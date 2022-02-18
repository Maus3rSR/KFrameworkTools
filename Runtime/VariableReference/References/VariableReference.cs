using System;
using UnityEngine;

namespace K.Framework.VariableReference
{
    public abstract class VariableReference<T>
    {
        public bool UseConstant = true;
        public T ConstantValue;

        protected abstract T _runTimeValue { get; }

        public T Value
        {
            get { return UseConstant ? ConstantValue : _runTimeValue; }
        }
    }
}