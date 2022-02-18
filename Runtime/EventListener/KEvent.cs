using System;
using System.Collections.Generic;
using UnityEngine;

namespace K.Framework.EventListener
{
    [Serializable]
    public abstract class KEvent<T> : ScriptableObject
    {
        public T Value { get; private set; }

        List<KEventListener<T>> _listenerList = new List<KEventListener<T>>();

        public void Raise(T value)
        {
            Value = value;
            foreach (KEventListener<T> listener in _listenerList)
                listener.OnEventRaised(this);
        }

        public void RegisterListener(KEventListener<T> listener)
        {
            _listenerList.Add(listener);
        }

        public void UnregisterListener(KEventListener<T> listener)
        {
            _listenerList.Remove(listener);
        }
    }
}
