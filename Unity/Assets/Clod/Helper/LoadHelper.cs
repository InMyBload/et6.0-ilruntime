using System.IO;
using System.Linq;

using UnityEditor;

using UnityEngine;

namespace ETModel
{

    public static class LoadHelper
    {
        const string CodeABName = "code.unity3d";
        public static TextAsset LoadCode(string name)
        {
#if UNITY_EDITOR
            string codePath = $"Assets/Bundles/Independent/Code.prefab";//Path.Combine(Application.dataPath, "Bundles","Independent","Code.prefab");

            string[] realPath = null;
            realPath = AssetDatabase.GetAssetPathsFromAssetBundle(CodeABName);
            codePath = realPath.FirstOrDefault();
            GameObject code = AssetDatabase.LoadAssetAtPath<GameObject>(codePath);
            if (code == null)
            {
                throw new System.Exception("请检查 Code是否存在");
            }
            var testAsset = code.GetComponent<ReferenceCollector>().Get<TextAsset>(name);
            return testAsset;
#endif




        }
    }
}