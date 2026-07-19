// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Tutorial/TutorialHelper
using System;

namespace UEModLoader.Game
{
    public class TutorialHelper_C : Actor
    {
        public const string UeClassName = "TutorialHelper_C";
        public TutorialHelper_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new TutorialHelper_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new TutorialHelper_C(p);
        public static TutorialHelper_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new TutorialHelper_C(o.Pointer); }
        public static TutorialHelper_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new TutorialHelper_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new TutorialHelper_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x220));
        public SceneComponent Root { get { var __p = GetAt<global::System.IntPtr>(0x228); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x228, value?.Pointer ?? global::System.IntPtr.Zero); }
        public string Tutorial => Native.GetPropName(Pointer, "Tutorial"); // FName
        public FName Tutorial_Raw { get => GetAt<FName>(0x230); set => SetAt(0x230, value); }
        public TArray<global::System.IntPtr> LabelAnchors => new TArray<global::System.IntPtr>(AddrOf(0x238)); // TArray<UObject*>
        public bool PreviouslyCompleted { get => Native.GetPropBool(Pointer, "PreviouslyCompleted"); set => Native.SetPropBool(Pointer, "PreviouslyCompleted", value); }
        public TutorialInstruction OpenTutorial { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new TutorialInstruction(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public Actor BindingActor { get { var __p = GetAt<global::System.IntPtr>(0x258); return __p==global::System.IntPtr.Zero?null:new Actor(__p); } set => SetAt(0x258, value?.Pointer ?? global::System.IntPtr.Zero); }
        public float DisplayTimeLimit { get => GetAt<float>(0x260); set => SetAt(0x260, value); }
        public global::System.IntPtr TimeLimitReached => AddrOf(0x268); // 
        public TArray<global::System.IntPtr> Headers => new TArray<global::System.IntPtr>(AddrOf(0x278)); // TArray<FText>
        public TArray<global::System.IntPtr> Labels => new TArray<global::System.IntPtr>(AddrOf(0x288)); // TArray<FText>
        public TArray<global::System.IntPtr> HeaderLabels => new TArray<global::System.IntPtr>(AddrOf(0x298)); // TArray<UObject*>
        public TArray<global::System.IntPtr> ScaleOverrides => new TArray<global::System.IntPtr>(AddrOf(0x2A8)); // TArray<float>
        public int AnchorCount { get => GetAt<int>(0x2B8); set => SetAt(0x2B8, value); }
        public global::System.IntPtr TutorialInfo => AddrOf(0x2C0); // struct TutorialEntry
        public global::System.IntPtr TutorialData => AddrOf(0x310); // struct TutorialEntry
        public global::System.IntPtr TutorialDisplayed => AddrOf(0x360); // 
        public TutorialHand_Base_BP_C LeftHand { get { var __p = GetAt<global::System.IntPtr>(0x370); return __p==global::System.IntPtr.Zero?null:new TutorialHand_Base_BP_C(__p); } set => SetAt(0x370, value?.Pointer ?? global::System.IntPtr.Zero); }
        public TutorialHand_Base_BP_C RightHand { get { var __p = GetAt<global::System.IntPtr>(0x378); return __p==global::System.IntPtr.Zero?null:new TutorialHand_Base_BP_C(__p); } set => SetAt(0x378, value?.Pointer ?? global::System.IntPtr.Zero); }
        public BP_DynamicTutorialManager_C ManagerBP { get { var __p = GetAt<global::System.IntPtr>(0x380); return __p==global::System.IntPtr.Zero?null:new BP_DynamicTutorialManager_C(__p); } set => SetAt(0x380, value?.Pointer ?? global::System.IntPtr.Zero); }
        public global::System.IntPtr HandsCreated => AddrOf(0x388); // 
        public bool ForceHandL { get => Native.GetPropBool(Pointer, "ForceHandL"); set => Native.SetPropBool(Pointer, "ForceHandL", value); }
        public bool ForceHandR { get => Native.GetPropBool(Pointer, "ForceHandR"); set => Native.SetPropBool(Pointer, "ForceHandR", value); }
        public string CompletionGroup => Native.GetPropString(Pointer, "CompletionGroup"); // FString
        public bool InstantOnAutocomplete { get => Native.GetPropBool(Pointer, "InstantOnAutocomplete"); set => Native.SetPropBool(Pointer, "InstantOnAutocomplete", value); }
        public int CompletionCount { get => GetAt<int>(0x3B4); set => SetAt(0x3B4, value); }
        public bool UseCompletionCount { get => Native.GetPropBool(Pointer, "UseCompletionCount"); set => Native.SetPropBool(Pointer, "UseCompletionCount", value); }
        public TArray<global::System.IntPtr> AdditionalLabels => new TArray<global::System.IntPtr>(AddrOf(0x3C0)); // TArray<FName>
        public BP_TutorialButtonLabel_Group_C GroupLabel { get { var __p = GetAt<global::System.IntPtr>(0x3D0); return __p==global::System.IntPtr.Zero?null:new BP_TutorialButtonLabel_Group_C(__p); } set => SetAt(0x3D0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool RemoveGroupLabelInstant { get => Native.GetPropBool(Pointer, "RemoveGroupLabelInstant"); set => Native.SetPropBool(Pointer, "RemoveGroupLabelInstant", value); }
        public TutorialHelperStatic_C TutorialButtonStatic { get { var __p = GetAt<global::System.IntPtr>(0x3E0); return __p==global::System.IntPtr.Zero?null:new TutorialHelperStatic_C(__p); } set => SetAt(0x3E0, value?.Pointer ?? global::System.IntPtr.Zero); }
        public bool GroupLabelCompleted { get => Native.GetPropBool(Pointer, "GroupLabelCompleted"); set => Native.SetPropBool(Pointer, "GroupLabelCompleted", value); }
        public bool CompleteOnTimeOut { get => Native.GetPropBool(Pointer, "CompleteOnTimeOut"); set => Native.SetPropBool(Pointer, "CompleteOnTimeOut", value); }
        public bool InstantComplete { get => Native.GetPropBool(Pointer, "InstantComplete"); set => Native.SetPropBool(Pointer, "InstantComplete", value); }
        public bool CompleteOnBindDestroy { get => Native.GetPropBool(Pointer, "CompleteOnBindDestroy"); set => Native.SetPropBool(Pointer, "CompleteOnBindDestroy", value); }
        public bool IgnorePlayerSetting { get => Native.GetPropBool(Pointer, "IgnorePlayerSetting"); set => Native.SetPropBool(Pointer, "IgnorePlayerSetting", value); }
        public void WorldDilationChanged(float WorldTimeDilation, float PlayerTimeDilation, float CustomTimeDilation)
        {
            var __pb = new ParamBuffer(12);
            __pb.Set(0x0, WorldTimeDilation);
            __pb.Set(0x4, PlayerTimeDilation);
            __pb.Set(0x8, CustomTimeDilation);
            CallRaw("WorldDilationChanged", __pb.Bytes);
        }
        public void Add_Labels()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("Add Labels", __pb.Bytes);
        }
        public void SpawnHand(EHandedness Hand)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)Hand);
            CallRaw("SpawnHand", __pb.Bytes);
        }
        public void TutorialComplete(bool Completed, bool instant)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)(Completed?1:0));
            __pb.Set<byte>(0x1, (byte)(instant?1:0));
            CallRaw("TutorialComplete", __pb.Bytes);
        }
        public void SpawnTutorial()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SpawnTutorial", __pb.Bytes);
        }
        public void GetDelay(float Delay)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, Delay);
            CallRaw("GetDelay", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void ShowTutorial()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ShowTutorial", __pb.Bytes);
        }
        public void ReceiveEndPlay(byte EndPlayReason)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, EndPlayReason);
            CallRaw("ReceiveEndPlay", __pb.Bytes);
        }
        public void BindingActorDestroyed(Actor DestroyedActor)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, DestroyedActor);
            CallRaw("BindingActorDestroyed", __pb.Bytes);
        }
        public void DisplayTimerExpired()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DisplayTimerExpired", __pb.Bytes);
        }
        public void TutorialShown(TutorialInstruction Tutorial)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, Tutorial);
            CallRaw("TutorialShown", __pb.Bytes);
        }
        public void GroupLabelShown()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("GroupLabelShown", __pb.Bytes);
        }
        public void DestroyStaticLabel(bool Completed)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Completed?1:0));
            CallRaw("DestroyStaticLabel", __pb.Bytes);
        }
        public void StaticDestroyed(Actor DestroyedActor)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, DestroyedActor);
            CallRaw("StaticDestroyed", __pb.Bytes);
        }
        public void ExecuteUbergraph_TutorialHelper(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_TutorialHelper", __pb.Bytes);
        }
        public void HandsCreated__DelegateSignature(TutorialHand_Base_BP_C LeftHand, TutorialHand_Base_BP_C RightHand)
        {
            var __pb = new ParamBuffer(16);
            __pb.SetObject(0x0, LeftHand);
            __pb.SetObject(0x8, RightHand);
            CallRaw("HandsCreated__DelegateSignature", __pb.Bytes);
        }
        public void TutorialDisplayed__DelegateSignature()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("TutorialDisplayed__DelegateSignature", __pb.Bytes);
        }
        public void TimeLimitReached__DelegateSignature()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("TimeLimitReached__DelegateSignature", __pb.Bytes);
        }
    }

}
