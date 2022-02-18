using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace K.Framework.EventListener
{
    [Serializable]
    public class ResponseEvent<T> : UnityEvent<T> {}

    [Serializable]
    public struct EventResponseList<T>
    {
        public KEvent<T> Event;
        public ResponseEvent<T> Response;
    }

    public abstract class KEventListener<T> : MonoBehaviour
    {
        [SerializeField] List<EventResponseList<T>> _eventResponseList = null;

        void OnEnable()
        {
            foreach (EventResponseList<T> pair in _eventResponseList)
            pair.Event.RegisterListener(this); 
        }

        void OnDisable()
        {
            foreach (EventResponseList<T> pair in _eventResponseList)
                pair.Event.UnregisterListener(this);
        }

        public void OnEventRaised(KEvent<T> e)
        {
            foreach (EventResponseList<T> pair in _eventResponseList)
                if (pair.Event == e)
                {
                    pair.Response.Invoke(e.Value);
                    break;
                }
        }
    }
}
