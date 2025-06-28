using System;
using System.Collections.Generic;
using UnityEngine;

namespace InfinityIdle.Core
{
    public class ObjectPool<T> where T : class
    {
        private readonly Func<T> createFunc;
        private readonly Action<T> onGet;
        private readonly Action<T> onReturn;
        private readonly Action<T> onDestroy;
        private readonly int maxSize;
        
        private readonly Stack<T> pool = new Stack<T>();
        
        public ObjectPool(Func<T> createFunc, Action<T> onGet = null, 
            Action<T> onReturn = null, Action<T> onDestroy = null, int maxSize = 100)
        {
            this.createFunc = createFunc;
            this.onGet = onGet;
            this.onReturn = onReturn;
            this.onDestroy = onDestroy;
            this.maxSize = maxSize;
        }
        
        public T Get()
        {
            T item;
            if (pool.Count > 0)
            {
                item = pool.Pop();
            }
            else
            {
                item = createFunc();
            }
            
            onGet?.Invoke(item);
            return item;
        }
        
        public void Return(T item)
        {
            if (pool.Count < maxSize)
            {
                onReturn?.Invoke(item);
                pool.Push(item);
            }
            else
            {
                onDestroy?.Invoke(item);
            }
        }
        
        public void Clear()
        {
            while (pool.Count > 0)
            {
                var item = pool.Pop();
                onDestroy?.Invoke(item);
            }
        }
    }
}