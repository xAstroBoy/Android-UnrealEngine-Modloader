// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Merchant/UI_Merchant_Character_BP
using System;

namespace UEModLoader.Game
{
    public class UI_Merchant_Character_BP_C : VR4PauseUIScreen
    {
        public const string UeClassName = "UI_Merchant_Character_BP_C";
        public UI_Merchant_Character_BP_C(System.IntPtr ptr) : base(ptr) {}
        public static new UI_Merchant_Character_BP_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new UI_Merchant_Character_BP_C(p);
        public static UI_Merchant_Character_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_Merchant_Character_BP_C(o.Pointer); }
        public static UI_Merchant_Character_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_Merchant_Character_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_Merchant_Character_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x258));
        public SkeletalMeshComponent Merchant { get { var __p = GetAt<System.IntPtr>(0x260); return __p==System.IntPtr.Zero?null:new SkeletalMeshComponent(__p); } set => SetAt(0x260, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent Merchant_Container { get { var __p = GetAt<System.IntPtr>(0x268); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x268, value?.Pointer ?? System.IntPtr.Zero); }
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<System.IntPtr>(0x270); return __p==System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x270, value?.Pointer ?? System.IntPtr.Zero); }
        public float Timeline_Walk_HeadScaleDown_14CECE1A4DC14A493F91ED9416FEC1C9 { get => GetAt<float>(0x278); set => SetAt(0x278, value); }
        public float Timeline_Walk_HeadScaleUp_14CECE1A4DC14A493F91ED9416FEC1C9 { get => GetAt<float>(0x27C); set => SetAt(0x27C, value); }
        public float Timeline_Walk_Walk_14CECE1A4DC14A493F91ED9416FEC1C9 { get => GetAt<float>(0x280); set => SetAt(0x280, value); }
        public byte Timeline_Walk__Direction_14CECE1A4DC14A493F91ED9416FEC1C9 { get => GetAt<byte>(0x284); set => SetAt(0x284, value); }
        public TimelineComponent Timeline_Walk { get { var __p = GetAt<System.IntPtr>(0x288); return __p==System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x288, value?.Pointer ?? System.IntPtr.Zero); }
        public void Timeline_Walk__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Walk__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_Walk__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_Walk__UpdateFunc", __pb.Bytes);
        }
        public void WalkForward()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("WalkForward", __pb.Bytes);
        }
        public void WalkBack()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("WalkBack", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_Merchant_Character_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_Merchant_Character_BP", __pb.Bytes);
        }
    }

}
