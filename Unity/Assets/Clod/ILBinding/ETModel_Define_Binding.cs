using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

using ILRuntime.CLR.TypeSystem;
using ILRuntime.CLR.Method;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;
using ILRuntime.Runtime.Stack;
using ILRuntime.Reflection;
using ILRuntime.CLR.Utils;

namespace ILRuntime.Runtime.Generated
{
    unsafe class ETModel_Define_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            FieldInfo field;
            Type[] args;
            Type type = typeof(ETModel.Define);

            field = type.GetField("IsILRuntime", flag);
            app.RegisterCLRFieldGetter(field, get_IsILRuntime_0);
            app.RegisterCLRFieldSetter(field, set_IsILRuntime_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_IsILRuntime_0, AssignFromStack_IsILRuntime_0);
            field = type.GetField("IsAsync", flag);
            app.RegisterCLRFieldGetter(field, get_IsAsync_1);
            app.RegisterCLRFieldSetter(field, set_IsAsync_1);
            app.RegisterCLRFieldBinding(field, CopyToStack_IsAsync_1, AssignFromStack_IsAsync_1);
            field = type.GetField("IsEditor", flag);
            app.RegisterCLRFieldGetter(field, get_IsEditor_2);
            app.RegisterCLRFieldSetter(field, set_IsEditor_2);
            app.RegisterCLRFieldBinding(field, CopyToStack_IsEditor_2, AssignFromStack_IsEditor_2);


        }



        static object get_IsILRuntime_0(ref object o)
        {
            return ETModel.Define.IsILRuntime;
        }

        static StackObject* CopyToStack_IsILRuntime_0(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ETModel.Define.IsILRuntime;
            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static void set_IsILRuntime_0(ref object o, object v)
        {
            ETModel.Define.IsILRuntime = (System.Boolean)v;
        }

        static StackObject* AssignFromStack_IsILRuntime_0(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Boolean @IsILRuntime = ptr_of_this_method->Value == 1;
            ETModel.Define.IsILRuntime = @IsILRuntime;
            return ptr_of_this_method;
        }

        static object get_IsAsync_1(ref object o)
        {
            return ETModel.Define.IsAsync;
        }

        static StackObject* CopyToStack_IsAsync_1(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ETModel.Define.IsAsync;
            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static void set_IsAsync_1(ref object o, object v)
        {
            ETModel.Define.IsAsync = (System.Boolean)v;
        }

        static StackObject* AssignFromStack_IsAsync_1(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Boolean @IsAsync = ptr_of_this_method->Value == 1;
            ETModel.Define.IsAsync = @IsAsync;
            return ptr_of_this_method;
        }

        static object get_IsEditor_2(ref object o)
        {
            return ETModel.Define.IsEditor;
        }

        static StackObject* CopyToStack_IsEditor_2(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ETModel.Define.IsEditor;
            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static void set_IsEditor_2(ref object o, object v)
        {
            ETModel.Define.IsEditor = (System.Boolean)v;
        }

        static StackObject* AssignFromStack_IsEditor_2(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Boolean @IsEditor = ptr_of_this_method->Value == 1;
            ETModel.Define.IsEditor = @IsEditor;
            return ptr_of_this_method;
        }



    }
}
