using ETModel;

namespace ET
{

    [Event]
    public class AppStart_Init : AEvent<EventType.AppStart>
    {
        protected override async ETTask Run(EventType.AppStart args)
        {
            Game.Scene.AddComponent<TimerComponent>();
            Game.Scene.AddComponent<CoroutineLockComponent>();

            //for (int i = 0; i < 10; i++)
            //{
                await TimerComponent.Instance.WaitAsync(10);
                Log.Info($"等待了次");
            //}






            //加载配置
            Game.Scene.AddComponent<ResourcesComponent>();
            ResourcesComponent.Instance.LoadBundle("config.unity3d");
            Game.Scene.AddComponent<ConfigComponent>();
            ConfigComponent.GetAllConfigBytes = LoadConfigHelper.LoadAllConfigBytes;
            await ConfigComponent.Instance.LoadAsync();
            ResourcesComponent.Instance.UnloadBundle("config.unity3d");

            foreach (var item in ConfigComponent.Instance.AllConfig.Values)//偷个懒
            {
                item.GetType().GetMethod("AfterDeserialization")?.Invoke(item, null);
            }

            Game.Scene.AddComponent<OpcodeTypeComponent>();
            Game.Scene.AddComponent<MessageDispatcherComponent>();

            Game.Scene.AddComponent<NetThreadComponent>();

            Game.Scene.AddComponent<ZoneSceneManagerComponent>();

            Game.Scene.AddComponent<GlobalComponent>();

            Game.Scene.AddComponent<AIDispatcherComponent>();

            ResourcesComponent.Instance.LoadBundle("unit.unity3d");

            Scene zoneScene = await SceneFactory.CreateZoneScene(1, "Process");
            await Game.EventSystem.Publish(new EventType.AppStartInitFinish() { ZoneScene = zoneScene });
            await ETTask.CompletedTask;
        }
    }
}
