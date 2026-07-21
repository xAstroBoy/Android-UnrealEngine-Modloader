// src/bridge.rs
// TCP client for the modloader ADB bridge (127.0.0.1:19420, newline-delimited
// JSON). One request = one short-lived connection, mirroring the Python MCP's
// bridge_send(): the modloader closes nothing per-request, but a fresh socket
// per command keeps the protocol trivially stateless and avoids interleaving.

use serde::Deserialize;
use serde_json::{json, Value};
use std::io::{Read, Write};
use std::net::TcpStream;
use std::time::Duration;

pub const DEFAULT_PORT: u16 = 19420;

#[derive(Debug, Clone, Deserialize)]
pub struct ModEntry {
    pub name: String,
    pub status: String,
    #[serde(default = "default_true")]
    pub enabled: bool,
    #[serde(default)]
    pub errors: i64,
    #[serde(default)]
    pub last_error: Option<String>,
}

fn default_true() -> bool {
    true
}

/// One entry in the modloader's native-patch registry (embedded C++ patches like
/// the getPartsPtr guard, plus Lua-registered byte patches). Toggled live via
/// `native_patch_set`.
#[derive(Debug, Clone, Deserialize)]
pub struct NativePatch {
    pub id: String,
    #[serde(default)]
    pub desc: String,
    pub enabled: bool,
    #[serde(default)]
    pub kind: String, // "bytes" | "toggle"
    #[serde(default)]
    pub addr: Option<String>,
}

/// A parsed bridge reply. `ok=false` carries the modloader's error string.
pub struct Reply {
    pub ok: bool,
    pub result: Value,
    pub error: String,
}

/// Send one JSON command and read the single newline-terminated reply.
/// `timeout` bounds connect + read; the modloader's own game-thread ops can
/// take up to ~20s (mod load/disable), so callers pass a generous timeout.
pub fn send(port: u16, payload: Value, timeout: Duration) -> Result<Reply, String> {
    let mut stream = TcpStream::connect(("127.0.0.1", port))
        .map_err(|e| format!("connect 127.0.0.1:{port} failed: {e} — is the game running with the modloader injected?"))?;
    stream
        .set_read_timeout(Some(timeout))
        .map_err(|e| e.to_string())?;
    stream
        .set_write_timeout(Some(timeout))
        .map_err(|e| e.to_string())?;

    let mut line = serde_json::to_vec(&payload).map_err(|e| e.to_string())?;
    line.push(b'\n');
    stream.write_all(&line).map_err(|e| format!("write failed: {e}"))?;

    // Read until the first newline (one reply per line).
    let mut buf = Vec::with_capacity(8192);
    let mut chunk = [0u8; 8192];
    loop {
        match stream.read(&mut chunk) {
            Ok(0) => break,
            Ok(n) => {
                buf.extend_from_slice(&chunk[..n]);
                if buf.contains(&b'\n') {
                    break;
                }
            }
            Err(e) => {
                if buf.is_empty() {
                    return Err(format!("read failed: {e}"));
                }
                break;
            }
        }
    }

    let text = String::from_utf8_lossy(&buf);
    let first = text.split('\n').next().unwrap_or("").trim();
    if first.is_empty() {
        return Err("empty reply (game thread busy or timed out)".into());
    }
    let v: Value = serde_json::from_str(first).map_err(|e| format!("unparseable reply: {e} — raw: {first}"))?;
    let ok = v.get("ok").and_then(|b| b.as_bool()).unwrap_or(false);
    Ok(Reply {
        ok,
        result: v.get("result").cloned().unwrap_or(Value::Null),
        error: v
            .get("error")
            .and_then(|e| e.as_str())
            .unwrap_or("")
            .to_string(),
    })
}

/// Send an arbitrary bridge command with arbitrary params and return the raw
/// `result` value (or the error string). This is the generic path the worker
/// uses for the Lua console, the raw bridge console, and the object inspector.
pub fn raw(port: u16, cmd: &str, params: Value, timeout: Duration) -> Result<Value, String> {
    let r = command(port, cmd, params, timeout)?;
    if r.ok {
        Ok(r.result)
    } else {
        Err(r.error)
    }
}

/// Escape a string so it can be embedded inside a single-quoted Lua literal.
pub fn lua_escape(s: &str) -> String {
    let mut out = String::with_capacity(s.len() + 2);
    for c in s.chars() {
        match c {
            '\\' => out.push_str("\\\\"),
            '\'' => out.push_str("\\'"),
            '\n' => out.push_str("\\n"),
            '\r' => out.push_str("\\r"),
            _ => out.push(c),
        }
    }
    out
}

/// Convenience: build `{cmd, ...extra}` and send.
fn command(port: u16, cmd: &str, extra: Value, timeout: Duration) -> Result<Reply, String> {
    let mut payload = json!({ "cmd": cmd });
    if let (Some(obj), Some(extra_obj)) = (payload.as_object_mut(), extra.as_object()) {
        for (k, v) in extra_obj {
            obj.insert(k.clone(), v.clone());
        }
    }
    send(port, payload, timeout)
}

pub fn ping(port: u16) -> Result<bool, String> {
    let r = command(port, "ping", json!({}), Duration::from_secs(3))?;
    Ok(r.ok)
}

pub fn list_mods(port: u16) -> Result<Vec<ModEntry>, String> {
    let r = command(port, "list_mods", json!({}), Duration::from_secs(8))?;
    if !r.ok {
        return Err(r.error);
    }
    serde_json::from_value(r.result).map_err(|e| format!("bad list_mods result: {e}"))
}

fn simple_op(port: u16, cmd: &str, name: &str, timeout_secs: u64) -> Result<String, String> {
    let r = command(port, cmd, json!({ "name": name }), Duration::from_secs(timeout_secs))?;
    if r.ok {
        Ok(r.result.as_str().unwrap_or("ok").to_string())
    } else {
        Err(r.error)
    }
}

pub fn enable_mod(port: u16, name: &str) -> Result<String, String> {
    simple_op(port, "enable_mod", name, 25)
}

pub fn disable_mod(port: u16, name: &str) -> Result<String, String> {
    simple_op(port, "disable_mod", name, 25)
}

pub fn unload_mod(port: u16, name: &str) -> Result<String, String> {
    simple_op(port, "unload_mod", name, 25)
}

pub fn reload_mod(port: u16, name: &str) -> Result<String, String> {
    simple_op(port, "reload_mod", name, 25)
}

pub fn set_all_mods(port: u16, enabled: bool) -> Result<String, String> {
    let r = command(
        port,
        "set_all_mods",
        json!({ "enabled": enabled }),
        Duration::from_secs(70),
    )?;
    if r.ok {
        let affected = r.result.get("affected").and_then(|a| a.as_i64()).unwrap_or(0);
        Ok(format!(
            "{} {} mod(s)",
            if enabled { "enabled" } else { "disabled" },
            affected
        ))
    } else {
        Err(r.error)
    }
}

/// Fetch the modloader's own recent log lines (its in-memory ring buffer).
pub fn log_tail(port: u16, lines: u32) -> Result<Vec<String>, String> {
    let r = command(port, "log_tail", json!({ "lines": lines }), Duration::from_secs(8))?;
    if !r.ok {
        return Err(r.error);
    }
    match r.result {
        Value::Array(arr) => Ok(arr
            .into_iter()
            .map(|v| v.as_str().unwrap_or("").to_string())
            .collect()),
        Value::String(s) => Ok(s.lines().map(|l| l.to_string()).collect()),
        _ => Ok(vec![]),
    }
}

/// Modloader stats (uptime, counts, active hooks) for the status bar.
pub fn get_stats(port: u16) -> Result<Value, String> {
    let r = command(port, "get_stats", json!({}), Duration::from_secs(8))?;
    if r.ok {
        Ok(r.result)
    } else {
        Err(r.error)
    }
}
