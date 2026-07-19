// UEModLoader.Api / AssemblyInfo.cs
// The generated game proxies (UEModLoader.Game) call the internal Native bridge
// directly (the "just native" property path). Grant that companion assembly —
// whether compiled on PC or on-device — access to this API's internals.
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("UEModLoader.Game")]
