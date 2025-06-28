using System;
using System.Collections.Generic;
using UnityEngine;

namespace InfinityIdle.Core
{
    public class EventBus
    {
        private readonly Dictionary<Type, List<Delegate>> eventHandlers = new Dictionary<Type, List<Delegate>>();
        private readonly object lockObject = new object();

        public void Subscribe<T>(Action<T> handler)
        {
            lock (lockObject)
            {
                Type eventType = typeof(T);
                if (!eventHandlers.ContainsKey(eventType))
                {
                    eventHandlers[eventType] = new List<Delegate>();
                }
                eventHandlers[eventType].Add(handler);
            }
        }

        public void Unsubscribe<T>(Action<T> handler)
        {
            lock (lockObject)
            {
                Type eventType = typeof(T);
                if (eventHandlers.ContainsKey(eventType))
                {
                    eventHandlers[eventType].Remove(handler);
                    if (eventHandlers[eventType].Count == 0)
                    {
                        eventHandlers.Remove(eventType);
                    }
                }
            }
        }

        public void Publish<T>(T eventData)
        {
            List<Delegate> handlers = null;
            
            lock (lockObject)
            {
                Type eventType = typeof(T);
                if (eventHandlers.ContainsKey(eventType))
                {
                    handlers = new List<Delegate>(eventHandlers[eventType]);
                }
            }

            if (handlers != null)
            {
                foreach (var handler in handlers)
                {
                    try
                    {
                        ((Action<T>)handler)(eventData);
                    }
                    catch (Exception e)
                    {
                        Debug.LogError($"Error handling event {typeof(T).Name}: {e.Message}");
                    }
                }
            }
        }

        public void Clear()
        {
            lock (lockObject)
            {
                eventHandlers.Clear();
            }
        }
    }
}