// Embed the application icon into the Windows .exe so it shows in Explorer,
// the taskbar, and Alt-Tab. No-op on non-Windows hosts. Requires a resource
// compiler (Windows SDK rc.exe, auto-detected by winresource).
fn main() {
    #[cfg(windows)]
    {
        println!("cargo:rerun-if-changed=assets/pcbridge.ico");
        let mut res = winresource::WindowsResource::new();
        res.set_icon("assets/pcbridge.ico");
        // Best-effort: if no resource compiler is found, don't fail the build —
        // the runtime egui window icon still applies.
        if let Err(e) = res.compile() {
            println!("cargo:warning=icon embed skipped: {e}");
        }
    }
}
