using ETModel;

using UnityEngine;

namespace ET
{
	[MessageHandler]
	public class M2C_PathfindingResultHandler : AMHandler<M2C_PathfindingResult>
	{
		protected override async ETVoid Run(Session session, M2C_PathfindingResult message)
		{
			Unit unit = session.Domain.GetComponent<UnitComponent>().Get(message.Id);

			float speed = unit.GetComponent<NumericComponent>().GetAsFloat(NumericType.Speed);

			var list = ListComponent<Vector3>.Create();
			
			for (int i = 0; i < message.Xs.Count; ++i)
			{
				list.List.Add(new Vector3(message.Xs[i], message.Ys[i], message.Zs[i]));
			}
			list.Dispose();
			await unit.GetComponent<MoveComponent>().MoveToAsync(list.List, speed);
		}
	}
}
