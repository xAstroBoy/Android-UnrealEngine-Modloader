// AUTO-GENERATED from the live UE reflection graph. Do not edit.
// Package: /Script/JsonUtilities
using System;

namespace UEModLoader.Game
{
    public class JsonObjectWrapper : StructProxy
    {
        public JsonObjectWrapper(System.IntPtr ptr) : base(ptr) {}
        public string JsonString => Native.ReadFStringAt(AddrOf(0x0)); // FString
    }

    public class JsonUtilitiesDummyObject : Object
    {
        public const string UeClassName = "JsonUtilitiesDummyObject";
        public JsonUtilitiesDummyObject(System.IntPtr ptr) : base(ptr) {}
        public static new JsonUtilitiesDummyObject FromPointer(System.IntPtr p) => p==System.IntPtr.Zero?null:new JsonUtilitiesDummyObject(p);
        public static JsonUtilitiesDummyObject FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new JsonUtilitiesDummyObject(o.Pointer); }
        public static JsonUtilitiesDummyObject[] All() { var a = UObject.FindAllOf(UeClassName); var r = new JsonUtilitiesDummyObject[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new JsonUtilitiesDummyObject(a[i].Pointer); return r; }
    }

}
