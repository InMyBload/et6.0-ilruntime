

using ETModel;

namespace ET
{
	[Event]
	public class AppStartInitFinish_RemoveLoginUI: AEvent<EventType.AppStartInitFinish>
	{
		protected override async ETTask Run(EventType.AppStartInitFinish args)
		{
			Log.Info("创建 UI");
			await UIHelper.Create(args.ZoneScene, UIType.UILogin);
		}
	}
}
