// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Player/Game/Props/Ammo/VR4GamePlayerAmmo_ShotgunShell_Base_BP
using System;

namespace UEModLoader.Game
{
    public class VR4GamePlayerAmmo_ShotgunShell_Base_BP_C : VR4GamePlayerAmmo_Clustered_Base_BP_C
    {
        public const string UeClassName = "VR4GamePlayerAmmo_ShotgunShell_Base_BP_C";
        public VR4GamePlayerAmmo_ShotgunShell_Base_BP_C(global::System.IntPtr ptr) : base(ptr) {}
        public static new VR4GamePlayerAmmo_ShotgunShell_Base_BP_C FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new VR4GamePlayerAmmo_ShotgunShell_Base_BP_C(p);
        public static VR4GamePlayerAmmo_ShotgunShell_Base_BP_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new VR4GamePlayerAmmo_ShotgunShell_Base_BP_C(o.Pointer); }
        public static VR4GamePlayerAmmo_ShotgunShell_Base_BP_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new VR4GamePlayerAmmo_ShotgunShell_Base_BP_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new VR4GamePlayerAmmo_ShotgunShell_Base_BP_C(a[i].Pointer); return r; }
        public PointerToUberGraphFrame UberGraphFrame => new PointerToUberGraphFrame(AddrOf(0x710));
        public StaticMeshComponent Shell8 { get { var __p = GetAt<global::System.IntPtr>(0x718); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x718, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent Shell7 { get { var __p = GetAt<global::System.IntPtr>(0x720); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x720, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent Shell6 { get { var __p = GetAt<global::System.IntPtr>(0x728); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x728, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent Shell5 { get { var __p = GetAt<global::System.IntPtr>(0x730); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x730, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent Shell4 { get { var __p = GetAt<global::System.IntPtr>(0x738); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x738, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent Shell3 { get { var __p = GetAt<global::System.IntPtr>(0x740); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x740, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent Shell2 { get { var __p = GetAt<global::System.IntPtr>(0x748); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x748, value?.Pointer ?? global::System.IntPtr.Zero); }
        public StaticMeshComponent Shell1 { get { var __p = GetAt<global::System.IntPtr>(0x750); return __p==global::System.IntPtr.Zero?null:new StaticMeshComponent(__p); } set => SetAt(0x750, value?.Pointer ?? global::System.IntPtr.Zero); }
        public int VisibleHeldShells { get => GetAt<int>(0x758); set => SetAt(0x758, value); }
        public TArray<global::System.IntPtr> ClusterHandPoses => new TArray<global::System.IntPtr>(AddrOf(0x760)); // TArray<struct>
        public void GetClusterCount(bool Visible, bool holstered, bool pouchOpen, bool AmmoAvailable, bool loadingAidSpent, int reserves, int gunCapacity, int loadedAmmo, int totalAmmo, int Count)
        {
            var __pb = new ParamBuffer(28);
            __pb.Set<byte>(0x0, (byte)(Visible?1:0));
            __pb.Set<byte>(0x1, (byte)(holstered?1:0));
            __pb.Set<byte>(0x2, (byte)(pouchOpen?1:0));
            __pb.Set<byte>(0x3, (byte)(AmmoAvailable?1:0));
            __pb.Set<byte>(0x4, (byte)(loadingAidSpent?1:0));
            __pb.Set(0x8, reserves);
            __pb.Set(0xC, gunCapacity);
            __pb.Set(0x10, loadedAmmo);
            __pb.Set(0x14, totalAmmo);
            __pb.Set(0x18, Count);
            CallRaw("GetClusterCount", __pb.Bytes);
        }
        public void UpdateVisibility_Internal(bool Visible, bool holstered, bool held, bool pouchOpen, bool AmmoAvailable, bool loadingAidSpent, int reserves, int gunCapacity, int loadedAmmo, int totalAmmo, int reloadAnimIndex, EHandedness Handedness)
        {
            var __pb = new ParamBuffer(29);
            __pb.Set<byte>(0x0, (byte)(Visible?1:0));
            __pb.Set<byte>(0x1, (byte)(holstered?1:0));
            __pb.Set<byte>(0x2, (byte)(held?1:0));
            __pb.Set<byte>(0x3, (byte)(pouchOpen?1:0));
            __pb.Set<byte>(0x4, (byte)(AmmoAvailable?1:0));
            __pb.Set<byte>(0x5, (byte)(loadingAidSpent?1:0));
            __pb.Set(0x8, reserves);
            __pb.Set(0xC, gunCapacity);
            __pb.Set(0x10, loadedAmmo);
            __pb.Set(0x14, totalAmmo);
            __pb.Set(0x18, reloadAnimIndex);
            __pb.Set<byte>(0x1C, (byte)Handedness);
            CallRaw("UpdateVisibility_Internal", __pb.Bytes);
        }
        public void ReceiveBeginPlay()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("ReceiveBeginPlay", __pb.Bytes);
        }
        public void OnLoadedIntoGun()
        {
            var __pb = new ParamBuffer(0);
            CallRaw("OnLoadedIntoGun", __pb.Bytes);
        }
        public void ExecuteUbergraph_VR4GamePlayerAmmo_ShotgunShell_Base_BP(int EntryPoint)
        {
            var __pb = new ParamBuffer(4);
            __pb.Set(0x0, EntryPoint);
            CallRaw("ExecuteUbergraph_VR4GamePlayerAmmo_ShotgunShell_Base_BP", __pb.Bytes);
        }
    }

}
