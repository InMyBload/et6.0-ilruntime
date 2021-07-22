using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using UnityEngine;

namespace ETModel
{
    public static class ILRuntimeHelper
    {

        //static Dictionary<string, string> loadDic = new Dictionary<string, string>()
        // {
        //     {"Model.dll","Model.pdb"},
        //     {"Hotfix.dll","Hotfix.pdb"},
        //     {"ModelView.dll","ModelView.pdb"},
        //     {"HotfixView.dll","HotfixView.pdb"},
        // };

        //static Dictionary<MemoryStream, MemoryStream> streamDic = new Dictionary<MemoryStream, MemoryStream>();
        static ILRuntime.Runtime.Enviorment.AppDomain appDomain;

        static IStaticMethod start;

        static List<Type> types;

        public static List<Type> Types => types;


        public static void Start()
        {
            Debug.Log($"当前使用的是ILRuntime模式");
            appDomain = new ILRuntime.Runtime.Enviorment.AppDomain();
            var reader = new ILRuntime.Mono.Cecil.Pdb.PdbReaderProvider();

            //foreach (var item in loadDic)
            //{
            //    byte[] assBytes = LoadHelper.LoadCode(item.Key).bytes;
            //    byte[] pdbBytes = LoadHelper.LoadCode(item.Value).bytes;
            //    var assStream = new MemoryStream(assBytes);
            //    var pdbStream = new MemoryStream(pdbBytes);
            //    streamDic.Add(assStream, pdbStream);
            //}

            //foreach (var item in streamDic)
            //{
            //    appDomain.LoadAssembly(item.Key, item.Value, reader);
            //}


            byte[] assBytes = LoadHelper.LoadCode("Sripte.dll").bytes;
            byte[] pdbBytes = LoadHelper.LoadCode("Sripte.pdb").bytes;

            var assStream = new MemoryStream(assBytes);
            var pdbStream = new MemoryStream(pdbBytes);
            appDomain.LoadAssembly(assStream, pdbStream, reader);

            ILHelper.InitILRuntime(appDomain);
            start = new ILStaticMethod(appDomain, "ET.Init", "Start", 0);
            types = appDomain.LoadedTypes.Values.Select(x => x.ReflectionType).ToList();
            start.Run();
        }
    }
}