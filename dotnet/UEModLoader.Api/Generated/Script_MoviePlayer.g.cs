// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/MoviePlayer
using System;

namespace UEModLoader.Game
{
    public enum EMoviePlaybackType
    {
        MT_Normal = 0,
        MT_Looped = 1,
        MT_LoadingLoop = 2,
    }

    public class MoviePlayerSettings : Object
    {
        public const string UeClassName = "MoviePlayerSettings";
        public MoviePlayerSettings(System.IntPtr ptr) : base(ptr) {}
        public static new MoviePlayerSettings FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new MoviePlayerSettings(p);
        public static MoviePlayerSettings FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new MoviePlayerSettings(o.Pointer); }
        public static MoviePlayerSettings[] All() { var a = UObject.FindAllOf(UeClassName); var r = new MoviePlayerSettings[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new MoviePlayerSettings(a[i].Pointer); return r; }
        public bool bWaitForMoviesToComplete { get => Native.GetPropBool(Pointer, "bWaitForMoviesToComplete"); set => Native.SetPropBool(Pointer, "bWaitForMoviesToComplete", value); }
        public bool bMoviesAreSkippable { get => Native.GetPropBool(Pointer, "bMoviesAreSkippable"); set => Native.SetPropBool(Pointer, "bMoviesAreSkippable", value); }
        public TArray<System.IntPtr> StartupMovies => new TArray<System.IntPtr>(AddrOf(0x30)); // TArray<FString>
    }

}
