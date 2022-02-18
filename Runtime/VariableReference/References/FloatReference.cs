using System;

namespace K.Framework.VariableReference
{
    [Serializable]
    public class FloatReference : VariableReference<float>
    {
        public FloatVariable Variable;
        protected override float _runTimeValue => Variable.RuntimeValue;
    }
}