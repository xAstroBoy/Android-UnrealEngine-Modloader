// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Save/VR4SaveGame_BP
using System;

namespace UEModLoader.Game
{
    public class VR4SaveGame_BP_C : VR4SaveGame
    {
        public const string UeClassName = "VR4SaveGame_BP_C";
        public VR4SaveGame_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new VR4SaveGame_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new VR4SaveGame_BP_C(p);
        public static VR4SaveGame_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new VR4SaveGame_BP_C(o.Pointer); }
        public static VR4SaveGame_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new VR4SaveGame_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new VR4SaveGame_BP_C(a[i].Pointer); return r; }
        public global::System.IntPtr SaveSlotData => AddrOf(0x598); // 
        public global::System.IntPtr CurrentSlotData => AddrOf(0x5E8); // struct SaveSlotData
        public DateTime DEBUG_Now => new DateTime(AddrOf(0x5F8));
        public bool DEBUG_UseDebugNow { get => Native.GetPropBool(Pointer, "DEBUG_UseDebugNow"); set => Native.SetPropBool(Pointer, "DEBUG_UseDebugNow", value); }
        public TArray<global::System.IntPtr> SelectedChallenge => new TArray<global::System.IntPtr>(AddrOf(0x608)); // TArray<FName>
        public DateTime LastMercenariesNewIndicatorDateTime => new DateTime(AddrOf(0x618));
        public DateTime LastChallengesNewIndicatorDateTime => new DateTime(AddrOf(0x620));
        public bool DEBUG_BypassLockedMercContent { get => Native.GetPropBool(Pointer, "DEBUG_BypassLockedMercContent"); set => Native.SetPropBool(Pointer, "DEBUG_BypassLockedMercContent", value); }
        public bool LeaderboardGlobal { get => Native.GetPropBool(Pointer, "LeaderboardGlobal"); set => Native.SetPropBool(Pointer, "LeaderboardGlobal", value); }
        public bool LeaderboardClassic { get => Native.GetPropBool(Pointer, "LeaderboardClassic"); set => Native.SetPropBool(Pointer, "LeaderboardClassic", value); }
        public ELeaderboardStartAt LeaderboardStartAt { get => (ELeaderboardStartAt)GetAt<byte>(0x62B); set => SetAt(0x62B, (byte)value); }
        public int LeaderboardClassicIndex { get => GetAt<int>(0x62C); set => SetAt(0x62C, value); }
        public int LeaderboardChallengeIndex { get => GetAt<int>(0x630); set => SetAt(0x630, value); }
        public void SetLeaderboardIndices(int Classic, int challenge)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, Classic);
            __pb.Set(0x4, challenge);
            CallRaw("SetLeaderboardIndices", __pb.Bytes);
        }
        public void GetLeaderboardIndices(int Classic, int challenge)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, Classic);
            __pb.Set(0x4, challenge);
            CallRaw("GetLeaderboardIndices", __pb.Bytes);
        }
        public void SetLeaderboardSettings(bool Global, bool Classic, ELeaderboardStartAt StartAt)
        {
            var __pb = new ParamBuffer(3);
            __pb.Set<byte>(0x0, (byte)(Global?1:0));
            __pb.Set<byte>(0x1, (byte)(Classic?1:0));
            __pb.Set<byte>(0x2, (byte)StartAt);
            CallRaw("SetLeaderboardSettings", __pb.Bytes);
        }
        public void GetLeaderboardSettings(bool Global, bool Classic, ELeaderboardStartAt StartAt)
        {
            var __pb = new ParamBuffer(3);
            __pb.Set<byte>(0x0, (byte)(Global?1:0));
            __pb.Set<byte>(0x1, (byte)(Classic?1:0));
            __pb.Set<byte>(0x2, (byte)StartAt);
            CallRaw("GetLeaderboardSettings", __pb.Bytes);
        }
        public void ClearChallengesNewIndicator()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ClearChallengesNewIndicator", __pb.Bytes);
        }
        public void ShowChallengesNewIndicator(bool Show)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Show?1:0));
            CallRaw("ShowChallengesNewIndicator", __pb.Bytes);
        }
        public void ClearMercenariesNewIndicator()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ClearMercenariesNewIndicator", __pb.Bytes);
        }
        public void ShowMercenariesNewIndicator(bool Show)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Show?1:0));
            CallRaw("ShowMercenariesNewIndicator", __pb.Bytes);
        }
        public void HasNewChallengeRelativeToDate(global::System.IntPtr InDate, bool HasNew)
        {
            var __pb = new ParamBuffer(9);
            __pb.Set<global::System.IntPtr>(0x0, InDate);
            __pb.Set<byte>(0x8, (byte)(HasNew?1:0));
            CallRaw("HasNewChallengeRelativeToDate", __pb.Bytes);
        }
        public void SetSelectedChallenge(FName ChallengeKey, bool Selected)
        {
            var __pb = new ParamBuffer(9);
            __pb.Set(0x0, ChallengeKey);
            __pb.Set<byte>(0x8, (byte)(Selected?1:0));
            CallRaw("SetSelectedChallenge", __pb.Bytes);
        }
        public void HasSelectedChallenge(FName ChallengeKey, bool HasSelected)
        {
            var __pb = new ParamBuffer(9);
            __pb.Set(0x0, ChallengeKey);
            __pb.Set<byte>(0x8, (byte)(HasSelected?1:0));
            CallRaw("HasSelectedChallenge", __pb.Bytes);
        }
        public void Get_Now(global::System.IntPtr Now)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<global::System.IntPtr>(0x0, Now);
            CallRaw("Get Now", __pb.Bytes);
        }
        public void HasNewChallenge(bool HasNew)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(HasNew?1:0));
            CallRaw("HasNewChallenge", __pb.Bytes);
        }
        public void PostLoadGame()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PostLoadGame", __pb.Bytes);
        }
        public void ClearTutorialProgress()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ClearTutorialProgress", __pb.Bytes);
        }
        public void saveSlot(int Slot, bool IsClearSlot)
        {
            var __pb = new ParamBuffer(5);
            __pb.Set(0x0, Slot);
            __pb.Set<byte>(0x4, (byte)(IsClearSlot?1:0));
            CallRaw("saveSlot", __pb.Bytes);
        }
        public void LoadSlot(int Slot, bool IsClearSlot)
        {
            var __pb = new ParamBuffer(5);
            __pb.Set(0x0, Slot);
            __pb.Set<byte>(0x4, (byte)(IsClearSlot?1:0));
            CallRaw("LoadSlot", __pb.Bytes);
        }
        public void SetTutorialCompleted(FName Tutorial, bool Completed)
        {
            var __pb = new ParamBuffer(9);
            __pb.Set(0x0, Tutorial);
            __pb.Set<byte>(0x8, (byte)(Completed?1:0));
            CallRaw("SetTutorialCompleted", __pb.Bytes);
        }
        public void IsTutorialCompleted(FName Tutorial, bool Completed)
        {
            var __pb = new ParamBuffer(9);
            __pb.Set(0x0, Tutorial);
            __pb.Set<byte>(0x8, (byte)(Completed?1:0));
            CallRaw("IsTutorialCompleted", __pb.Bytes);
        }
    }

}
