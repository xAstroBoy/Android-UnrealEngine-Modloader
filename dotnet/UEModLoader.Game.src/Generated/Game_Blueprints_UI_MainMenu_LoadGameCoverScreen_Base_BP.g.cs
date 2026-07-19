// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/MainMenu/LoadGameCoverScreen_Base_BP
using System;

namespace UEModLoader.Game
{
    public class LoadGameCoverScreen_Base_BP_C : VR4UIScreen
    {
        public const string UeClassName = "LoadGameCoverScreen_Base_BP_C";
        public LoadGameCoverScreen_Base_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new LoadGameCoverScreen_Base_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new LoadGameCoverScreen_Base_BP_C(p);
        public static LoadGameCoverScreen_Base_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new LoadGameCoverScreen_Base_BP_C(o.Pointer); }
        public static LoadGameCoverScreen_Base_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new LoadGameCoverScreen_Base_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new LoadGameCoverScreen_Base_BP_C(a[i].Pointer); return r; }
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public void SetHasActiveSaveData(bool HasActiveSaveData, int MostCurrentSave)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set<byte>(0x0, (byte)(HasActiveSaveData?1:0));
            __pb.Set(0x4, MostCurrentSave);
            CallRaw("SetHasActiveSaveData", __pb.Bytes);
        }
    }

}
