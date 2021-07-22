using ETModel;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ET
{

    [ObjectSystem]
    public class ConfigAwakeSystem : AwakeSystem<ConfigComponent>
    {
        public override void Awake(ConfigComponent self)
        {
            ConfigComponent.Instance = self;
        }
    }


    [ObjectSystem]
    public class ConfigDestroySystem : DestroySystem<ConfigComponent>
    {
        public override void Destroy(ConfigComponent self)
        {
            ConfigComponent.Instance = null;
        }
    }

    public static class ConfigComponentSystem
    {

        public static async ETTask LoadAsync(this ConfigComponent self)
        {

            self.AllConfig?.Clear();
            HashSet<Type> types = Game.EventSystem.GetTypes(typeof(ConfigAttribute));

            Dictionary<string, byte[]> configBytes = new Dictionary<string, byte[]>();

            ConfigComponent.GetAllConfigBytes(configBytes);


            async ETTask Load(Type configType, Dictionary<string, byte[]> configBytes)
            {
                await ETTask.CompletedTask;
                self.LoadOneInThread(configType, configBytes);
            }

            var tasks = ListComponent<ETTask>.Create();
            foreach (var item in types)
            {
                tasks.List.Add(Load(item, configBytes));//好像这么写还是同步加载
            }
            await ETTaskHelper.WaitAll(tasks.List);
            tasks.Dispose();

            //foreach (Type type in types)   //ILRT 不支持多线程
            //{
            //	Task task = Task.Run(() => self.LoadOneInThread(type, configBytes));
            //	listTasks.Add(task);
            //}
            //await Task.WhenAll(listTasks.ToArray());
        }

        private static void LoadOneInThread(this ConfigComponent self, Type configType, Dictionary<string, byte[]> configBytes)
        {
            byte[] oneConfigBytes = configBytes[configType.Name];
            Log.Info($"反序列化  {configType.Name}");
            object category = ProtobufHelper.FromBytes(configType, oneConfigBytes, 0, oneConfigBytes.Length);

            lock (self)
            {
                self.AllConfig[configType] = category;
            }
        }
    }
}