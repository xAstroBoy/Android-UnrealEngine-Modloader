// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/UI/Typewriter/TypewriterManager_Load_BP
using System;

namespace UEModLoader.Game
{
    public class TypewriterManager_Load_BP_C : VR4SaveMenu
    {
        public const string UeClassName = "TypewriterManager_Load_BP_C";
        public TypewriterManager_Load_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new TypewriterManager_Load_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new TypewriterManager_Load_BP_C(p);
        public static TypewriterManager_Load_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new TypewriterManager_Load_BP_C(o.Pointer); }
        public static TypewriterManager_Load_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new TypewriterManager_Load_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new TypewriterManager_Load_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x248));
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<global::System.IntPtr>(0x250); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x250, value?.Pointer ?? global::System.IntPtr.Zero); }
        public EPlayerPawn StoredPawnType { get => (EPlayerPawn)GetAt<byte>(0x258); set => SetAt(0x258, (byte)value); }
        public bool DataReady { get => Native.GetPropBool(Pointer, "DataReady"); set => Native.SetPropBool(Pointer, "DataReady", value); }
        public global::System.IntPtr DataUpdated => AddrOf(0x260); // 
        public bool Debug { get => Native.GetPropBool(Pointer, "Debug"); set => Native.SetPropBool(Pointer, "Debug", value); }
        public global::System.IntPtr NewDataCreated => AddrOf(0x278); // 
        public Transform StoredPawnTransform => new Transform(AddrOf(0x290));
        public TArray<global::System.IntPtr> FogValues => new TArray<global::System.IntPtr>(AddrOf(0x2C0)); // TArray<struct>
        public TArray<global::System.IntPtr> MobileFogValues => new TArray<global::System.IntPtr>(AddrOf(0x2D0)); // TArray<struct>
        public global::System.IntPtr CommFog => AddrOf(0x2E0); // struct CommFog
        public global::System.IntPtr CommMobileFog => AddrOf(0x310); // struct CommMobileFog
        public TArray<global::System.IntPtr> FogActors => new TArray<global::System.IntPtr>(AddrOf(0x330)); // TArray<UObject*>
        public bool NotifyFrontEnd { get => Native.GetPropBool(Pointer, "NotifyFrontEnd"); set => Native.SetPropBool(Pointer, "NotifyFrontEnd", value); }
        public void LM_DoSavesExist(bool SavesExist)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(SavesExist?1:0));
            CallRaw("LM_DoSavesExist", __pb.Bytes);
        }
        public void LM_GetSlotInfo(global::System.IntPtr SaveSlotInfo)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<global::System.IntPtr>(0x0, SaveSlotInfo);
            CallRaw("LM_GetSlotInfo", __pb.Bytes);
        }
        public void LM_NotifySlotSelected(int saveSlot, bool isClearSaveSlot, bool Callback)
        {
            var __pb = new ParamBuffer(6);
            __pb.Set(0x0, saveSlot);
            __pb.Set<byte>(0x4, (byte)(isClearSaveSlot?1:0));
            __pb.Set<byte>(0x5, (byte)(Callback?1:0));
            CallRaw("LM_NotifySlotSelected", __pb.Bytes);
        }
        public void LM_NotifyCancel(bool Callback)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Callback?1:0));
            CallRaw("LM_NotifyCancel", __pb.Bytes);
        }
        public void LM_DataReady_(bool Ready)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Ready?1:0));
            CallRaw("LM_DataReady?", __pb.Bytes);
        }
        public void NotifyFrontendDataReady()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("NotifyFrontendDataReady", __pb.Bytes);
        }
        public void GameEndSaves(global::System.IntPtr Saves)
        {
            var __pb = new ParamBuffer(16);
            __pb.Set<global::System.IntPtr>(0x0, Saves);
            CallRaw("GameEndSaves", __pb.Bytes);
        }
        public void RestoreFog()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("RestoreFog", __pb.Bytes);
        }
        public void SetFog()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SetFog", __pb.Bytes);
        }
        public void RestoreOldPawn()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("RestoreOldPawn", __pb.Bytes);
        }
        public void StoreOldPawn()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("StoreOldPawn", __pb.Bytes);
        }
        public void OnSaveSlotInfosUpdated()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnSaveSlotInfosUpdated", __pb.Bytes);
        }
        public void OnMessageSet(FName messageKey)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, messageKey);
            CallRaw("OnMessageSet", __pb.Bytes);
        }
        public void OnConfirmationRequired(FName messageKey)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, messageKey);
            CallRaw("OnConfirmationRequired", __pb.Bytes);
        }
        public void ReceiveEndPlay(byte EndPlayReason)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, EndPlayReason);
            CallRaw("ReceiveEndPlay", __pb.Bytes);
        }
        public void OnNewSaveInfoCreated(global::System.IntPtr newSaveInfo)
        {
            var __pb = new ParamBuffer(64);
            __pb.Set<global::System.IntPtr>(0x0, newSaveInfo);
            CallRaw("OnNewSaveInfoCreated", __pb.Bytes);
        }
        public void OnSaveMenuEnd(ESaveAccessMode accessMode, bool wasCalledFromOptionMenu)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)accessMode);
            __pb.Set<byte>(0x1, (byte)(wasCalledFromOptionMenu?1:0));
            CallRaw("OnSaveMenuEnd", __pb.Bytes);
        }
        public void TypewriterComplete(int saveSlot)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, saveSlot);
            CallRaw("TypewriterComplete", __pb.Bytes);
        }
        public void OnNoSaveSlotsFound()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnNoSaveSlotsFound", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void ExecuteUbergraph_TypewriterManager_Load_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_TypewriterManager_Load_BP", __pb.Bytes);
        }
        public void NewDataCreated__DelegateSignature(global::System.IntPtr NewData)
        {
            var __pb = new ParamBuffer(64);
            __pb.Set<global::System.IntPtr>(0x0, NewData);
            CallRaw("NewDataCreated__DelegateSignature", __pb.Bytes);
        }
        public void DataUpdated__DelegateSignature()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("DataUpdated__DelegateSignature", __pb.Bytes);
        }
    }

}
