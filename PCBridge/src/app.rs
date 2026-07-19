// src/app.rs
// The egui application: a Mods tab (per-mod on/off, all on/off, reload/unload)
// and a Logs tab (live logcat + modloader stream with filters and auto-save).

use crate::adb::{self, LogcatStream};
use crate::bridge::ModEntry;
use crate::worker::{Job, JobResult, Worker, WorkerConfig};
use serde_json::{json, Value};
use std::collections::HashSet;
use std::time::{Duration, Instant};

#[derive(PartialEq, Clone, Copy)]
enum Tab {
    Mods,
    Objects,
    Lua,
    Bridge,
    Paks,
    Logs,
}

/// One entry in the Lua console transcript.
struct LuaEntry {
    code: String,
    output: String,
    ok: bool,
}

#[derive(PartialEq, Clone, Copy)]
enum LogFilterMode {
    All,
    ModLoaderOnly,
    WarnAndUp,
}

pub struct PcBridgeApp {
    // ── connection config ──────────────────────────────────────────────
    adb_bin: String,
    serial: String, // "" = auto
    port: u16,
    devices: Vec<(String, String)>,

    // ── worker + live state ────────────────────────────────────────────
    worker: Worker,
    mods: Vec<ModEntry>,
    busy_mods: HashSet<String>,
    busy_all: bool,
    connected: Option<bool>,
    stats: Option<Value>,
    messages: Vec<(Instant, String)>, // newest last
    last_auto_refresh: Instant,
    auto_refresh: bool,

    // ── tabs ───────────────────────────────────────────────────────────
    tab: Tab,

    // ── logs ───────────────────────────────────────────────────────────
    logcat: Option<LogcatStream>,
    log_filter_mode: LogFilterMode,
    log_text_filter: String,
    log_autoscroll: bool,
    log_autosave_path: String,
    log_error: Option<String>,

    // ── Lua console ─────────────────────────────────────────────────────
    lua_input: String,
    lua_log: Vec<LuaEntry>,
    lua_history: Vec<String>,
    lua_hist_idx: Option<usize>,
    lua_busy: bool,

    // ── raw bridge console ──────────────────────────────────────────────
    bridge_cmd: String,
    bridge_params: String,
    bridge_output: String,
    bridge_cmd_list: Vec<String>,
    bridge_busy: bool,

    // ── paks ────────────────────────────────────────────────────────────
    paks: Vec<Value>,
    pak_mount_input: String,
    paks_msg: String,

    // ── object inspector ────────────────────────────────────────────────
    obj_classes: Vec<Value>,      // [{name, count}] (live) or [{name, package}] (all)
    obj_class_search: String,     // filter for the class browser
    obj_class_live: bool,         // true = class_counts (live), false = list_classes (all)
    obj_classes_msg: String,
    obj_classes_requested: bool,  // avoid re-firing the initial scan every frame
    obj_class_query: String,
    obj_instances: Vec<Value>,
    obj_instances_msg: String,
    obj_selected_addr: String,
    obj_inspect: Option<Value>,
    obj_prop_edits: std::collections::HashMap<String, String>,
    obj_prop_filter: String,
    obj_func_filter: String,
    obj_action_msg: String,
    obj_busy: bool,
}

impl PcBridgeApp {
    pub fn new(cc: &eframe::CreationContext<'_>) -> Self {
        let (adb_bin, port) = load_defaults();
        let cfg = WorkerConfig {
            adb_bin: adb_bin.clone(),
            serial: None,
            port,
        };
        let worker = Worker::spawn(cfg, cc.egui_ctx.clone());

        // Kick off an immediate connection check + mod refresh, and prefetch the
        // bridge command list + pak list for the Bridge/Paks tabs.
        worker.post(Job::Ping);
        worker.post(Job::RefreshMods);
        worker.post(Job::RefreshStats);
        worker.post(Job::Bridge {
            tag: "help".into(),
            cmd: "help".into(),
            params: json!({}),
            timeout_s: 6,
        });
        worker.post(Job::Bridge {
            tag: "paks".into(),
            cmd: "list_paks".into(),
            params: json!({}),
            timeout_s: 8,
        });

        let devices = adb::devices(&adb_bin).unwrap_or_default();

        let default_autosave = default_autosave_path();

        Self {
            adb_bin,
            serial: String::new(),
            port,
            devices,
            worker,
            mods: Vec::new(),
            busy_mods: HashSet::new(),
            busy_all: false,
            connected: None,
            stats: None,
            messages: Vec::new(),
            last_auto_refresh: Instant::now(),
            auto_refresh: true,
            tab: Tab::Mods,
            logcat: None,
            log_filter_mode: LogFilterMode::All,
            log_text_filter: String::new(),
            log_autoscroll: true,
            log_autosave_path: default_autosave,
            log_error: None,

            lua_input: String::new(),
            lua_log: Vec::new(),
            lua_history: Vec::new(),
            lua_hist_idx: None,
            lua_busy: false,

            bridge_cmd: "get_stats".to_string(),
            bridge_params: "{}".to_string(),
            bridge_output: String::new(),
            bridge_cmd_list: Vec::new(),
            bridge_busy: false,

            paks: Vec::new(),
            pak_mount_input: String::new(),
            paks_msg: String::new(),

            obj_classes: Vec::new(),
            obj_class_search: String::new(),
            obj_class_live: true,
            obj_classes_msg: String::new(),
            obj_classes_requested: false,
            obj_class_query: String::new(),
            obj_instances: Vec::new(),
            obj_instances_msg: String::new(),
            obj_selected_addr: String::new(),
            obj_inspect: None,
            obj_prop_edits: std::collections::HashMap::new(),
            obj_prop_filter: String::new(),
            obj_func_filter: String::new(),
            obj_action_msg: String::new(),
            obj_busy: false,
        }
    }

    /// Post a generic bridge call routed back by `tag`.
    fn post_bridge(&self, tag: &str, cmd: &str, params: Value, timeout_s: u64) {
        self.worker.post(Job::Bridge {
            tag: tag.to_string(),
            cmd: cmd.to_string(),
            params,
            timeout_s,
        });
    }

    fn serial_opt(&self) -> Option<String> {
        if self.serial.trim().is_empty() {
            None
        } else {
            Some(self.serial.trim().to_string())
        }
    }

    fn push_msg(&mut self, msg: impl Into<String>) {
        self.messages.push((Instant::now(), msg.into()));
        if self.messages.len() > 200 {
            let overflow = self.messages.len() - 200;
            self.messages.drain(0..overflow);
        }
    }

    fn sync_worker_config(&self) {
        self.worker.update_config(WorkerConfig {
            adb_bin: self.adb_bin.clone(),
            serial: self.serial_opt(),
            port: self.port,
        });
    }

    fn drain_worker(&mut self) {
        // Collect first to avoid borrowing self across the loop.
        let mut results = Vec::new();
        while let Ok(r) = self.worker.rx.try_recv() {
            results.push(r);
        }
        for r in results {
            match r {
                JobResult::Pong(ok) => {
                    self.connected = Some(ok);
                }
                JobResult::Mods(Ok(mods)) => {
                    self.connected = Some(true);
                    self.mods = mods;
                }
                JobResult::Mods(Err(e)) => {
                    self.connected = Some(false);
                    self.log_error = Some(e.clone());
                    self.push_msg(format!("list_mods failed: {e}"));
                }
                JobResult::Stats(Ok(v)) => {
                    self.stats = Some(v);
                }
                JobResult::Stats(Err(_)) => {}
                JobResult::OpDone {
                    verb,
                    target,
                    result,
                } => {
                    self.busy_mods.remove(&target);
                    match result {
                        Ok(msg) => self.push_msg(format!("{verb} {target}: {msg}")),
                        Err(e) => self.push_msg(format!("{verb} {target} FAILED: {e}")),
                    }
                    // Refresh the list so status reflects the change.
                    self.worker.post(Job::RefreshMods);
                    self.worker.post(Job::RefreshStats);
                }
                JobResult::SetAllDone(result) => {
                    self.busy_all = false;
                    match result {
                        Ok(msg) => self.push_msg(format!("set all: {msg}")),
                        Err(e) => self.push_msg(format!("set all FAILED: {e}")),
                    }
                    self.worker.post(Job::RefreshMods);
                    self.worker.post(Job::RefreshStats);
                }
                JobResult::Bridge { tag, cmd, result } => {
                    self.handle_bridge_reply(&tag, &cmd, result);
                }
            }
        }
    }

    fn handle_bridge_reply(&mut self, tag: &str, _cmd: &str, result: Result<Value, String>) {
        match tag {
            "lua" => {
                self.lua_busy = false;
                let (ok, output) = match result {
                    Ok(v) => (true, value_to_text(&v)),
                    Err(e) => (false, e),
                };
                if let Some(last) = self.lua_log.last_mut() {
                    if last.output.is_empty() && !last.ok {
                        last.output = output;
                        last.ok = ok;
                        return;
                    }
                }
            }
            "raw" => {
                self.bridge_busy = false;
                self.bridge_output = match result {
                    Ok(v) => serde_json::to_string_pretty(&v).unwrap_or_else(|_| value_to_text(&v)),
                    Err(e) => format!("ERROR: {e}"),
                };
            }
            "help" => {
                if let Ok(Value::Array(arr)) = result {
                    self.bridge_cmd_list = arr
                        .into_iter()
                        .filter_map(|v| v.as_str().map(|s| s.to_string()))
                        .collect();
                    self.bridge_cmd_list.sort();
                }
            }
            "paks" => {
                self.paks = match result {
                    Ok(Value::Array(arr)) => arr,
                    _ => Vec::new(),
                };
            }
            "mount" => {
                self.paks_msg = match result {
                    Ok(v) => format!("mount: {}", value_to_text(&v)),
                    Err(e) => format!("mount FAILED: {e}"),
                };
                self.post_bridge("paks", "list_paks", json!({}), 8);
            }
            "classes" => {
                self.obj_busy = false;
                match result {
                    Ok(v) => {
                        self.obj_classes = v
                            .get("classes")
                            .and_then(|c| c.as_array())
                            .cloned()
                            .unwrap_or_default();
                        let scanned = v.get("scanned_objects").and_then(|s| s.as_i64());
                        let distinct = v
                            .get("distinct_classes")
                            .or_else(|| v.get("total_known"))
                            .and_then(|s| s.as_i64())
                            .unwrap_or(0);
                        self.obj_classes_msg = match scanned {
                            Some(n) => format!("{} classes with instances ({} objects scanned)", distinct, n),
                            None => format!("{} known classes", distinct),
                        };
                    }
                    Err(e) => {
                        self.obj_classes.clear();
                        self.obj_classes_msg = format!("ERROR: {e}");
                    }
                }
            }
            "instances" => {
                self.obj_busy = false;
                match result {
                    Ok(v) => {
                        let total = v.get("total").and_then(|t| t.as_i64()).unwrap_or(0);
                        let returned = v.get("returned").and_then(|t| t.as_i64()).unwrap_or(0);
                        self.obj_instances = v
                            .get("instances")
                            .and_then(|i| i.as_array())
                            .cloned()
                            .unwrap_or_default();
                        self.obj_instances_msg =
                            format!("{returned} shown of {total} live instance(s)");
                    }
                    Err(e) => {
                        self.obj_instances.clear();
                        self.obj_instances_msg = format!("ERROR: {e}");
                    }
                }
            }
            "inspect" => {
                self.obj_busy = false;
                match result {
                    Ok(v) => {
                        self.obj_prop_edits.clear();
                        self.obj_inspect = Some(v);
                    }
                    Err(e) => {
                        self.obj_action_msg = format!("inspect ERROR: {e}");
                    }
                }
            }
            "setprop" => {
                self.obj_action_msg = match result {
                    Ok(v) => format!("set → {}", value_to_text(&v)),
                    Err(e) => format!("set FAILED: {e}"),
                };
                // Re-inspect to show the committed value.
                if !self.obj_selected_addr.is_empty() {
                    self.post_bridge(
                        "inspect",
                        "inspect",
                        json!({ "address": self.obj_selected_addr }),
                        10,
                    );
                }
            }
            "call" => {
                self.obj_action_msg = match result {
                    Ok(v) => format!("call → {}", value_to_text(&v)),
                    Err(e) => format!("call FAILED: {e}"),
                };
            }
            _ => {}
        }
    }

    fn toggle_mod(&mut self, entry_name: &str, currently_on: bool) {
        if self.busy_mods.contains(entry_name) {
            return;
        }
        self.busy_mods.insert(entry_name.to_string());
        if currently_on {
            self.worker.post(Job::Disable(entry_name.to_string()));
        } else {
            self.worker.post(Job::Enable(entry_name.to_string()));
        }
    }

    // ── logcat control ─────────────────────────────────────────────────
    fn logcat_args(&self) -> Vec<String> {
        match self.log_filter_mode {
            LogFilterMode::All => vec![],
            // Show ONLY the modloader's own tag, silence everything else.
            LogFilterMode::ModLoaderOnly => vec!["UEModLoader:V".into(), "*:S".into()],
            LogFilterMode::WarnAndUp => vec!["*:W".into()],
        }
    }

    fn start_logcat(&mut self) {
        self.stop_logcat();
        let args = self.logcat_args();
        match LogcatStream::start(&self.adb_bin, &self.serial_opt(), &args) {
            Ok(stream) => {
                self.log_error = None;
                self.logcat = Some(stream);
                self.push_msg("logcat stream started");
            }
            Err(e) => {
                self.log_error = Some(e.clone());
                self.push_msg(format!("logcat start failed: {e}"));
            }
        }
    }

    fn stop_logcat(&mut self) {
        if let Some(mut s) = self.logcat.take() {
            s.stop();
        }
    }

    fn toggle_autosave(&mut self) {
        let path = self.log_autosave_path.clone();
        // Snapshot whether we should enable, and act, then message — avoids
        // holding a mutable borrow of self.logcat across the &mut self methods.
        let mut msg: Option<String> = None;
        if let Some(stream) = self.logcat.as_mut() {
            if stream.is_autosaving() {
                stream.disable_autosave();
                msg = Some("autosave stopped".to_string());
            } else {
                match stream.enable_autosave(&path) {
                    Ok(()) => msg = Some(format!("autosave → {path}")),
                    Err(e) => msg = Some(format!("autosave failed: {e}")),
                }
            }
        } else {
            msg = Some("start the logcat stream first".to_string());
        }
        if let Some(m) = msg {
            self.push_msg(m);
        }
    }

    fn save_log_snapshot(&mut self) {
        let path = snapshot_path();
        let lines: Vec<String> = self
            .logcat
            .as_ref()
            .map(|s| s.buffer.lock().unwrap().clone())
            .unwrap_or_default();
        if lines.is_empty() {
            self.push_msg("nothing to save (log buffer empty)");
            return;
        }
        match std::fs::write(&path, lines.join("\n")) {
            Ok(()) => self.push_msg(format!("saved {} lines → {path}", lines.len())),
            Err(e) => self.push_msg(format!("save failed: {e}")),
        }
    }
}

impl eframe::App for PcBridgeApp {
    fn update(&mut self, ctx: &egui::Context, _frame: &mut eframe::Frame) {
        self.drain_worker();

        // Periodic auto-refresh of the mod list + stats + connection.
        if self.auto_refresh && self.last_auto_refresh.elapsed() > Duration::from_secs(3) {
            self.last_auto_refresh = Instant::now();
            self.worker.post(Job::Ping);
            self.worker.post(Job::RefreshMods);
            self.worker.post(Job::RefreshStats);
        }
        // Keep the UI live while logcat streams in.
        if self.logcat.is_some() {
            ctx.request_repaint_after(Duration::from_millis(400));
        } else {
            ctx.request_repaint_after(Duration::from_millis(800));
        }

        self.top_bar(ctx);
        self.status_bar(ctx);

        match self.tab {
            Tab::Mods => self.mods_tab(ctx),
            Tab::Objects => self.objects_tab(ctx),
            Tab::Lua => self.lua_tab(ctx),
            Tab::Bridge => self.bridge_tab(ctx),
            Tab::Paks => self.paks_tab(ctx),
            Tab::Logs => self.logs_tab(ctx),
        }
    }
}

// ── UI sections ────────────────────────────────────────────────────────────
impl PcBridgeApp {
    fn top_bar(&mut self, ctx: &egui::Context) {
        egui::TopBottomPanel::top("top").show(ctx, |ui| {
            ui.add_space(4.0);
            ui.horizontal(|ui| {
                ui.heading("PCBridge");
                ui.separator();
                let (dot, label) = match self.connected {
                    Some(true) => (egui::Color32::from_rgb(0x3f, 0xb9, 0x50), "connected"),
                    Some(false) => (egui::Color32::from_rgb(0xd0, 0x40, 0x40), "no bridge"),
                    None => (egui::Color32::GRAY, "connecting…"),
                };
                ui.colored_label(dot, "●");
                ui.label(label);

                ui.separator();
                ui.selectable_value(&mut self.tab, Tab::Mods, "Mods");
                ui.selectable_value(&mut self.tab, Tab::Objects, "Objects");
                ui.selectable_value(&mut self.tab, Tab::Lua, "Lua");
                ui.selectable_value(&mut self.tab, Tab::Bridge, "Bridge");
                ui.selectable_value(&mut self.tab, Tab::Paks, "Paks");
                ui.selectable_value(&mut self.tab, Tab::Logs, "Logs");

                ui.with_layout(egui::Layout::right_to_left(egui::Align::Center), |ui| {
                    if ui.button("⟳ Refresh").clicked() {
                        self.sync_worker_config();
                        self.worker.post(Job::Ping);
                        self.worker.post(Job::RefreshMods);
                        self.worker.post(Job::RefreshStats);
                    }
                    ui.checkbox(&mut self.auto_refresh, "auto");
                });
            });

            ui.add_space(2.0);
            ui.horizontal(|ui| {
                ui.label("adb:");
                if ui
                    .add(egui::TextEdit::singleline(&mut self.adb_bin).desired_width(120.0))
                    .lost_focus()
                {
                    self.sync_worker_config();
                }
                ui.label("device:");
                let current = if self.serial.is_empty() {
                    "(auto)".to_string()
                } else {
                    self.serial.clone()
                };
                egui::ComboBox::from_id_source("serial_combo")
                    .selected_text(current)
                    .show_ui(ui, |ui| {
                        let mut changed = ui
                            .selectable_value(&mut self.serial, String::new(), "(auto)")
                            .clicked();
                        for (serial, state) in &self.devices {
                            let label = format!("{serial}  [{state}]");
                            changed |= ui
                                .selectable_value(&mut self.serial, serial.clone(), label)
                                .clicked();
                        }
                        if changed {
                            self.sync_worker_config();
                        }
                    });
                if ui.button("scan").clicked() {
                    self.devices = adb::devices(&self.adb_bin).unwrap_or_default();
                }
                ui.label("port:");
                let mut port_str = self.port.to_string();
                if ui
                    .add(egui::TextEdit::singleline(&mut port_str).desired_width(60.0))
                    .lost_focus()
                {
                    if let Ok(p) = port_str.parse::<u16>() {
                        self.port = p;
                        self.sync_worker_config();
                    }
                }
            });
            ui.add_space(4.0);
        });
    }

    fn status_bar(&mut self, ctx: &egui::Context) {
        egui::TopBottomPanel::bottom("status").show(ctx, |ui| {
            ui.add_space(2.0);
            ui.horizontal(|ui| {
                // Latest message on the left.
                if let Some((_, msg)) = self.messages.last() {
                    ui.label(egui::RichText::new(msg).monospace());
                }
                ui.with_layout(egui::Layout::right_to_left(egui::Align::Center), |ui| {
                    let loaded = self
                        .mods
                        .iter()
                        .filter(|m| m.status == "loaded" || m.status == "errored")
                        .count();
                    let disabled = self
                        .mods
                        .iter()
                        .filter(|m| m.status == "disabled")
                        .count();
                    ui.label(format!(
                        "{} mods · {} on · {} disabled",
                        self.mods.len(),
                        loaded,
                        disabled
                    ));
                    if let Some(stats) = &self.stats {
                        if let Some(hooks) = stats.get("active_hooks").and_then(|v| v.as_i64()) {
                            ui.separator();
                            ui.label(format!("{hooks} hooks"));
                        }
                    }
                });
            });
            ui.add_space(2.0);
        });
    }

    fn mods_tab(&mut self, ctx: &egui::Context) {
        egui::CentralPanel::default().show(ctx, |ui| {
            ui.horizontal(|ui| {
                let en = ui.add_enabled(!self.busy_all, egui::Button::new("✅ Enable ALL"));
                if en.clicked() {
                    self.busy_all = true;
                    self.worker.post(Job::SetAll(true));
                }
                let dis = ui.add_enabled(!self.busy_all, egui::Button::new("⛔ Disable ALL"));
                if dis.clicked() {
                    self.busy_all = true;
                    self.worker.post(Job::SetAll(false));
                }
                if self.busy_all {
                    ui.spinner();
                    ui.label("applying to all mods…");
                }
            });
            ui.separator();

            if self.mods.is_empty() {
                ui.add_space(20.0);
                ui.vertical_centered(|ui| {
                    match self.connected {
                        Some(false) | None => {
                            ui.label("No bridge connection.");
                            ui.label(
                                egui::RichText::new(
                                    "Launch the game with the modloader injected, then Refresh.",
                                )
                                .weak(),
                            );
                        }
                        Some(true) => {
                            ui.label("No mods found on device.");
                        }
                    }
                });
                return;
            }

            // Snapshot rows so we don't borrow self.mods while mutating busy set.
            let rows: Vec<ModEntry> = self.mods.clone();
            egui::ScrollArea::vertical().show(ui, |ui| {
                egui::Grid::new("mods_grid")
                    .num_columns(4)
                    .striped(true)
                    .spacing([12.0, 6.0])
                    .show(ui, |ui| {
                        ui.strong("On");
                        ui.strong("Mod");
                        ui.strong("Status");
                        ui.strong("Actions");
                        ui.end_row();

                        for m in &rows {
                            let is_on = m.status == "loaded" || m.status == "errored";
                            let busy = self.busy_mods.contains(&m.name);

                            // Toggle switch (checkbox).
                            let mut on = is_on;
                            let cb = ui.add_enabled(
                                !busy && !self.busy_all,
                                egui::Checkbox::without_text(&mut on),
                            );
                            if cb.clicked() {
                                self.toggle_mod(&m.name, is_on);
                            }

                            // Name.
                            ui.label(egui::RichText::new(&m.name).strong());

                            // Status (color-coded) + spinner while busy.
                            ui.horizontal(|ui| {
                                let (col, txt) = status_color(&m.status);
                                ui.colored_label(col, txt);
                                if !m.enabled && m.status != "disabled" {
                                    ui.label(egui::RichText::new("(persisted off)").weak().small());
                                }
                                if busy {
                                    ui.spinner();
                                }
                                if let Some(err) = &m.last_error {
                                    if !err.is_empty() {
                                        ui.label(
                                            egui::RichText::new("⚠")
                                                .color(egui::Color32::from_rgb(0xd0, 0x90, 0x30)),
                                        )
                                        .on_hover_text(err);
                                    }
                                }
                            });

                            // Per-mod actions.
                            ui.horizontal(|ui| {
                                let can_act = !busy && !self.busy_all;
                                if ui
                                    .add_enabled(can_act && is_on, egui::Button::new("⟲ reload"))
                                    .on_hover_text("Re-run this mod's main.lua (tears down old hooks first)")
                                    .clicked()
                                {
                                    self.busy_mods.insert(m.name.clone());
                                    self.worker.post(Job::Reload(m.name.clone()));
                                }
                                if ui
                                    .add_enabled(can_act && is_on, egui::Button::new("⏏ unload"))
                                    .on_hover_text(
                                        "Release hooks/patches/timers now, but keep it enabled for next launch",
                                    )
                                    .clicked()
                                {
                                    self.busy_mods.insert(m.name.clone());
                                    self.worker.post(Job::Unload(m.name.clone()));
                                }
                            });
                            ui.end_row();
                        }
                    });
            });
        });
    }

    fn logs_tab(&mut self, ctx: &egui::Context) {
        egui::CentralPanel::default().show(ctx, |ui| {
            ui.horizontal_wrapped(|ui| {
                let streaming = self.logcat.is_some();
                if streaming {
                    if ui.button("⏹ Stop").clicked() {
                        self.stop_logcat();
                        self.push_msg("logcat stopped");
                    }
                } else if ui.button("▶ Start stream").clicked() {
                    self.start_logcat();
                }

                ui.separator();
                ui.label("filter:");
                let mut mode_changed = false;
                mode_changed |= ui
                    .selectable_value(&mut self.log_filter_mode, LogFilterMode::All, "All")
                    .clicked();
                mode_changed |= ui
                    .selectable_value(
                        &mut self.log_filter_mode,
                        LogFilterMode::ModLoaderOnly,
                        "ModLoader",
                    )
                    .clicked();
                mode_changed |= ui
                    .selectable_value(
                        &mut self.log_filter_mode,
                        LogFilterMode::WarnAndUp,
                        "Warn+",
                    )
                    .clicked();
                // Changing the logcat-side filter requires restarting the child.
                if mode_changed && streaming {
                    self.start_logcat();
                }

                ui.separator();
                ui.checkbox(&mut self.log_autoscroll, "autoscroll");
            });

            ui.horizontal(|ui| {
                ui.label("find:");
                ui.add(
                    egui::TextEdit::singleline(&mut self.log_text_filter)
                        .hint_text("substring filter (client-side)")
                        .desired_width(240.0),
                );
                if ui.button("✖").on_hover_text("clear filter").clicked() {
                    self.log_text_filter.clear();
                }
                ui.separator();

                // Auto-save controls — the whole point: keep the spam on disk.
                let autosaving = self
                    .logcat
                    .as_ref()
                    .map(|s| s.is_autosaving())
                    .unwrap_or(false);
                ui.add(
                    egui::TextEdit::singleline(&mut self.log_autosave_path)
                        .desired_width(280.0)
                        .hint_text("auto-save file path"),
                );
                let btn_label = if autosaving {
                    "⏺ Stop auto-save"
                } else {
                    "⏺ Auto-save"
                };
                let btn = egui::Button::new(btn_label).fill(if autosaving {
                    egui::Color32::from_rgb(0x8a, 0x2a, 0x2a)
                } else {
                    ui.visuals().widgets.inactive.bg_fill
                });
                if ui
                    .add(btn)
                    .on_hover_text(
                        "Append every incoming line to the file as it arrives — survives a game/bridge crash",
                    )
                    .clicked()
                {
                    self.toggle_autosave();
                }
                if ui.button("💾 Save now").clicked() {
                    self.save_log_snapshot();
                }
            });

            if let Some(err) = &self.log_error {
                ui.colored_label(egui::Color32::from_rgb(0xd0, 0x40, 0x40), err);
            }
            if let Some(stream) = &self.logcat {
                if stream.is_autosaving() {
                    if let Some(p) = &stream.autosave_path {
                        ui.label(
                            egui::RichText::new(format!("⏺ auto-saving → {p}"))
                                .small()
                                .color(egui::Color32::from_rgb(0xd0, 0x60, 0x60)),
                        );
                    }
                }
            }
            ui.separator();

            // Snapshot + filter the buffer, then render.
            let filter = self.log_text_filter.to_lowercase();
            let lines: Vec<String> = match &self.logcat {
                Some(s) => {
                    let buf = s.buffer.lock().unwrap();
                    if filter.is_empty() {
                        buf.clone()
                    } else {
                        buf.iter()
                            .filter(|l| l.to_lowercase().contains(&filter))
                            .cloned()
                            .collect()
                    }
                }
                None => Vec::new(),
            };

            let text_style = egui::TextStyle::Monospace;
            let row_h = ui.text_style_height(&text_style);
            let mut scroll = egui::ScrollArea::vertical().auto_shrink([false, false]);
            if self.log_autoscroll {
                scroll = scroll.stick_to_bottom(true);
            }
            scroll.show_rows(ui, row_h, lines.len(), |ui, range| {
                for i in range {
                    let line = &lines[i];
                    let color = line_color(line);
                    ui.label(
                        egui::RichText::new(line)
                            .monospace()
                            .size(12.0)
                            .color(color),
                    );
                }
            });

            if self.logcat.is_none() {
                ui.add_space(8.0);
                ui.label(
                    egui::RichText::new(
                        "Press ▶ Start stream to begin. 'ModLoader' filter shows only the \
                         modloader's own log; 'All' captures game-wide spam too. Toggle \
                         Auto-save to persist everything to disk as it streams.",
                    )
                    .weak(),
                );
            }
        });
    }
}

// ── Lua console ─────────────────────────────────────────────────────────────
impl PcBridgeApp {
    fn run_lua(&mut self) {
        let code = self.lua_input.trim().to_string();
        if code.is_empty() || self.lua_busy {
            return;
        }
        self.lua_busy = true;
        self.lua_history.push(code.clone());
        self.lua_hist_idx = None;
        self.lua_log.push(LuaEntry {
            code: code.clone(),
            output: String::new(),
            ok: false,
        });
        self.post_bridge("lua", "exec_lua", json!({ "code": code }), 12);
        self.lua_input.clear();
    }

    fn lua_tab(&mut self, ctx: &egui::Context) {
        egui::TopBottomPanel::bottom("lua_input_panel").show(ctx, |ui| {
            ui.add_space(4.0);
            ui.horizontal(|ui| {
                ui.label("Lua:");
                let resp = ui.add(
                    egui::TextEdit::multiline(&mut self.lua_input)
                        .desired_rows(2)
                        .desired_width(f32::INFINITY)
                        .hint_text("exec_lua on the game thread — Ctrl+Enter to run"),
                );
                // Ctrl+Enter runs.
                if resp.has_focus()
                    && ui.input(|i| i.modifiers.command && i.key_pressed(egui::Key::Enter))
                {
                    self.run_lua();
                }
            });
            ui.horizontal(|ui| {
                if ui
                    .add_enabled(!self.lua_busy, egui::Button::new("▶ Run (Ctrl+Enter)"))
                    .clicked()
                {
                    self.run_lua();
                }
                if self.lua_busy {
                    ui.spinner();
                }
                if ui.button("Clear log").clicked() {
                    self.lua_log.clear();
                }
                // A couple of handy starter snippets.
                if ui.small_button("stat fps").clicked() {
                    self.lua_input = "return exec_console and 'use Bridge tab' or 'stat'".into();
                }
                if ui.small_button("GetSDKCounts").clicked() {
                    self.lua_input =
                        "local c,s,e = GetSDKCounts(); return string.format('classes=%d structs=%d enums=%d', c, s, e)".into();
                }
                if ui.small_button("PlayerController").clicked() {
                    self.lua_input =
                        "local pc = FindFirstOf('PlayerController'); return pc and pc:GetFullName() or 'none'".into();
                }
            });
            ui.add_space(4.0);
        });

        egui::CentralPanel::default().show(ctx, |ui| {
            egui::ScrollArea::vertical()
                .auto_shrink([false, false])
                .stick_to_bottom(true)
                .show(ui, |ui| {
                    for entry in &self.lua_log {
                        ui.horizontal_wrapped(|ui| {
                            ui.label(egui::RichText::new("»").strong().color(egui::Color32::GRAY));
                            ui.label(egui::RichText::new(&entry.code).monospace().color(
                                egui::Color32::from_rgb(0x9a, 0xd0, 0xe0),
                            ));
                        });
                        if entry.output.is_empty() && !entry.ok {
                            ui.label(egui::RichText::new("  …").weak());
                        } else {
                            let col = if entry.ok {
                                egui::Color32::from_gray(0xd0)
                            } else {
                                egui::Color32::from_rgb(0xe0, 0x60, 0x60)
                            };
                            ui.label(egui::RichText::new(&entry.output).monospace().color(col));
                        }
                        ui.separator();
                    }
                });
        });
    }

    // ── raw bridge console ──────────────────────────────────────────────
    fn bridge_tab(&mut self, ctx: &egui::Context) {
        egui::CentralPanel::default().show(ctx, |ui| {
            ui.label(
                egui::RichText::new(
                    "Send any bridge command with raw JSON params — the full bridge surface.",
                )
                .weak(),
            );
            ui.horizontal(|ui| {
                ui.label("cmd:");
                egui::ComboBox::from_id_source("bridge_cmd_combo")
                    .selected_text(&self.bridge_cmd)
                    .width(220.0)
                    .show_ui(ui, |ui| {
                        for c in &self.bridge_cmd_list {
                            ui.selectable_value(&mut self.bridge_cmd, c.clone(), c);
                        }
                    });
                ui.add(
                    egui::TextEdit::singleline(&mut self.bridge_cmd)
                        .desired_width(160.0)
                        .hint_text("or type"),
                );
                let send = ui.add_enabled(!self.bridge_busy, egui::Button::new("Send"));
                if send.clicked() {
                    self.send_raw_bridge();
                }
                if self.bridge_busy {
                    ui.spinner();
                }
            });
            ui.horizontal(|ui| {
                ui.label("params:");
                ui.add(
                    egui::TextEdit::multiline(&mut self.bridge_params)
                        .desired_rows(2)
                        .desired_width(f32::INFINITY)
                        .code_editor()
                        .hint_text("{\"key\": value}  — JSON merged into the command"),
                );
            });
            ui.separator();
            let mut out_view = self.bridge_output.clone();
            egui::ScrollArea::vertical()
                .auto_shrink([false, false])
                .show(ui, |ui| {
                    ui.add(
                        egui::TextEdit::multiline(&mut out_view)
                            .desired_width(f32::INFINITY)
                            .code_editor()
                            .interactive(false),
                    );
                });
        });
    }

    fn send_raw_bridge(&mut self) {
        let cmd = self.bridge_cmd.trim().to_string();
        if cmd.is_empty() {
            return;
        }
        let params: Value = if self.bridge_params.trim().is_empty() {
            json!({})
        } else {
            match serde_json::from_str(&self.bridge_params) {
                Ok(v) => v,
                Err(e) => {
                    self.bridge_output = format!("bad params JSON: {e}");
                    return;
                }
            }
        };
        self.bridge_busy = true;
        self.bridge_output = "…".into();
        self.post_bridge("raw", &cmd, params, 30);
    }

    // ── paks ────────────────────────────────────────────────────────────
    fn paks_tab(&mut self, ctx: &egui::Context) {
        egui::CentralPanel::default().show(ctx, |ui| {
            ui.horizontal(|ui| {
                if ui.button("⟳ Refresh").clicked() {
                    self.post_bridge("paks", "list_paks", json!({}), 8);
                }
                ui.separator();
                ui.label("mount:");
                ui.add(
                    egui::TextEdit::singleline(&mut self.pak_mount_input)
                        .desired_width(280.0)
                        .hint_text("pak name (in paks/) or full device path"),
                );
                if ui.button("Mount").clicked() {
                    let name = self.pak_mount_input.trim().to_string();
                    if !name.is_empty() {
                        self.post_bridge("mount", "mount_pak", json!({ "path": name }), 20);
                    }
                }
            });
            if !self.paks_msg.is_empty() {
                ui.label(egui::RichText::new(&self.paks_msg).monospace());
            }
            ui.separator();
            if self.paks.is_empty() {
                ui.label(egui::RichText::new("No paks reported.").weak());
                return;
            }
            egui::ScrollArea::vertical().show(ui, |ui| {
                egui::Grid::new("paks_grid")
                    .num_columns(3)
                    .striped(true)
                    .spacing([16.0, 6.0])
                    .show(ui, |ui| {
                        ui.strong("Mounted");
                        ui.strong("Name");
                        ui.strong("Size (MB)");
                        ui.end_row();
                        for p in &self.paks {
                            let mounted = p.get("mounted").and_then(|m| m.as_bool()).unwrap_or(false);
                            let (c, t) = if mounted {
                                (egui::Color32::from_rgb(0x3f, 0xb9, 0x50), "✔")
                            } else {
                                (egui::Color32::GRAY, "—")
                            };
                            ui.colored_label(c, t);
                            ui.label(p.get("name").and_then(|n| n.as_str()).unwrap_or("?"));
                            let mb = p.get("size_mb").and_then(|s| s.as_f64()).unwrap_or(0.0);
                            ui.label(format!("{mb:.1}"));
                            ui.end_row();
                        }
                    });
            });
        });
    }

    // ── object inspector / editor ───────────────────────────────────────
    fn scan_classes(&mut self) {
        self.obj_busy = true;
        self.obj_classes_msg = "scanning…".into();
        let filter = self.obj_class_search.trim().to_string();
        if self.obj_class_live {
            // Live: walk GUObjectArray, tally instances per class. No limit.
            self.post_bridge(
                "classes",
                "class_counts",
                json!({ "min": 1, "filter": filter }),
                25,
            );
        } else {
            // All reflection-known classes (instant). No limit.
            self.post_bridge("classes", "list_classes", json!({ "filter": filter }), 15);
        }
    }

    fn load_instances(&mut self, cls: &str) {
        self.obj_class_query = cls.to_string();
        self.obj_busy = true;
        self.obj_instances.clear();
        self.obj_instances_msg = "loading instances…".into();
        // No limit — return every live instance.
        self.post_bridge("instances", "list_instances", json!({ "class": cls }), 20);
    }

    fn objects_tab(&mut self, ctx: &egui::Context) {
        // Auto-scan classes the first time the tab is opened.
        if !self.obj_classes_requested {
            self.obj_classes_requested = true;
            self.scan_classes();
        }

        // Column 1: class browser.
        egui::SidePanel::left("obj_classes_panel")
            .resizable(true)
            .default_width(260.0)
            .show(ctx, |ui| {
                ui.add_space(4.0);
                ui.strong("Classes");
                ui.horizontal(|ui| {
                    let resp = ui.add(
                        egui::TextEdit::singleline(&mut self.obj_class_search)
                            .desired_width(140.0)
                            .hint_text("filter"),
                    );
                    let go = ui.button("Scan").clicked()
                        || (resp.lost_focus() && ui.input(|i| i.key_pressed(egui::Key::Enter)));
                    if go {
                        self.scan_classes();
                    }
                });
                ui.horizontal(|ui| {
                    if ui
                        .selectable_label(self.obj_class_live, "Live (with counts)")
                        .clicked()
                    {
                        self.obj_class_live = true;
                        self.scan_classes();
                    }
                    if ui.selectable_label(!self.obj_class_live, "All known").clicked() {
                        self.obj_class_live = false;
                        self.scan_classes();
                    }
                });
                if !self.obj_classes_msg.is_empty() {
                    ui.label(egui::RichText::new(&self.obj_classes_msg).weak().small());
                }
                ui.separator();

                // Client-side filter on top of whatever the scan returned, then
                // virtualize — 2700+ classes must render without lag (no clamp).
                let filt = self.obj_class_search.to_lowercase();
                let filtered: Vec<(String, Option<i64>)> = self
                    .obj_classes
                    .iter()
                    .filter_map(|c| {
                        let name = c.get("name").and_then(|n| n.as_str())?.to_string();
                        if !filt.is_empty() && !name.to_lowercase().contains(&filt) {
                            return None;
                        }
                        Some((name, c.get("count").and_then(|n| n.as_i64())))
                    })
                    .collect();
                let row_h = ui.text_style_height(&egui::TextStyle::Body);
                let mut clicked: Option<String> = None;
                egui::ScrollArea::vertical()
                    .id_source("class_scroll")
                    .auto_shrink([false, false])
                    .show_rows(ui, row_h, filtered.len(), |ui, range| {
                        for i in range {
                            let (name, count) = &filtered[i];
                            let label = match count {
                                Some(n) => format!("{name}  ({n})"),
                                None => name.clone(),
                            };
                            let selected = &self.obj_class_query == name;
                            if ui.selectable_label(selected, label).clicked() {
                                clicked = Some(name.clone());
                            }
                        }
                    });
                if let Some(name) = clicked {
                    self.load_instances(&name);
                }
            });

        // Column 2: instances of the selected class.
        egui::SidePanel::left("obj_instances_panel")
            .resizable(true)
            .default_width(260.0)
            .show(ctx, |ui| {
                ui.add_space(4.0);
                ui.horizontal(|ui| {
                    ui.strong("Instances");
                    if self.obj_busy {
                        ui.spinner();
                    }
                });
                if self.obj_class_query.is_empty() {
                    ui.label(egui::RichText::new("Pick a class →").weak());
                } else {
                    ui.label(
                        egui::RichText::new(&self.obj_class_query)
                            .monospace()
                            .small(),
                    );
                }
                if !self.obj_instances_msg.is_empty() {
                    ui.label(egui::RichText::new(&self.obj_instances_msg).weak().small());
                }
                ui.separator();
                // Virtualized — an instance list can be many thousands long.
                let rows: Vec<(String, String)> = self
                    .obj_instances
                    .iter()
                    .map(|inst| {
                        (
                            inst.get("address").and_then(|a| a.as_str()).unwrap_or("").to_string(),
                            inst.get("name").and_then(|n| n.as_str()).unwrap_or("?").to_string(),
                        )
                    })
                    .collect();
                let row_h = ui.text_style_height(&egui::TextStyle::Body) * 2.0 + 4.0;
                let mut picked: Option<String> = None;
                egui::ScrollArea::vertical()
                    .id_source("inst_scroll")
                    .auto_shrink([false, false])
                    .show_rows(ui, row_h, rows.len(), |ui, range| {
                        for i in range {
                            let (addr, name) = &rows[i];
                            let selected = &self.obj_selected_addr == addr;
                            if ui
                                .selectable_label(selected, format!("{name}\n{addr}"))
                                .clicked()
                            {
                                picked = Some(addr.clone());
                            }
                        }
                    });
                if let Some(addr) = picked {
                    self.obj_selected_addr = addr.clone();
                    self.obj_action_msg.clear();
                    self.obj_busy = true;
                    self.post_bridge("inspect", "inspect", json!({ "address": addr }), 15);
                }
            });

        // Column 3: inspector.
        egui::CentralPanel::default().show(ctx, |ui| {
            self.render_inspector(ui);
        });
    }

    fn render_inspector(&mut self, ui: &mut egui::Ui) {
        let inspect = match &self.obj_inspect {
            Some(v) => v.clone(),
            None => {
                ui.add_space(20.0);
                ui.vertical_centered(|ui| {
                    ui.label("Search a class on the left, then pick an instance to inspect.");
                    ui.label(
                        egui::RichText::new(
                            "Properties are editable; functions can be invoked. \
                             Reads are non-faulting, so inspecting never crashes the game.",
                        )
                        .weak(),
                    );
                });
                return;
            }
        };

        let addr = inspect.get("address").and_then(|a| a.as_str()).unwrap_or("").to_string();
        ui.horizontal(|ui| {
            ui.heading(inspect.get("name").and_then(|n| n.as_str()).unwrap_or("?"));
            ui.label(
                egui::RichText::new(format!(
                    "{}  ·  {}",
                    inspect.get("class").and_then(|c| c.as_str()).unwrap_or("?"),
                    addr
                ))
                .monospace()
                .weak(),
            );
            if ui.button("⟳").on_hover_text("re-inspect").clicked() && !addr.is_empty() {
                self.post_bridge("inspect", "inspect", json!({ "address": addr }), 12);
            }
        });
        if !self.obj_action_msg.is_empty() {
            ui.label(egui::RichText::new(&self.obj_action_msg).monospace().color(
                egui::Color32::from_rgb(0x9a, 0xd0, 0xe0),
            ));
        }
        ui.separator();

        let empty = Vec::new();
        let props = inspect.get("properties").and_then(|p| p.as_array()).unwrap_or(&empty);
        let funcs = inspect.get("functions").and_then(|f| f.as_array()).unwrap_or(&empty);

        egui::ScrollArea::vertical().auto_shrink([false, false]).show(ui, |ui| {
            egui::CollapsingHeader::new(format!("Properties ({})", props.len()))
                .default_open(true)
                .show(ui, |ui| {
                    ui.horizontal(|ui| {
                        ui.label("filter:");
                        ui.add(
                            egui::TextEdit::singleline(&mut self.obj_prop_filter)
                                .desired_width(180.0),
                        );
                    });
                    let filt = self.obj_prop_filter.to_lowercase();
                    egui::Grid::new("prop_grid")
                        .num_columns(4)
                        .striped(true)
                        .spacing([10.0, 4.0])
                        .show(ui, |ui| {
                            for p in props {
                                let pname =
                                    p.get("name").and_then(|n| n.as_str()).unwrap_or("").to_string();
                                if !filt.is_empty() && !pname.to_lowercase().contains(&filt) {
                                    continue;
                                }
                                let ptype =
                                    p.get("type").and_then(|t| t.as_str()).unwrap_or("");
                                let pval = p.get("value").cloned().unwrap_or(Value::Null);

                                ui.label(egui::RichText::new(&pname).strong());
                                ui.label(egui::RichText::new(ptype).weak().small());

                                // Editable value field (seeded from current value).
                                // Copy out of the edit map so we hold no &mut self
                                // borrow across the set_property call below.
                                let mut edit = self
                                    .obj_prop_edits
                                    .get(&pname)
                                    .cloned()
                                    .unwrap_or_else(|| value_to_text(&pval));
                                let resp = ui.add(
                                    egui::TextEdit::singleline(&mut edit).desired_width(220.0),
                                );
                                let commit = resp.lost_focus()
                                    && ui.input(|i| i.key_pressed(egui::Key::Enter));
                                let set_clicked = ui.button("set").clicked();
                                self.obj_prop_edits.insert(pname.clone(), edit.clone());
                                if (commit || set_clicked) && !addr.is_empty() {
                                    self.set_property(&addr, &pname, ptype, &edit);
                                }
                                ui.end_row();
                            }
                        });
                });

            ui.add_space(6.0);
            egui::CollapsingHeader::new(format!("Functions ({})", funcs.len()))
                .default_open(false)
                .show(ui, |ui| {
                    ui.horizontal(|ui| {
                        ui.label("filter:");
                        ui.add(
                            egui::TextEdit::singleline(&mut self.obj_func_filter)
                                .desired_width(180.0),
                        );
                    });
                    let filt = self.obj_func_filter.to_lowercase();
                    for f in funcs {
                        let fname = f.get("name").and_then(|n| n.as_str()).unwrap_or("").to_string();
                        if !filt.is_empty() && !fname.to_lowercase().contains(&filt) {
                            continue;
                        }
                        let nparms = f.get("num_parms").and_then(|n| n.as_i64()).unwrap_or(0);
                        ui.horizontal(|ui| {
                            let can_call = nparms == 0 && !addr.is_empty();
                            if ui
                                .add_enabled(can_call, egui::Button::new("invoke"))
                                .on_hover_text(if nparms == 0 {
                                    "call this no-arg function on the instance"
                                } else {
                                    "has params — call it from the Lua tab: obj:Call('Name', args)"
                                })
                                .clicked()
                            {
                                self.call_function(&addr, &fname);
                            }
                            ui.label(egui::RichText::new(&fname).strong());
                            if nparms > 0 {
                                ui.label(
                                    egui::RichText::new(format!("({nparms} params)"))
                                        .weak()
                                        .small(),
                                );
                            }
                        });
                    }
                });
        });
    }

    /// Commit a property edit by generating Lua through the wrapper (which does
    /// all the type marshalling): `UObjectFromPtr(IntToPtr(A)):Set('P', V)`.
    fn set_property(&mut self, addr: &str, prop: &str, ptype: &str, raw_val: &str) {
        let lua_val = lua_literal_for(ptype, raw_val);
        let code = format!(
            "local o = UObjectFromPtr(IntToPtr({addr})); if not o then return 'null object' end; \
             o:Set('{p}', {v}); return tostring(o:Get('{p}'))",
            addr = addr,
            p = crate::bridge::lua_escape(prop),
            v = lua_val,
        );
        self.obj_action_msg = format!("set {prop} = {raw_val} …");
        self.post_bridge("setprop", "exec_lua", json!({ "code": code }), 12);
    }

    /// Invoke a no-arg UFunction on the instance via the wrapper's :Call.
    fn call_function(&mut self, addr: &str, func: &str) {
        let code = format!(
            "local o = UObjectFromPtr(IntToPtr({addr})); if not o then return 'null object' end; \
             return tostring(o:Call('{f}'))",
            addr = addr,
            f = crate::bridge::lua_escape(func),
        );
        self.obj_action_msg = format!("invoke {func} …");
        self.post_bridge("call", "exec_lua", json!({ "code": code }), 12);
    }
}

// ── helpers ────────────────────────────────────────────────────────────────

/// Render a bridge/JSON value as a compact human string for display.
fn value_to_text(v: &Value) -> String {
    match v {
        Value::Null => "nil".to_string(),
        Value::Bool(b) => b.to_string(),
        Value::Number(n) => n.to_string(),
        Value::String(s) => s.clone(),
        other => serde_json::to_string(other).unwrap_or_default(),
    }
}

/// Turn a user-entered value into a Lua literal, typed by the property's UE type
/// so `:Set` receives the right Lua type (number / boolean / quoted string).
fn lua_literal_for(ptype: &str, raw: &str) -> String {
    let t = ptype.to_lowercase();
    let trimmed = raw.trim();
    let numeric = t.contains("int")
        || t.contains("float")
        || t.contains("double")
        || t.contains("byte")
        || t.contains("enum");
    if t.contains("bool") {
        let b = matches!(trimmed, "true" | "1" | "yes" | "on");
        return b.to_string();
    }
    if numeric {
        if trimmed.parse::<f64>().is_ok() {
            return trimmed.to_string();
        }
        // fall through to quoting if not a clean number
    }
    format!("'{}'", crate::bridge::lua_escape(trimmed))
}

fn status_color(status: &str) -> (egui::Color32, String) {
    match status {
        "loaded" => (egui::Color32::from_rgb(0x3f, 0xb9, 0x50), "loaded".into()),
        "errored" => (egui::Color32::from_rgb(0xd0, 0x90, 0x30), "errored".into()),
        "disabled" => (egui::Color32::GRAY, "disabled".into()),
        "unloaded" => (egui::Color32::from_rgb(0x70, 0x90, 0xc0), "unloaded".into()),
        "failed" => (egui::Color32::from_rgb(0xd0, 0x40, 0x40), "failed".into()),
        other => (egui::Color32::LIGHT_GRAY, other.to_string()),
    }
}

fn line_color(line: &str) -> egui::Color32 {
    // adb logcat -v time prefixes priority as " E/", " W/", " I/", " D/".
    if line.contains(" E/") || line.contains("/ E ") {
        egui::Color32::from_rgb(0xe0, 0x60, 0x60)
    } else if line.contains(" W/") || line.contains("/ W ") {
        egui::Color32::from_rgb(0xd8, 0xb0, 0x50)
    } else if line.contains("UEModLoader") {
        egui::Color32::from_rgb(0x7a, 0xc0, 0xe0)
    } else {
        egui::Color32::from_gray(0xc0)
    }
}

/// Read defaults (adb path, bridge port) from the MCP config if present so the
/// tool "just works" alongside the existing tooling.
fn load_defaults() -> (String, u16) {
    let mut adb_bin = "adb".to_string();
    let mut port = crate::bridge::DEFAULT_PORT;
    if let Some(home) = dirs_home() {
        let cfg_path = format!("{home}/.ue_modloader_mcp.json");
        if let Ok(text) = std::fs::read_to_string(&cfg_path) {
            if let Ok(v) = serde_json::from_str::<Value>(&text) {
                if let Some(a) = v.get("adb").and_then(|x| x.as_str()) {
                    if !a.is_empty() {
                        adb_bin = a.to_string();
                    }
                }
                if let Some(p) = v.get("bridge_port").and_then(|x| x.as_u64()) {
                    port = p as u16;
                }
            }
        }
    }
    (adb_bin, port)
}

fn dirs_home() -> Option<String> {
    std::env::var("USERPROFILE")
        .ok()
        .or_else(|| std::env::var("HOME").ok())
}

fn default_autosave_path() -> String {
    let base = std::env::temp_dir();
    base.join("pcbridge_logcat.log")
        .to_string_lossy()
        .to_string()
}

fn snapshot_path() -> String {
    let base = std::env::temp_dir();
    base.join("pcbridge_log_snapshot.log")
        .to_string_lossy()
        .to_string()
}
