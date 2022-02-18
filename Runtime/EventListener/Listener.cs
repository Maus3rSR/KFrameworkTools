using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace K.Framework.EventListener
{
    public abstract class EventResolver<T>
    {
        protected abstract Event<T> _event { get; }
        public UnityEvent<T> Resolver;

        public Event<T> Event
        {
            get { return _event; }
        }
    }

    public abstract class EventListener<T> : MonoBehaviour
    {
        public abstract IEnumerable<EventResolver<T>> _eventResolverList { get; }

        void OnEnable()
        {
            foreach (EventResolver<T> eventResolver in _eventResolverList)
                eventResolver.Event.RegisterListener(this);
        }

        void OnDisable()
        {
            foreach (EventResolver<T> eventResolver in _eventResolverList)
                eventResolver.Event.UnregisterListener(this);
        }


        public void OnEventRaised(Event<T> e)
        {
            foreach (EventResolver<T> eventResolver in _eventResolverList)
                if (eventResolver.Event == e)
                {
                    eventResolver.Resolver.Invoke(e.Value);
                    break;
                }
        }
    }
}
