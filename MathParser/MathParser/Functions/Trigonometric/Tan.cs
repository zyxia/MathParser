 
using System;
using System.Collections.Generic;

namespace MathParser.Functions
{
    internal class Tan : Function
    {
        private Function @internal;

        public Tan(Function @internal)
        {
            this.@internal = @internal;
        }

        public override float GetValue()
        {
            if (@internal is ConstValueFunction)
            {
                return (float) Math.Tan(@internal.GetValue());
            }

            throw new NotImplementedException();
        }

        public override Function Reduce()
        {
            @internal = @internal.Reduce();
            if (@internal is ConstValueFunction && this.GetValue() == 1.0f)
            {
                return new ConstValueFunction(1.0f);
            }

            return this;
        }

        public override Function GetDerivative(string name)
        {
            var sec = new Sec(@internal.Clone());
            var left = new MulFunction( sec , sec.Clone());
            var right = @internal.GetDerivative(name);
            var result = new MulFunction(left, right);
            return result;
        }

        public override Function Const(Param param)
        {
            return new Tan(@internal.Const(param));
        }

        public override Function Const(List<Param> paramList)
        {
            return new Tan(@internal.Const(paramList));
        }

        public override float GetValue(Param param)
        {
            return (float) Math.Tan(@internal.GetValue(param));
        }

        public override Function Clone()
        {
            return new Tan(@internal.Clone());
        }

        public override string ToString()
        {
            return "tan(" + @internal.ToString() + ")";
        }
    }
}