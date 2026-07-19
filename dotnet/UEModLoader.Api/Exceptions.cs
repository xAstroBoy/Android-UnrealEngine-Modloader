// UEModLoader.Api / Exceptions.cs
using System;

namespace UEModLoader
{
    /// <summary>
    /// Base for mod-thrown exceptions. Standard C# try/catch/throw works
    /// normally inside a mod — the host wraps every lifecycle/hook/command call
    /// in a try/catch (see ModRuntime.Safe), so a throw is logged (with the mod
    /// identity) and the game keeps running instead of the exception escaping
    /// into native code. Derive your own for typed handling.
    /// </summary>
    public class ModException : Exception
    {
        public ModException() { }
        public ModException(string message) : base(message) { }
        public ModException(string message, Exception inner) : base(message, inner) { }
    }

    /// <summary>Thrown when a UObject/UFunction/property couldn't be resolved.</summary>
    public class ReflectionException : ModException
    {
        public ReflectionException(string message) : base(message) { }
    }

    /// <summary>Thrown when a patch/hook target couldn't be resolved or applied.</summary>
    public class PatchException : ModException
    {
        public PatchException(string message) : base(message) { }
    }
}
