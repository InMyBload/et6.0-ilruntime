using System;

namespace ET
{
    public readonly struct CoroutineLock: IDisposable
    {
        private readonly CoroutineLockComponent coroutineLockComponent;
        private readonly CoroutineLockType coroutineLockType;
        private readonly long key;
        private readonly short index;

        public CoroutineLock(CoroutineLockComponent coroutineLockComponent, int type, long k, short index)
        {
            this.coroutineLockComponent = coroutineLockComponent;
            this.coroutineLockType = (CoroutineLockType)type;
            this.key = k;
            this.index = index;
        }

        public void Dispose()
        {
            coroutineLockComponent.Notify((int)coroutineLockType, this.key, this.index);
        }
    }
}