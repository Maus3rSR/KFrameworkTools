using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace K.Framework.EventListener
{
    [Serializable]
    public class GameObjectEventResolver : EventResolver<GameObject>
    {
        public GameObjectEvent GameObjectEvent;
        protected override Event<GameObject> _event => GameObjectEvent;
    }

    [AddComponentMenu("K.Listener/GameObject Listener")]
    public class GameObjectListener : EventListener<GameObject>
    {
        [SerializeField] List<GameObjectEventResolver> _gameObjectEventResolverList;
        public override IEnumerable<EventResolver<GameObject>> _eventResolverList => (_gameObjectEventResolverList.Cast<EventResolver<GameObject>>());
    }
}
