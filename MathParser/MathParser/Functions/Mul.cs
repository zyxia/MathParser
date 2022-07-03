using System;
using System.Collections.Generic;

namespace MathParser.Functions
{
    internal class MulFunction : Function
    {
        private Function left;
        private Function right;

        public MulFunction(Function left, Function right)
        {
            this.left = left;
            this.right = right;
        }

        public override Function Reduce()
        {
            var l = left.Reduce();
            var r = right.Reduce();
            if (l is ConstValueFunction && r is ConstValueFunction)
            {
                return new ConstValueFunction(l.GetValue() * r.GetValue());
            }

            if (l is ConstValueFunction)
            {
                var value = l.GetValue();
                if (value == 0.0f)
                {
                    return new ConstValueFunction(0);
                }
                else if (Math.Abs(value - 1.0f) < 1e-4)
                {
                    return r;
                }
            }

            if (r is ConstValueFunction)
            {
                var value = r.GetValue();
                if (value == 0.0f)
                {
                    return new ConstValueFunction(0);
                }
                else if (Math.Abs(value - 1.0f) < 1e-4)
                {
                    return l;
                }
            }

            left = l;
            right = r;
            return this;
        }

        public override Function GetDerivative(string name)
        {
            return new AddFunction(new MulFunction(left.GetDerivative(name), right.Clone()),
                new MulFunction(left.Clone(), right.GetDerivative(name)));
        }

        public override Function Const(Param value)
        {
            return new MulFunction(left.Const(value), right.Const(value));
        }

        public override Function Const(List<Param> value)
        {
            return new MulFunction(left.Const(value), right.Const(value));
        }

        public override float GetValue(Param value)
        {
            return left.GetValue(value) * right.GetValue(value);
        }

        public override Function Clone()
        {
            return new MulFunction(left.Clone(), right.Clone());
        }

        public override float GetValue()
        {
            return left.GetValue() * right.GetValue();
        }

        public override string ToString()
        {
            return "(" + left + " * " + right + ")";
        }
    }
}