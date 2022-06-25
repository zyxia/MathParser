using System;
using System.Collections.Generic;

namespace TokenParser.Functions
{
    internal class Cos : Function
    {
        private Function @internal;

        public Cos(Function @internal)
        {
            this.@internal = @internal;
        }

        public override float GetValue()
        {
            if (@internal is ConstValueFunction)
            {
                return (float) Math.Cos(@internal.GetValue());
            }

            throw new NotImplementedException();
        }

        public override Function Reduce()
        {
            @internal = @internal.Reduce();
            if (@internal is ConstValueFunction && this.GetValue() == 0)
            {
                return new ConstValueFunction(0);
            }

            return this;
        }

        public override Function GetDerivative(string name)
        {
            var left = new MulFunction(new ConstValueFunction(-1.0f), new Sin(@internal.Clone()));
            var right = @internal.GetDerivative(name);
            var result = new MulFunction(left, right);
            return result;
        }

        public override Function Const(Param param)
        {
            return new Cos(@internal.Const(param));
        }

        public override Function Const(List<Param> paramList)
        {
            return new Cos(@internal.Const(paramList));
        }

        public override float GetValue(Param param)
        {
            return (float) Math.Cos(@internal.GetValue(param));
        }

        public override Function Clone()
        {
            return new Cos(@internal.Clone());
        }

        public override string ToString()
        {
            return "cos(" + @internal.ToString() + ")";
        }
    }
}