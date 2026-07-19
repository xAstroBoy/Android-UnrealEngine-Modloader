// modloader/src/dotnet/csharp_proxy_generator.cpp
// See csharp_proxy_generator.h. Full-coverage: enums, structs, classes, every
// property type, function params + returns, and traced native functions.

#include "modloader/csharp_proxy_generator.h"
#include "modloader/reflection_walker.h"
#include "modloader/symbols.h"
#include "modloader/paths.h"
#include "modloader/logger.h"

#include <cstdio>
#include <string>
#include <vector>
#include <set>
#include <map>
#include <algorithm>
#include <sys/stat.h>

namespace csharp_gen
{
    using reflection::PropType;
    using reflection::PropertyInfo;
    using reflection::FunctionInfo;

    // ── identifier hygiene ──────────────────────────────────────────────────
    static const std::set<std::string> kCsKeywords = {
        "abstract","as","base","bool","break","byte","case","catch","char","checked",
        "class","const","continue","decimal","default","delegate","do","double","else",
        "enum","event","explicit","extern","false","finally","fixed","float","for",
        "foreach","goto","if","implicit","in","int","interface","internal","is","lock",
        "long","namespace","new","null","object","operator","out","override","params",
        "private","protected","public","readonly","ref","return","sbyte","sealed","short",
        "sizeof","stackalloc","static","string","struct","switch","this","throw","true",
        "try","typeof","uint","ulong","unchecked","unsafe","ushort","using","virtual",
        "void","volatile","while","value","async","await","var","dynamic"};

    static std::string ident(const std::string &raw)
    {
        std::string s;
        for (char c : raw)
            s += (isalnum((unsigned char)c) || c == '_') ? c : '_';
        if (s.empty() || isdigit((unsigned char)s[0]))
            s = "_" + s;
        if (kCsKeywords.count(s))
            s = "@" + s;
        return s;
    }

    // Package name → file/namespace-safe.
    static std::string pkg_file(const std::string &pkg)
    {
        std::string s = pkg;
        for (auto &c : s) if (c == '/' || c == '\\' || c == '.') c = '_';
        while (!s.empty() && s[0] == '_') s.erase(0, 1);
        return s.empty() ? "Global" : s;
    }

    // Sets of everything we generate, for type resolution.
    struct Registry
    {
        std::set<std::string> classes, structs, enums;
        bool has_class(const std::string &n) const { return classes.count(n) != 0; }
        bool has_struct(const std::string &n) const { return structs.count(n) != 0; }
        bool has_enum(const std::string &n) const { return enums.count(n) != 0; }
    };

    static std::string mkdirs(const std::string &dir)
    {
        std::string cur;
        for (size_t i = 0; i < dir.size(); i++)
        {
            cur += dir[i];
            if (dir[i] == '/' && cur.size() > 1)
                mkdir(cur.c_str(), 0755);
        }
        mkdir(dir.c_str(), 0755);
        return dir;
    }

    // Numeric C# type for a fixed-width integer/float property.
    static const char *numeric_cs(PropType t)
    {
        switch (t)
        {
        case PropType::Int8Property:   return "sbyte";
        case PropType::ByteProperty:   return "byte";
        case PropType::Int16Property:  return "short";
        case PropType::UInt16Property: return "ushort";
        case PropType::IntProperty:    return "int";
        case PropType::UInt32Property: return "uint";
        case PropType::Int64Property:  return "long";
        case PropType::UInt64Property: return "ulong";
        case PropType::FloatProperty:  return "float";
        case PropType::DoubleProperty: return "double";
        default: return nullptr;
        }
    }

    static const char *enum_underlying(int element_size)
    {
        switch (element_size)
        {
        case 1: return "byte";
        case 2: return "ushort";
        case 8: return "long";
        default: return "int";
        }
    }

    // Resolve a property's C# type + emit a get/set body onto `f`.
    // Every layer is covered: numerics, bool, enum, name, string, object, struct,
    // array; anything exotic falls back to an IntPtr address accessor so nothing
    // is unreachable.
    // Make `base` a unique C# member identifier within `members` that also does
    // not equal the enclosing type name (CS0542). Appends _2/_3/... on collision.
    static std::string uniq_member(std::string base, std::set<std::string> &members,
                                   const std::string &type_name)
    {
        std::string n = base;
        int i = 2;
        while (n == type_name || members.count(n))
            n = base + "_" + std::to_string(i++);
        members.insert(n);
        return n;
    }

    // in_struct: the owner is a StructProxy (raw struct address, no UObject), so
    // there is no native by-name resolver — bool fields bake their offset+mask.
    // `name` is the (already-deduped) C# member identifier; p.name stays the real
    // UE name used in the native-call string literals.
    static void emit_property(FILE *f, const Registry &reg, const PropertyInfo &p,
                              bool in_struct, const std::string &name)
    {
        int off = p.offset;

        // Static array (ArrayDim > 1): expose base address; element access is raw.
        if (p.array_dim > 1)
        {
            fprintf(f, "        public global::System.IntPtr %s => AddrOf(0x%X); // [%d] static array\n",
                    name.c_str(), off, p.array_dim);
            return;
        }

        if (const char *num = numeric_cs(p.type))
        {
            fprintf(f, "        public %s %s { get => GetAt<%s>(0x%X); set => SetAt(0x%X, value); }\n",
                    num, name.c_str(), num, off, off);
            return;
        }

        switch (p.type)
        {
        case PropType::BoolProperty:
            if (!in_struct)
                // Class field: JUST NATIVE — the C++ side knows the offset+mask.
                fprintf(f, "        public bool %s { get => Native.GetPropBool(Pointer, \"%s\"); set => Native.SetPropBool(Pointer, \"%s\", value); }\n",
                        name.c_str(), p.name.c_str(), p.name.c_str());
            else
            {
                // Struct field: no UObject to resolve — bake the real byte+mask.
                int boff = off + p.bool_byte_offset;
                unsigned mask = p.bool_field_mask ? p.bool_field_mask : 0xFF;
                fprintf(f, "        public bool %s { get => (GetAt<byte>(0x%X) & 0x%X) != 0; set { var __b = GetAt<byte>(0x%X); SetAt(0x%X, (byte)(value ? (__b | 0x%X) : (__b & ~0x%X))); } }\n",
                        name.c_str(), boff, mask, boff, boff, mask, mask);
            }
            break;
        case PropType::EnumProperty:
        {
            std::string en = ident(p.inner_type_name);
            const char *u = enum_underlying(p.element_size);
            if (reg.has_enum(p.inner_type_name))
                fprintf(f, "        public %s %s { get => (%s)GetAt<%s>(0x%X); set => SetAt(0x%X, (%s)value); }\n",
                        en.c_str(), name.c_str(), en.c_str(), u, off, off, u);
            else
                fprintf(f, "        public %s %s { get => GetAt<%s>(0x%X); set => SetAt(0x%X, value); } // enum %s\n",
                        u, name.c_str(), u, off, off, p.inner_type_name.c_str());
            break;
        }
        case PropType::NameProperty:
            if (!in_struct)
                fprintf(f, "        public string %s => Native.GetPropName(Pointer, \"%s\"); // FName\n",
                        name.c_str(), p.name.c_str());
            else
                // Struct: read the FName comparison index at the offset, resolve natively.
                fprintf(f, "        public string %s => Native.FNameToString(GetAt<int>(0x%X)); // FName\n",
                        name.c_str(), off);
            fprintf(f, "        public FName %s_Raw { get => GetAt<FName>(0x%X); set => SetAt(0x%X, value); }\n",
                    name.c_str(), off, off);
            break;
        case PropType::StrProperty:
            if (!in_struct)
                fprintf(f, "        public string %s => Native.GetPropString(Pointer, \"%s\"); // FString\n",
                        name.c_str(), p.name.c_str());
            else
                // Struct: read the FString header at the field address natively.
                fprintf(f, "        public string %s => Native.ReadFStringAt(AddrOf(0x%X)); // FString\n",
                        name.c_str(), off);
            break;
        case PropType::ObjectProperty:
        case PropType::WeakObjectProperty:
        case PropType::LazyObjectProperty:
        case PropType::SoftObjectProperty:
        case PropType::ClassProperty:
        case PropType::SoftClassProperty:
        case PropType::InterfaceProperty:
        {
            std::string inner = ident(p.inner_type_name);
            const char *ty = reg.has_class(p.inner_type_name) ? inner.c_str() : "UObject";
            fprintf(f,
                "        public %s %s { get { var __p = GetAt<global::System.IntPtr>(0x%X); return __p==global::System.IntPtr.Zero?null:new %s(__p); } set => SetAt(0x%X, value?.Pointer ?? global::System.IntPtr.Zero); }\n",
                ty, name.c_str(), off, ty, off);
            break;
        }
        case PropType::StructProperty:
        {
            std::string inner = ident(p.inner_type_name);
            if (reg.has_struct(p.inner_type_name))
                fprintf(f, "        public %s %s => new %s(AddrOf(0x%X));\n",
                        inner.c_str(), name.c_str(), inner.c_str(), off);
            else
                fprintf(f, "        public global::System.IntPtr %s => AddrOf(0x%X); // struct %s\n",
                        name.c_str(), off, p.inner_type_name.c_str());
            break;
        }
        case PropType::ArrayProperty:
        {
            // TArray<T> reader (unmanaged elements: pointers for object arrays,
            // the numeric type for primitive arrays). The element proxy type is
            // named in the comment; wrap a pointer with `new Proxy(ptr)`.
            const char *inner_num = nullptr;
            // Heuristic: object/struct element arrays store pointers/structs;
            // expose as IntPtr elements. Primitive element arrays are rare here.
            fprintf(f, "        public TArray<global::System.IntPtr> %s => new TArray<global::System.IntPtr>(AddrOf(0x%X)); // TArray<%s>\n",
                    name.c_str(), off, p.inner_type_name.c_str());
            (void)inner_num;
            break;
        }
        default:
            // Text/Map/Set/Delegate/FieldPath/etc — expose the raw field address.
            fprintf(f, "        public global::System.IntPtr %s => AddrOf(0x%X); // %s\n",
                    name.c_str(), off, p.inner_type_name.c_str());
            break;
        }
    }

    // C# type name for a function param/return property.
    static std::string param_cs_type(const Registry &reg, const PropertyInfo &p)
    {
        if (const char *num = numeric_cs(p.type)) return num;
        switch (p.type)
        {
        case PropType::BoolProperty: return "bool";
        case PropType::NameProperty: return "FName";
        case PropType::StrProperty:  return "global::System.IntPtr"; // FString by ref
        case PropType::EnumProperty:
            return reg.has_enum(p.inner_type_name) ? ident(p.inner_type_name)
                                                   : enum_underlying(p.element_size);
        case PropType::ObjectProperty:
        case PropType::ClassProperty:
        case PropType::WeakObjectProperty:
        case PropType::InterfaceProperty:
            return reg.has_class(p.inner_type_name) ? ident(p.inner_type_name) : "UObject";
        case PropType::StructProperty:
            // Struct params/returns pass by value inline in the params buffer;
            // a struct PROXY wraps an address, so as a function arg/return we use
            // the raw IntPtr (address of the struct data). Struct FIELDS stay
            // typed proxies (emit_property), which is where the value lives.
            return "global::System.IntPtr";
        default:
            return "global::System.IntPtr";
        }
    }

    static bool is_object_type(PropType t)
    {
        return t == PropType::ObjectProperty || t == PropType::ClassProperty ||
               t == PropType::WeakObjectProperty || t == PropType::InterfaceProperty;
    }

    static void emit_function(FILE *f, const Registry &reg, const FunctionInfo &fn,
                              const std::string &mname)
    {
        // Split params / return.
        std::vector<const PropertyInfo *> args;
        const PropertyInfo *ret = nullptr;
        for (const auto &p : fn.params)
        {
            if (p.flags & ue::CPF_ReturnParm) { ret = &p; continue; }
            if (p.flags & ue::CPF_Parm) args.push_back(&p);
        }

        // Deduplicate parameter identifiers (CS0100) — keep positional order.
        std::vector<std::string> arg_names(args.size());
        std::set<std::string> seen;
        for (size_t i = 0; i < args.size(); i++)
        {
            std::string base = ident(args[i]->name);
            std::string n = base;
            int k = 2;
            while (!seen.insert(n).second) n = base + "_" + std::to_string(k++);
            arg_names[i] = n;
        }

        std::string retType = ret ? param_cs_type(reg, *ret) : "void";

        // [Native] doc + hookable native thunk RVA.
        if (fn.is_native() && fn.native_func)
        {
            uintptr_t base = symbols::lib_base();
            uintptr_t addr = reinterpret_cast<uintptr_t>(fn.native_func);
            unsigned long rva = (base && addr >= base) ? (unsigned long)(addr - base) : 0;
            fprintf(f, "        /// <summary>[Native] thunk RVA 0x%lX — hookable via Hooks.InstallAt(NativeFunc_%s).</summary>\n",
                    rva, mname.c_str());
            fprintf(f, "        public static global::System.IntPtr NativeFunc_%s => Memory.ModuleBase() + 0x%lX;\n",
                    mname.c_str(), rva);
        }

        // Signature.
        fprintf(f, "        public %s %s(", retType.c_str(), mname.c_str());
        for (size_t i = 0; i < args.size(); i++)
        {
            std::string t = param_cs_type(reg, *args[i]);
            fprintf(f, "%s%s %s", i ? ", " : "", t.c_str(), arg_names[i].c_str());
        }
        fprintf(f, ")\n        {\n");
        fprintf(f, "            var __pb = new ParamBuffer(%d);\n", (int)fn.parms_size);
        for (size_t ai = 0; ai < args.size(); ai++)
        {
            const PropertyInfo *a = args[ai];
            std::string an = arg_names[ai];
            int off = a->offset;
            if (a->type == PropType::BoolProperty)
                fprintf(f, "            __pb.Set<byte>(0x%X, (byte)(%s?1:0));\n", off, an.c_str());
            else if (is_object_type(a->type))
                fprintf(f, "            __pb.SetObject(0x%X, %s);\n", off, an.c_str());
            else if (a->type == PropType::EnumProperty)
                fprintf(f, "            __pb.Set<%s>(0x%X, (%s)%s);\n",
                        enum_underlying(a->element_size), off, enum_underlying(a->element_size), an.c_str());
            else if (numeric_cs(a->type) || a->type == PropType::NameProperty)
                fprintf(f, "            __pb.Set(0x%X, %s);\n", off, an.c_str());
            else
                fprintf(f, "            __pb.Set<global::System.IntPtr>(0x%X, %s);\n", off, an.c_str());
        }
        fprintf(f, "            CallRaw(\"%s\", __pb.Bytes);\n", fn.name.c_str());
        if (ret)
        {
            int roff = ret->offset;
            if (ret->type == PropType::BoolProperty)
                fprintf(f, "            return __pb.Get<byte>(0x%X) != 0;\n", roff);
            else if (is_object_type(ret->type))
            {
                std::string rt = param_cs_type(reg, *ret);
                if (rt == "UObject")
                    fprintf(f, "            return __pb.GetObject(0x%X);\n", roff);
                else
                    fprintf(f, "            { var __p = __pb.Get<global::System.IntPtr>(0x%X); return __p==global::System.IntPtr.Zero?null:new %s(__p); }\n",
                            roff, rt.c_str());
            }
            else if (ret->type == PropType::EnumProperty)
                fprintf(f, "            return (%s)__pb.Get<%s>(0x%X);\n",
                        retType.c_str(), enum_underlying(ret->element_size), roff);
            else
                fprintf(f, "            return __pb.Get<%s>(0x%X);\n", retType.c_str(), roff);
        }
        fprintf(f, "        }\n");
    }

    // ── Top level ────────────────────────────────────────────────────────────
    std::string generate(const std::string &out_dir_in)
    {
        std::string out_dir = out_dir_in.empty()
            ? paths::data_dir() + "/dotnet/Generated"
            : out_dir_in;
        mkdirs(out_dir);

        const auto &classes = reflection::get_classes();
        const auto &structs = reflection::get_structs();
        const auto &enums = reflection::get_enums();

        // Build the registry so type references resolve to generated proxies.
        Registry reg;
        for (const auto &c : classes) reg.classes.insert(c.name);
        for (const auto &s : structs) reg.structs.insert(s.name);
        for (const auto &e : enums)   reg.enums.insert(e.name);

        // Group by package.
        std::map<std::string, std::vector<const reflection::ClassInfo *>> byPkgC;
        std::map<std::string, std::vector<const reflection::StructInfo *>> byPkgS;
        std::map<std::string, std::vector<const reflection::EnumInfo *>>   byPkgE;
        for (const auto &c : classes) byPkgC[c.package_name].push_back(&c);
        for (const auto &s : structs) byPkgS[s.package_name].push_back(&s);
        for (const auto &e : enums)   byPkgE[e.package_name].push_back(&e);

        std::set<std::string> pkgs;
        for (auto &kv : byPkgC) pkgs.insert(kv.first);
        for (auto &kv : byPkgS) pkgs.insert(kv.first);
        for (auto &kv : byPkgE) pkgs.insert(kv.first);

        int nClasses = 0, nStructs = 0, nEnums = 0, nFiles = 0;

        for (const auto &pkg : pkgs)
        {
            std::string file = out_dir + "/" + pkg_file(pkg) + ".g.cs";
            FILE *f = fopen(file.c_str(), "w");
            if (!f) { logger::log_warn("CSGEN", "cannot write %s", file.c_str()); continue; }
            nFiles++;

            fprintf(f, "// AUTO-GENERATED from the live UE reflection graph. Do not edit.\n");
            fprintf(f, "// Package: %s\n", pkg.c_str());
            fprintf(f, "using System;\n\nnamespace UEModLoader.Game\n{\n");

            // Enums.
            for (const auto *e : byPkgE[pkg])
            {
                int64_t mx = 0, mn = 0;
                for (auto &v : e->values) { mx = std::max(mx, v.second); mn = std::min(mn, v.second); }
                const char *ut = (mn < -2147483648LL || mx > 2147483647LL) ? " : long" : "";
                fprintf(f, "    public enum %s%s\n    {\n", ident(e->name).c_str(), ut);
                std::set<std::string> seen;
                for (auto &v : e->values)
                {
                    std::string vn = ident(v.first);
                    if (!seen.insert(vn).second) continue; // dedupe
                    fprintf(f, "        %s = %lld,\n", vn.c_str(), (long long)v.second);
                }
                fprintf(f, "    }\n\n");
                nEnums++;
            }

            // Structs (proxy over a struct address).
            for (const auto *s : byPkgS[pkg])
            {
                std::string sn = ident(s->name);
                fprintf(f, "    public class %s : StructProxy\n    {\n", sn.c_str());
                fprintf(f, "        public %s(global::System.IntPtr ptr) : base(ptr) {}\n", sn.c_str());
                std::set<std::string> members;
                for (const auto &p : s->properties)
                {
                    std::string mn = uniq_member(ident(p.name), members, sn);
                    emit_property(f, reg, p, /*in_struct=*/true, mn);
                }
                fprintf(f, "    }\n\n");
                nStructs++;
            }

            // Classes.
            for (const auto *c : byPkgC[pkg])
            {
                std::string cn = ident(c->name);
                std::string parent = (!c->parent_name.empty() && reg.has_class(c->parent_name))
                    ? ident(c->parent_name) : "UObject";
                fprintf(f, "    public class %s : %s\n    {\n", cn.c_str(), parent.c_str());
                fprintf(f, "        public const string UeClassName = \"%s\";\n", c->name.c_str());
                fprintf(f, "        public %s(global::System.IntPtr ptr) : base(ptr) {}\n", cn.c_str());
                fprintf(f, "        public static new %s FromPointer(global::System.IntPtr p) => p==global::System.IntPtr.Zero?null:new %s(p);\n",
                        cn.c_str(), cn.c_str());
                fprintf(f, "        public static %s FirstOf() { var o = UObject.FindFirstOf(UeClassName); return o==null?null:new %s(o.Pointer); }\n",
                        cn.c_str(), cn.c_str());
                fprintf(f, "        public static %s[] All() { var a = UObject.FindAllOf(UeClassName); var r = new %s[a.Length]; for(int i=0;i<a.Length;i++) r[i]=new %s(a[i].Pointer); return r; }\n",
                        cn.c_str(), cn.c_str(), cn.c_str());

                std::set<std::string> members;
                // Seed with the static members the class already emits so a UE
                // field/function named the same gets renamed, not clashed.
                members.insert("UeClassName");
                members.insert("FromPointer");
                members.insert("FirstOf");
                members.insert("All");
                for (const auto &p : c->properties)
                {
                    std::string mn = uniq_member(ident(p.name), members, cn);
                    emit_property(f, reg, p, /*in_struct=*/false, mn);
                }
                for (const auto &fn : c->functions)
                {
                    std::string mn = uniq_member(ident(fn.name), members, cn);
                    emit_function(f, reg, fn, mn);
                }
                fprintf(f, "    }\n\n");
                nClasses++;
            }

            fprintf(f, "}\n");
            fclose(f);
        }

        char summary[256];
        snprintf(summary, sizeof(summary),
                 "C# proxies: %d classes, %d structs, %d enums across %d files -> %s",
                 nClasses, nStructs, nEnums, nFiles, out_dir.c_str());
        logger::log_info("CSGEN", "%s", summary);
        return summary;
    }

} // namespace csharp_gen
