// src/adb.rs
// Thin wrapper over the `adb` CLI: establishes the bridge port-forward and
// streams `adb logcat` on a background thread into a shared ring buffer.

use std::fs::{File, OpenOptions};
use std::io::{BufRead, BufReader, BufWriter, Write};
use std::process::{Command, Stdio};
use std::sync::atomic::{AtomicBool, Ordering};
use std::sync::{Arc, Mutex};
use std::thread;

#[cfg(windows)]
use std::os::windows::process::CommandExt;
#[cfg(windows)]
const CREATE_NO_WINDOW: u32 = 0x0800_0000;

/// Build an `adb` Command, optionally targeting a specific serial, with no
/// console window popping up on Windows.
fn adb_cmd(adb_bin: &str, serial: &Option<String>) -> Command {
    let mut c = Command::new(adb_bin);
    if let Some(s) = serial {
        if !s.is_empty() {
            c.arg("-s").arg(s);
        }
    }
    #[cfg(windows)]
    c.creation_flags(CREATE_NO_WINDOW);
    c
}

/// List attached devices as (serial, state) rows.
pub fn devices(adb_bin: &str) -> Result<Vec<(String, String)>, String> {
    let out = adb_cmd(adb_bin, &None)
        .arg("devices")
        .stdout(Stdio::piped())
        .stderr(Stdio::piped())
        .output()
        .map_err(|e| format!("could not run '{adb_bin}': {e}"))?;
    let text = String::from_utf8_lossy(&out.stdout);
    let mut rows = Vec::new();
    for line in text.lines().skip(1) {
        let line = line.trim();
        if line.is_empty() {
            continue;
        }
        let mut parts = line.split_whitespace();
        if let (Some(serial), Some(state)) = (parts.next(), parts.next()) {
            rows.push((serial.to_string(), state.to_string()));
        }
    }
    Ok(rows)
}

/// `adb forward tcp:port tcp:port` — idempotent; safe to call before each
/// bridge burst. Returns the adb stderr on failure.
pub fn forward(adb_bin: &str, serial: &Option<String>, port: u16) -> Result<(), String> {
    let out = adb_cmd(adb_bin, serial)
        .arg("forward")
        .arg(format!("tcp:{port}"))
        .arg(format!("tcp:{port}"))
        .stdout(Stdio::piped())
        .stderr(Stdio::piped())
        .output()
        .map_err(|e| format!("could not run adb forward: {e}"))?;
    if out.status.success() {
        Ok(())
    } else {
        Err(String::from_utf8_lossy(&out.stderr).trim().to_string())
    }
}

/// Shared, runtime-togglable auto-save sink. When Some, every streamed line
/// is appended to the file as it arrives — so logcat/modloader spam that later
/// crashes the game or wedges the bridge is already persisted on disk.
pub type AutosaveSink = Arc<Mutex<Option<BufWriter<File>>>>;

/// A running logcat stream. Lines land in `buffer` (capped); drop or call
/// stop() to end the child process and reader thread.
pub struct LogcatStream {
    running: Arc<AtomicBool>,
    pub buffer: Arc<Mutex<Vec<String>>>,
    pub autosave: AutosaveSink,
    pub autosave_path: Option<String>,
    child: Option<std::process::Child>,
    handle: Option<thread::JoinHandle<()>>,
}

const MAX_LOG_LINES: usize = 20000;

impl LogcatStream {
    /// Start `adb logcat` (optionally filtered by a package's PID or a tag).
    /// `extra_args` are extra logcat arguments (e.g. ["UEModLoader:V", "*:S"]
    /// or a `--pid=` filter). Existing backlog is streamed first (context),
    /// then the live tail — we do NOT clear it here.
    pub fn start(adb_bin: &str, serial: &Option<String>, extra_args: &[String]) -> Result<Self, String> {
        let running = Arc::new(AtomicBool::new(true));
        let buffer = Arc::new(Mutex::new(Vec::<String>::new()));
        let autosave: AutosaveSink = Arc::new(Mutex::new(None));

        let mut cmd = adb_cmd(adb_bin, serial);
        cmd.arg("logcat");
        // -v time gives readable timestamps; keep it consistent regardless of
        // the device's default format.
        cmd.arg("-v").arg("time");
        for a in extra_args {
            cmd.arg(a);
        }
        cmd.stdout(Stdio::piped()).stderr(Stdio::piped());

        let mut child = cmd
            .spawn()
            .map_err(|e| format!("could not spawn adb logcat: {e}"))?;

        let stdout = child
            .stdout
            .take()
            .ok_or_else(|| "adb logcat produced no stdout".to_string())?;

        let running_t = running.clone();
        let buffer_t = buffer.clone();
        let autosave_t = autosave.clone();
        let handle = thread::spawn(move || {
            let reader = BufReader::new(stdout);
            for line in reader.lines() {
                if !running_t.load(Ordering::Relaxed) {
                    break;
                }
                let line = match line {
                    Ok(l) => l,
                    Err(_) => break,
                };
                // Persist first (before the in-memory cap can evict it) so a
                // crash right after this line still leaves it on disk.
                if let Ok(mut sink) = autosave_t.lock() {
                    if let Some(w) = sink.as_mut() {
                        let _ = w.write_all(line.as_bytes());
                        let _ = w.write_all(b"\n");
                        let _ = w.flush();
                    }
                }
                let mut buf = buffer_t.lock().unwrap();
                buf.push(line);
                if buf.len() > MAX_LOG_LINES {
                    let overflow = buf.len() - MAX_LOG_LINES;
                    buf.drain(0..overflow);
                }
            }
        });

        Ok(LogcatStream {
            running,
            buffer,
            autosave,
            autosave_path: None,
            child: Some(child),
            handle: Some(handle),
        })
    }

    /// Begin appending every subsequent line to `path`. Returns an error if the
    /// file cannot be opened. Overwrites any previous autosave sink.
    pub fn enable_autosave(&mut self, path: &str) -> Result<(), String> {
        let file = OpenOptions::new()
            .create(true)
            .append(true)
            .open(path)
            .map_err(|e| format!("cannot open {path}: {e}"))?;
        let mut w = BufWriter::new(file);
        let _ = writeln!(
            w,
            "==== PCBridge autosave started (append) ===="
        );
        let _ = w.flush();
        *self.autosave.lock().unwrap() = Some(w);
        self.autosave_path = Some(path.to_string());
        Ok(())
    }

    pub fn disable_autosave(&mut self) {
        if let Ok(mut sink) = self.autosave.lock() {
            if let Some(w) = sink.as_mut() {
                let _ = w.flush();
            }
            *sink = None;
        }
        self.autosave_path = None;
    }

    pub fn is_autosaving(&self) -> bool {
        self.autosave_path.is_some()
    }

    pub fn stop(&mut self) {
        self.running.store(false, Ordering::Relaxed);
        if let Some(mut child) = self.child.take() {
            let _ = child.kill();
            let _ = child.wait();
        }
        if let Some(h) = self.handle.take() {
            let _ = h.join();
        }
        self.disable_autosave();
    }
}

impl Drop for LogcatStream {
    fn drop(&mut self) {
        self.stop();
    }
}

/// Clear the device logcat backlog (`adb logcat -c`).
pub fn logcat_clear(adb_bin: &str, serial: &Option<String>) -> Result<(), String> {
    let out = adb_cmd(adb_bin, serial)
        .arg("logcat")
        .arg("-c")
        .output()
        .map_err(|e| format!("adb logcat -c failed: {e}"))?;
    if out.status.success() {
        Ok(())
    } else {
        Err(String::from_utf8_lossy(&out.stderr).trim().to_string())
    }
}
