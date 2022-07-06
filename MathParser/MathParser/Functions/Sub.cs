using System.Collections.Generic;

namespace MathParser.Functions
{
    internal class SubFunction : Function
    {
        private Function left;
        private Function right;

        public SubFunction(Function left, Function right)
        {
            this.left = left;
            this.right = right;
        }

        public override Function ReduceOnce()
        {
            var l = left.ReduceOnce();
            var r = right.ReduceOnce();
            switch (l)
            {
                case ConstValueFunction when r is ConstValueFunction:
                    return new ConstValueFunction(l.GetValue() - r.GetValue());
                case ConstValueFunction when l.GetValue() == 0.0f:
                    return new MulFunction(new ConstValueFunction(-1), r).ReduceOnce();
            }

            if (r is ConstValueFunction && r.GetValue() == 0.0f)
            {
                return l;
            }

            left = l;
            right = r;
            return this;
        }

        public override Function GetDerivative(string name)
        {
            return new SubFunction(left.GetDerivative(name), right.GetDerivative(name));
        }

        public override Function Const(Param value)
        {
            return new SubFunction(left.Const(value), right.Const(value));
        }

        public override Function Const(List<Param> value)
        {
            return new SubFunction(left.Const(value), right.Const(value));
        }

        public override float GetValue(Param value)
        {
            return left.GetValue(value) - right.GetValue(value);
        }

        public override Function Clone()
        {
            return new SubFunction(left.Clone(), right.Clone());
        }

        public override float GetValue()
        {
            return left.GetValue() - right.GetValue();
        }

        public override string ToString()
        {
            return "(" + left + " - " + right + ")";
        }
    }
}