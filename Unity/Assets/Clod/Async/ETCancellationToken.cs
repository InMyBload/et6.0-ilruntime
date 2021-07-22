using System;
using System.Collections.Generic;

namespace ETModel
{
    public class ETCancellationToken
    {
        private HashSet<Action> actions = new HashSet<Action>();

        public void Add(Action callback)
        {
            // 如果action是null，绝对不能添加,要抛异常，说明有协程泄漏
            this.actions.Add(callback);
        }
        
        public void Remove(Action callback)
        {
            this.actions?.Remove(callback);
        }

        public bool IsCancel()
        {
            return this.actions == null;
        }

        public void Cancel()
        {
            if (this.actions == null)
            {
                return;
            }

            this.Invoke();
        }

        private void Invoke()
        {
            HashSet<Action> runActions = this.actions;
            this.actions = null;
            try
            {
                foreach (Action action in runActions)
                {
                    action.Invoke();
                }
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

        public async ETVoid CancelAfter(long afterTimeCancel)
        {
            if (this.actions == null)
            {
                return;
            }
#if SERVER
            await ET.TimerComponent.Instance.WaitAsync(afterTimeCancel);
#else
            //await TimerComponent.Instance.WaitAsync(afterTimeCancel);
#endif

            this.Invoke();
        }
    }
}