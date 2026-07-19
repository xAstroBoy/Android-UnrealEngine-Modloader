// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Game/Blueprints/Characters/Vehicles/JetSki_Interface
using System;

namespace UEModLoader.Game
{
    public class JetSki_Interface_C : Interface
    {
        public const string UeClassName = "JetSki_Interface_C";
        public JetSki_Interface_C(System.IntPtr ptr) : base(ptr) {}
        public static new JetSki_Interface_C FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new JetSki_Interface_C(p);
        public static JetSki_Interface_C FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new JetSki_Interface_C(o.Pointer); }
        public static JetSki_Interface_C[] All() { var a = UObject.FindAllOf(UeClassName); var r = new JetSki_Interface_C[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new JetSki_Interface_C(a[i].Pointer); return r; }
        public void GetJetSkiActive(bool JetSkiActive)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(JetSkiActive?1:0));
            CallRaw("GetJetSkiActive", __pb.Bytes);
        }
        public void SetJetSkiActive(bool Callback)
        {
            var __pb = new ParamBuffer(1);
            __pb.Set<byte>(0x0, (byte)(Callback?1:0));
            CallRaw("SetJetSkiActive", __pb.Bytes);
        }
    }

}
