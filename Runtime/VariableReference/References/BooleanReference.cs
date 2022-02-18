using System;

namespace K.Framework.VariableReference
{
    [Serializable]
    public class BooleanReference : VariableReference<bool>
    {
        public BooleanVariable Variable;
        protected override bool _runTimeValue => Variable.RuntimeValue;
    }
}