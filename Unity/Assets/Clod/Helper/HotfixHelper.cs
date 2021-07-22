using System;
using System.Collections.Generic;

namespace ETModel
{
    public static class HotfixHelper
    {
        public static void StartHotfix()
        {
            if (Define.IsILRuntime)
            {
                ILRuntimeHelper.Start();
            }
            else
            {
                MonoHelper.StartHotfix();
            }
        }

        public static List<Type> GetTypes()
        {
            return Define.IsILRuntime ? ILRuntimeHelper.Types : MonoHelper.Types;
        }

    }
}
