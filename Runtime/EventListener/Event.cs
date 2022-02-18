using System;
using System.Collections.Generic;
using UnityEngine;

namespace K.Framework.EventListener
{
    [Serializable]
    public abstract class Event<T> : ScriptableObject
    {
        public T Value { get; private set; }

        List<EventListener<T>> _listenerList = new List<EventListener<T>>();

        public void Raise(T value)
        {
            Value = value;
            foreach (EventListener<T> listener in _listenerList)
                listener.OnEventRaised(this);
        }

        public void RegisterListener(EventListener<T> listener)
        {
            _listenerList.Add(listener);
        }

        public void UnregisterListener(EventListener<T> listener)
        {
            _listenerList.Remove(listener);
        }
    }
}
