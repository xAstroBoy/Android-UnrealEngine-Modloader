// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/UI/VR4/Menus/PauseMenu/UI_PauseMenu_Content_BP
using System;

namespace UEModLoader.Game
{
    public class UI_PauseMenu_Content_BP_C : Actor
    {
        public const string UeClassName = "UI_PauseMenu_Content_BP_C";
        public UI_PauseMenu_Content_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new UI_PauseMenu_Content_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new UI_PauseMenu_Content_BP_C(p);
        public static UI_PauseMenu_Content_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new UI_PauseMenu_Content_BP_C(o.Pointer); }
        public static UI_PauseMenu_Content_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new UI_PauseMenu_Content_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new UI_PauseMenu_Content_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x220));
        public SceneComponent PanelParent { get { var __p = GetAt<global::System.IntPtr>(0x228); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x228, value?.Pointer ?? global::System.IntPtr.Zero); }
        public SceneComponent DefaultSceneRoot { get { var __p = GetAt<global::System.IntPtr>(0x230); return __p==global::System.IntPtr.Zero?null:new SceneComponent(__p); } set => SetAt(0x230, value?.Pointer ?? global::System.IntPtr.Zero); }
        public EItemId ItemId { get => (EItemId)GetAt<byte>(0x238); set => SetAt(0x238, (byte)value); }
        public VR4PauseMenuStartInfo PauseStartInfo => new VR4PauseMenuStartInfo(AddrOf(0x239));
        public EUISound IntroSound { get => (EUISound)GetAt<byte>(0x23B); set => SetAt(0x23B, (byte)value); }
        public EUISound OutroSound { get => (EUISound)GetAt<byte>(0x23C); set => SetAt(0x23C, (byte)value); }
        public bool FirstTimeTutorial { get => Native.GetPropBool(Pointer, "FirstTimeTutorial"); set => Native.SetPropBool(Pointer, "FirstTimeTutorial", value); }
        public EUISound OutroFinish { get => (EUISound)GetAt<byte>(0x23E); set => SetAt(0x23E, (byte)value); }
        public void TitleBackButtonPressed()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("TitleBackButtonPressed", __pb.Bytes);
        }
        public void IntSetTitleText(global::System.IntPtr TitleText, bool ShowButton)
        {
            var __pb = new ParamBuffer(25);
            __pb.Set<global::System.IntPtr>(0x0, TitleText);
            __pb.Set<byte>(0x18, (byte)(ShowButton?1:0));
            CallRaw("IntSetTitleText", __pb.Bytes);
        }
        public void IntSetLinkTransition(FName LinkTransition)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, LinkTransition);
            CallRaw("IntSetLinkTransition", __pb.Bytes);
        }
        public void IntGetLinkTransition(FName LinkTransition)
        {
            var __pb = new ParamBuffer(8);
            __pb.Set(0x0, LinkTransition);
            CallRaw("IntGetLinkTransition", __pb.Bytes);
        }
        public void IntLoadGame(int saveSlot)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, saveSlot);
            CallRaw("IntLoadGame", __pb.Bytes);
        }
        public void IntGetLoadGameManager(TypewriterManager_Load_BP_C LoadGameManager)
        {
            var __pb = new ParamBuffer(8);
            __pb.SetObject(0x0, LoadGameManager);
            CallRaw("IntGetLoadGameManager", __pb.Bytes);
        }
        public void IntGetMenuType(bool InGame, bool Mercenaries)
        {
            var __pb = new ParamBuffer(2);
            __pb.Set<byte>(0x0, (byte)(InGame?1:0));
            __pb.Set<byte>(0x1, (byte)(Mercenaries?1:0));
            CallRaw("IntGetMenuType", __pb.Bytes);
        }
        public void IntPopToUIScreen()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("IntPopToUIScreen", __pb.Bytes);
        }
        public void IntSetMenuSwapping(bool MenuSwapping)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(MenuSwapping?1:0));
            CallRaw("IntSetMenuSwapping", __pb.Bytes);
        }
        public void IntSubActionEventStart()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("IntSubActionEventStart", __pb.Bytes);
        }
        public void IntContentExitDone()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("IntContentExitDone", __pb.Bytes);
        }
        public void IntContentEnterDone()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("IntContentEnterDone", __pb.Bytes);
        }
        public void ResetStartInfo()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ResetStartInfo", __pb.Bytes);
        }
        public void PlayOutro()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PlayOutro", __pb.Bytes);
        }
        public void HideContent()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("HideContent", __pb.Bytes);
        }
        public void SubAction_A()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SubAction_A", __pb.Bytes);
        }
        public void SubAction_B()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SubAction_B", __pb.Bytes);
        }
        public void PlayIntro()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PlayIntro", __pb.Bytes);
        }
        public void PlayBasicOpen()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PlayBasicOpen", __pb.Bytes);
        }
        public void PlayBasicClose()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("PlayBasicClose", __pb.Bytes);
        }
        public void SkipIntro()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("SkipIntro", __pb.Bytes);
        }
        public void ContinueOpen()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ContinueOpen", __pb.Bytes);
        }
        public void ReceiveEndPlay(byte EndPlayReason)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set(0x0, EndPlayReason);
            CallRaw("ReceiveEndPlay", __pb.Bytes);
        }
        public void ExecuteUbergraph_UI_PauseMenu_Content_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_UI_PauseMenu_Content_BP", __pb.Bytes);
        }
    }

}
