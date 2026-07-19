// src/worker.rs
// Background worker: bridge ops (mod load/disable, list, stats) can block up to
// ~25s on the game thread, so they must never run on the egui UI thread. The UI
// posts Jobs down a channel; a single worker thread drains them sequentially
// (the bridge is serialized on the game thread anyway) and posts JobResults back.

use crate::bridge;
use crate::adb;
use serde_json::Value;
use std::sync::mpsc::{Receiver, Sender};
use std::sync::{Arc, Mutex};
use std::thread;

#[derive(Clone)]
pub struct WorkerConfig {
    pub adb_bin: String,
    pub serial: Option<String>,
    pub port: u16,
}

pub enum Job {
    Ping,
    RefreshMods,
    Enable(String),
    Disable(String),
    Unload(String),
    Reload(String),
    SetAll(bool),
    RefreshStats,
    /// Generic bridge call — used by the Lua console, raw bridge console, and
    /// object inspector. `tag` is an opaque routing key the UI matches on when
    /// the reply comes back; `timeout_s` bounds the (possibly game-thread) op.
    Bridge {
        tag: String,
        cmd: String,
        params: Value,
        timeout_s: u64,
    },
}

pub enum JobResult {
    Pong(bool),
    Mods(Result<Vec<bridge::ModEntry>, String>),
    /// A single-mod op finished. `verb` is enable/disable/unload/reload.
    OpDone {
        verb: String,
        target: String,
        result: Result<String, String>,
    },
    SetAllDone(Result<String, String>),
    Stats(Result<Value, String>),
    /// Reply to a Job::Bridge, carrying the same `tag` for UI routing.
    Bridge {
        tag: String,
        cmd: String,
        result: Result<Value, String>,
    },
}

pub struct Worker {
    pub tx: Sender<Job>,
    pub rx: Receiver<JobResult>,
    cfg: Arc<Mutex<WorkerConfig>>,
}

impl Worker {
    pub fn spawn(cfg: WorkerConfig, ctx: egui::Context) -> Self {
        let (job_tx, job_rx) = std::sync::mpsc::channel::<Job>();
        let (res_tx, res_rx) = std::sync::mpsc::channel::<JobResult>();
        let shared = Arc::new(Mutex::new(cfg));
        let shared_t = shared.clone();

        thread::spawn(move || {
            for job in job_rx {
                let cfg = shared_t.lock().unwrap().clone();
                // Re-establish the port-forward before each op — cheap and
                // idempotent, and recovers automatically after a replug.
                let _ = adb::forward(&cfg.adb_bin, &cfg.serial, cfg.port);
                let result = run_job(&cfg, job);
                if res_tx.send(result).is_err() {
                    break; // UI gone
                }
                ctx.request_repaint(); // wake the UI to consume the result
            }
        });

        Worker {
            tx: job_tx,
            rx: res_rx,
            cfg: shared,
        }
    }

    pub fn update_config(&self, cfg: WorkerConfig) {
        *self.cfg.lock().unwrap() = cfg;
    }

    pub fn post(&self, job: Job) {
        let _ = self.tx.send(job);
    }
}

fn run_job(cfg: &WorkerConfig, job: Job) -> JobResult {
    let p = cfg.port;
    match job {
        Job::Ping => JobResult::Pong(bridge::ping(p).unwrap_or(false)),
        Job::RefreshMods => JobResult::Mods(bridge::list_mods(p)),
        Job::RefreshStats => JobResult::Stats(bridge::get_stats(p)),
        Job::Enable(name) => JobResult::OpDone {
            verb: "enable".into(),
            result: bridge::enable_mod(p, &name),
            target: name,
        },
        Job::Disable(name) => JobResult::OpDone {
            verb: "disable".into(),
            result: bridge::disable_mod(p, &name),
            target: name,
        },
        Job::Unload(name) => JobResult::OpDone {
            verb: "unload".into(),
            result: bridge::unload_mod(p, &name),
            target: name,
        },
        Job::Reload(name) => JobResult::OpDone {
            verb: "reload".into(),
            result: bridge::reload_mod(p, &name),
            target: name,
        },
        Job::SetAll(enabled) => JobResult::SetAllDone(bridge::set_all_mods(p, enabled)),
        Job::Bridge {
            tag,
            cmd,
            params,
            timeout_s,
        } => {
            let result = bridge::raw(p, &cmd, params, std::time::Duration::from_secs(timeout_s));
            JobResult::Bridge { tag, cmd, result }
        }
    }
}
