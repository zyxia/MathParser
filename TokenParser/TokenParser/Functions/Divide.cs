using System;
using System.Collections.Generic;

namespace TokenParser.Functions
{
    public class DivideFunction : Function
    {
        private Function left;
        private Function right;

        public DivideFunction(Function left, Function right)
        {
            this.left = left;
            this.right = right;
        }

        public override Function Reduce()
        {
            var l = left.Reduce();
            var r = right.Reduce();
            switch (l)
            {
                case ConstValueFunction when r is ConstValueFunction:
                    return new ConstValueFunction(l.GetValue() / r.GetValue());
                case ConstValueFunction when l.GetValue() == 0.0f:
                    return new ConstValueFunction(0);
            }

            if (r is ConstValueFunction && r.GetValue() == 0.0f)
            {
                throw new Exception("divide by 0 is not valid!!");
            }

            left = l;
            right = r;
            return this;
        }

        public override Function GetDerivative(string name)
        {
            var f1 = new SubFunction(new MulFunction(left.GetDerivative(name), right.Clone()),
                new MulFunction(left.Clone(), right.GetDerivative(name)));
            var f2 = new MulFunction(right.Clone(), right.Clone());
            return new DivideFunction(f1, f2);
        }

        public override Function Const(Param value)
        {
            return new DivideFunction(left.Const(value), right.Const(value));
        }

        public override Function Const(List<Param> value)
        {
            return new DivideFunction(left.Const(value), right.Const(value));
        }

        public override float GetValue(Param value)
        {
            return left.GetValue(value) / right.GetValue(value);
        }

        public override Function Clone()
        {
            return new DivideFunction(left.Clone(), right.Clone());
        }

        public override float GetValue()
        {
            return left.GetValue() / right.GetValue();
        }

        public override string ToString()
        {
            return "(" + left + " / " + right + ")";
        }
    }
}