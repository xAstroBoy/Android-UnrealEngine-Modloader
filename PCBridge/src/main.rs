// src/main.rs
// PCBridge — desktop control panel for the UE ModLoader on-device bridge.
// Toggle individual Lua/DLL mods on/off (fully — hooks & code patches restored
// via the modloader's mod_tracker), flip every mod at once, and watch a live,
// auto-saving logcat/modloader stream.
#![cfg_attr(not(debug_assertions), windows_subsystem = "windows")]

mod adb;
mod app;
mod bridge;
mod worker;

fn main() -> eframe::Result<()> {
    let options = eframe::NativeOptions {
        viewport: egui::ViewportBuilder::default()
            .with_inner_size([980.0, 720.0])
            .with_min_inner_size([720.0, 480.0])
            .with_title("PCBridge — UE ModLoader Control"),
        ..Default::default()
    };

    eframe::run_native(
        "PCBridge",
        options,
        Box::new(|cc| Ok(Box::new(app::PcBridgeApp::new(cc)))),
    )
}
