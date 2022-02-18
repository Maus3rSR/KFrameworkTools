using System;
using UnityEngine;

namespace K.Framework.VariableReference
{
    public abstract class Variable<T> : ScriptableObject, ISerializationCallbackReceiver
    {
        public T InitialValue;
        [NonSerialized] public T RuntimeValue;

        public void OnBeforeSerialize() {}
        
        public void OnAfterDeserialize()
        {
            RuntimeValue = InitialValue;
        }
    }
}