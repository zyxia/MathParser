using System.Collections.Generic;
using System.Globalization;

namespace MathParser.Functions
{
    internal class ConstValueFunction : Function
    {
        private float Value { get; }

        public ConstValueFunction(float v)
        {
            Value = v;
        }
        public override Function ReduceOnce()
        { 
            return this;
        }
        public override Function GetDerivative(string name)
        {
            return new ConstValueFunction(0);
        }

        public override Function Const(Param _)
        {
            return Clone();
        }

        public override Function Const(List<Param> _)
        {
            return Clone();
        }

        public override float GetValue(Param _)
        {
            return Value;
        }

        public override Function Clone()
        {
            return new ConstValueFunction(this.Value);
        }

        public override float GetValue()
        {
            return this.Value;
        }
        public override string ToString()
        {
            return this.Value.ToString(CultureInfo.InvariantCulture);
        }
    }

}