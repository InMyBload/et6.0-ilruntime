/*
* @File:ListComponent.cs.cs
* @Author: ET
* @Description: 对List的封装，主要是用于List的重用
 * 这个类使用的时候，List会从池子队列中获取复用的，注意使用的时候，如果是局部临时变量，要使用using声明， 这样可以在生作用域结束的时候自动调用Dispose函数
* @Date: 2021 04 17
* @Modify:
*/

using System.Collections.Generic;
#if SERVER
namespace ET
{
    public class ListComponent<T> : Object
    {
        private bool isDispose;

        public static ListComponent<T> Create()
        {
            ListComponent<T> listComponent = ObjectPool.Instance.Fetch<ListComponent<T>>();
            listComponent.isDispose = false;
            return listComponent;
        }

        public List<T> List { get; } = new List<T>();

        public override void Dispose()
        {
            if (this.isDispose)
            {
                return;
            }

            this.isDispose = true;

            base.Dispose();

            this.List.Clear();
            ObjectPool.Instance.Recycle(this);
        }
    }

    public class ListComponentDisposeChildren<T> : Object where T : Object
    {
        private bool isDispose;

        public static ListComponentDisposeChildren<T> Create()
        {
            ListComponentDisposeChildren<T> listComponent = ObjectPool.Instance.Fetch<ListComponentDisposeChildren<T>>();
            listComponent.isDispose = false;
            return listComponent;
        }

        public List<T> List = new List<T>();

        public override void Dispose()
        {
            if (this.isDispose)
            {
                return;
            }

            this.isDispose = true;

            base.Dispose();

            foreach (T entity in this.List)
            {
                entity.Dispose();
            }

            this.List.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }
}
#endif