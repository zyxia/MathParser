using System;
using System.Collections.Generic;

namespace MathParser.Functions
{
    internal class Sec : Function
    {
        private Function @internal;

        public Sec(Function @internal)
        {
            this.@internal = @internal;
        }

        public override float GetValue()
        {
            if (@internal is ConstValueFunction)
            {
                return   1.0f/(float)Math.Cos(@internal.GetValue());
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
            var tan = new Tan(@internal.Clone());
            var left = new MulFunction( tan , this.Clone());
            var right = @internal.GetDerivative(name);
            var result = new MulFunction(left, right);
            return result;
        }

        public override Function Const(Param param)
        {
            return new Sec(@internal.Const(param));
        }

        public override Function Const(List<Param> paramList)
        {
            return  new Sec(@internal.Const(paramList));
        }

        public override float GetValue(Param param)
        {
            return 1.0f/(float)Math.Cos(@internal.GetValue(param));
        }

        public override Function Clone()
        {
            return new Sec(@internal.Clone());
        }

        public override string ToString()
        {
            return "sec(" + @internal.ToString() + ")";
        }
    }
}