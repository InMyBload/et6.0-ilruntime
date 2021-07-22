using ETModel;

using System;

namespace ET
{
    public interface IEvent
    {
        Type GetEventType();
    }

    [Event]

#if SERVER
    public abstract class AEvent<A> : IEvent where A : struct
#else
	public abstract class AEvent<A>: IEvent where A: class
#endif

    {
        public Type GetEventType()
        {
            return typeof(A);
        }

        protected abstract ETTask Run(A a);

        public async ETTask Handle(A a)
        {
            try
            {
                await Run(a);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
    }
}