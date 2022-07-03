using System;
using System.Collections.Generic;

namespace MathParser.Functions
{
    internal class Sin : Function
    {
        private Function @internal;

        public Sin(Function @internal)
        {
            this.@internal = @internal;
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
            return new MulFunction(new Cos(@internal.Clone()), @internal.GetDerivative(name));
        }

        public override Function Const(Param param)
        {
            return new Sin(@internal.Const(param));
        }

        public override Function Const(List<Param> paramList)
        {
            return new Sin(@internal.Const(paramList));
        }

        public override float GetValue(Param param)
        {
            return (float) Math.Sin(@internal.GetValue(param));
        }

        public override float GetValue()
        {
            if (@internal is ConstValueFunction)
            {
                return (float) Math.Sin(@internal.GetValue());
            }

            throw new NotImplementedException();
        }

        public override Function Clone()
        {
            return new Sin(@internal.Clone());
        }

        public override string ToString()
        {
            return "sin(" + @internal + ")";
        }
    }
}