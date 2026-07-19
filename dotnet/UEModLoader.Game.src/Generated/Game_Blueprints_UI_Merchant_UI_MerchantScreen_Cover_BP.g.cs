// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Merchant/UI_MerchantScreen_Cover_BP
using System;

namespace UEModLoader.Game
{
    public class UI_MerchantScreen_Cover_BP_C : Actor
    {
        public const string UeClassName = "UI_MerchantScreen_Cover_BP_C";
        public UI_MerchantScreen_Cover_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new UI_MerchantScreen_Cover_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UI_MerchantScreen_Cover_BP_C(p);
        public static UI_MerchantScreen_Cover_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_MerchantScreen_Cover_BP_C(o.Pointer); }
        public static UI_MerchantScreen_Cover_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_MerchantScreen_Cover_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_MerchantScreen_Cover_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x220));
        public StaticMeshComponent CoverSlat { get { var __p = GetAt<global::System.IntPtr>(0x228); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x228, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent CoverSlat_2 { get { var __p = GetAt<global::System.IntPtr>(0x230); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x230, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent CoverSlat_3 { get { var __p = GetAt<global::System.IntPtr>(0x238); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x238, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent CoverSlat_4 { get { var __p = GetAt<global::System.IntPtr>(0x240); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x240, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent CoverSlat_5 { get { var __p = GetAt<global::System.IntPtr>(0x248); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x248, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent CoverSlat_6 { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent CoverSlat_7 { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent CoverSlat_8 { get { var __p = GetAt<global::System.IntPtr>(0x260); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x260, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent CoverSlat_9 { get { var __p = GetAt<global::System.IntPtr>(0x268); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x268, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent CoverSlat_10 { get { var __p = GetAt<global::System.IntPtr>(0x270); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x270, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<global::System.IntPtr>(0x278); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x278, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float Timeline_0_Rotation10_Top_20C9DFBB425966866549FB82B24BDCB6 { get => GetAt<float>(0x280); set => SetAt(0x280, value); }
        public float Timeline_0_Rotation9_20C9DFBB425966866549FB82B24BDCB6 { get => GetAt<float>(0x284); set => SetAt(0x284, value); }
        public float Timeline_0_Rotation8_20C9DFBB425966866549FB82B24BDCB6 { get => GetAt<float>(0x288); set => SetAt(0x288, value); }
        public float Timeline_0_Rotation7_20C9DFBB425966866549FB82B24BDCB6 { get => GetAt<float>(0x28C); set => SetAt(0x28C, value); }
        public float Timeline_0_Rotation6_20C9DFBB425966866549FB82B24BDCB6 { get => GetAt<float>(0x290); set => SetAt(0x290, value); }
        public float Timeline_0_Rotation5_20C9DFBB425966866549FB82B24BDCB6 { get => GetAt<float>(0x294); set => SetAt(0x294, value); }
        public float Timeline_0_Rotation4_20C9DFBB425966866549FB82B24BDCB6 { get => GetAt<float>(0x298); set => SetAt(0x298, value); }
        public float Timeline_0_Rotation3_20C9DFBB425966866549FB82B24BDCB6 { get => GetAt<float>(0x29C); set => SetAt(0x29C, value); }
        public float Timeline_0_Rotation2_20C9DFBB425966866549FB82B24BDCB6 { get => GetAt<float>(0x2A0); set => SetAt(0x2A0, value); }
        public float Timeline_0_Rotation1_Bottom_20C9DFBB425966866549FB82B24BDCB6 { get => GetAt<float>(0x2A4); set => SetAt(0x2A4, value); }
        public float Timeline_0_Motion10_Top_20C9DFBB425966866549FB82B24BDCB6 { get => GetAt<float>(0x2A8); set => SetAt(0x2A8, value); }
        public float Timeline_0_Motion9_20C9DFBB425966866549FB82B24BDCB6 { get => GetAt<float>(0x2AC); set => SetAt(0x2AC, value); }
        public float Timeline_0_Motion8_20C9DFBB425966866549FB82B24BDCB6 { get => GetAt<float>(0x2B0); set => SetAt(0x2B0, value); }
        public float Timeline_0_Motion7_20C9DFBB425966866549FB82B24BDCB6 { get => GetAt<float>(0x2B4); set => SetAt(0x2B4, value); }
        public float Timeline_0_Motion6_20C9DFBB425966866549FB82B24BDCB6 { get => GetAt<float>(0x2B8); set => SetAt(0x2B8, value); }
        public float Timeline_0_Motion5_20C9DFBB425966866549FB82B24BDCB6 { get => GetAt<float>(0x2BC); set => SetAt(0x2BC, value); }
        public float Timeline_0_Motion4_20C9DFBB425966866549FB82B24BDCB6 { get => GetAt<float>(0x2C0); set => SetAt(0x2C0, value); }
        public float Timeline_0_Motion3_20C9DFBB425966866549FB82B24BDCB6 { get => GetAt<float>(0x2C4); set => SetAt(0x2C4, value); }
        public float Timeline_0_Motion2_20C9DFBB425966866549FB82B24BDCB6 { get => GetAt<float>(0x2C8); set => SetAt(0x2C8, value); }
        public float Timeline_0_Motion1_Bottom_20C9DFBB425966866549FB82B24BDCB6 { get => GetAt<float>(0x2CC); set => SetAt(0x2CC, value); }
        public byte Timeline_0__Direction_20C9DFBB425966866549FB82B24BDCB6 { get => GetAt<byte>(0x2D0); set => SetAt(0x2D0, value); }
        public TimelineComponent Timeline { get { var __p = GetAt<global::System.IntPtr>(0x2D8); return __p==global::System.IntPtr.Zero?null:new TimelineComponent(__p); } set => SetAt(0x2D8, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TArray<global::System.IntPtr> MotionArray => new TArray<global::System.IntPtr>(AddrOf(0x2E0)); // TArray<float>
        public TArray<global::System.IntPtr> RotationArray => new TArray<global::System.IntPtr>(AddrOf(0x2F0)); // TArray<float>
        public TArray<global::System.IntPtr> MeshArray => new TArray<global::System.IntPtr>(AddrOf(0x300)); // TArray<UObject*>
        public bool IsOpening { get => Native.GetPropBool(Pointer, "IsOpening"); set => Native.SetPropBool(Pointer, "IsOpening", value); }
        public bool IsOpen { get => Native.GetPropBool(Pointer, "IsOpen"); set => Native.SetPropBool(Pointer, "IsOpen", value); }
        public global::System.IntPtr OnAnimationDone => AddrOf(0x318); // 
        public bool IsAnimating { get => Native.GetPropBool(Pointer, "IsAnimating"); set => Native.SetPropBool(Pointer, "IsAnimating", value); }
        public void AnimationDone()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("AnimationDone", __pb.Bytes);
        }
        public void Timeline_0__FinishedFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_0__FinishedFunc", __pb.Bytes);
        }
        public void Timeline_0__UpdateFunc()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Timeline_0__UpdateFunc", __pb.Bytes);
        }
        public void AnimateCover_Open()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("AnimateCover_Open", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void AnimateCover_Closed()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("AnimateCover_Closed", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_MerchantScreen_Cover_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_MerchantScreen_Cover_BP", __pb.Bytes);
        }
        public void OnAnimationDone__DelegateSignature(bool Open)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Open?1:0));
            CallRaw("OnAnimationDone__DelegateSignature", __pb.Bytes);
        }
    }

}
