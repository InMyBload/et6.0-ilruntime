using ET;

using System;
using System.Collections.Concurrent;
using System.Threading;

namespace ETModel
{
    public class ThreadSynchronizationContext : SynchronizationContext
    {
        public static ThreadSynchronizationContext Instance { get; } = new ThreadSynchronizationContext(Thread.CurrentThread.ManagedThreadId);

        private readonly int threadId;

        // 线程同步队列,发送接收socket回调都放到该队列,由poll线程统一执行
        private readonly ConcurrentQueue<Action> queue = new ConcurrentQueue<Action>();

        private Action a;

        public ThreadSynchronizationContext(int threadId)
        {
            this.threadId = threadId;
        }

        public void Update()
        {
            while (true)
            {
                if (!this.queue.TryDequeue(out a))
                {
                    return;
                }

                try
                {
                    a();
                }
                catch (Exception e)
                {
#if SERVER
                    ET.Log.Error(e);
#else
                    UnityEngine.Debug.LogError(e);
#endif
                }
            }
        }

        public override void Post(SendOrPostCallback callback, object state)
        {
            this.Post(() => callback(state));
        }
		
        public void Post(Action action)
        {
            if (Thread.CurrentThread.ManagedThreadId == this.threadId)
            {
                try
                {
                    action();
                }
                catch (Exception ex)
                {
#if SERVER
                    ET.Log.Error(ex);
#else
                    UnityEngine.Debug.LogException(ex);
#endif
                }

                return;
            }

            this.queue.Enqueue(action);
        }
		
        public void PostNext(Action action)
        {
            this.queue.Enqueue(action);
        }
    }
}