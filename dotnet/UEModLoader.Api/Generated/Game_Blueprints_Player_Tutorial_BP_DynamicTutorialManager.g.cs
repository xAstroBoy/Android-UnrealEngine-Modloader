// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Tutorial/BP_DynamicTutorialManager
using System;

namespace UEModLoader.Game
{
    public class BP_DynamicTutorialManager_C : VR4DynamicTutorialManager
    {
        public const string UeClassName = "BP_DynamicTutorialManager_C";
        public BP_DynamicTutorialManager_C(System.IntPtr ptr) : base(ptr) {}
        public static new BP_DynamicTutorialManager_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new BP_DynamicTutorialManager_C(p);
        public static BP_DynamicTutorialManager_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new BP_DynamicTutorialManager_C(o.Pointer); }
        public static BP_DynamicTutorialManager_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new BP_DynamicTutorialManager_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new BP_DynamicTutorialManager_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x2E0));
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<System.IntPtr>(0x2E8); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x2E8, value?.Pointer ?? System.IntPtr.Zero); }
        public TutorialHand_Base_BP_C LeftHandOverride { get { var __p = GetAt<System.IntPtr>(0x2F0); return __p==System.IntPtr.Zero?null:new TutorialHand_Base_BP_C(__p); } set => SetAt(0x2F0, value?.Pointer ?? System.IntPtr.Zero); }
        public TutorialHand_Base_BP_C RightHandOverride { get { var __p = GetAt<System.IntPtr>(0x2F8); return __p==System.IntPtr.Zero?null:new TutorialHand_Base_BP_C(__p); } set => SetAt(0x2F8, value?.Pointer ?? System.IntPtr.Zero); }
        public bool AlwaysShow { get => Native.GetPropBool(Pointer, "AlwaysShow"); set => Native.SetPropBool(Pointer, "AlwaysShow", value); }
        public void WorldDilationChanged(float WorldTimeDilation, float PlayerTimeDilation, float CustomTimeDilation)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set(0x0, WorldTimeDilation);
            __pb.Set(0x4, PlayerTimeDilation);
            __pb.Set(0x8, CustomTimeDilation);
            CallRaw("WorldDilationChanged", __pb.Bytes);
        }
        public bool CanDisplayTutorialControllers()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("CanDisplayTutorialControllers", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        public bool IsDynamicTutorialEnabled()
        {
            var __pb = new ParamBuffer(1);
            CallRaw("IsDynamicTutorialEnabled", __pb.Bytes);
            return __pb.Get<byte>(0x0) != 0;
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void ExecuteUbergraph_BP_DynamicTutorialManager(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_BP_DynamicTutorialManager", __pb.Bytes);
        }
    }

}
