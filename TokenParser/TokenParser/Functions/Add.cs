using System.Collections.Generic;

namespace TokenParser.Functions
{
    public class AddFunction : Function
    {
        private Function left;
        private Function right;

        public AddFunction(Function left, Function right)
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
                    return new ConstValueFunction(l.GetValue() + r.GetValue());
                case ConstValueFunction when l.GetValue() == 0.0f:
                    return r;
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
            return new AddFunction(left.GetDerivative(name), right.GetDerivative(name));
        }

        public override Function Const(Param value)
        {
            return new AddFunction(left.Const(value), right.Const(value));
        }

        public override Function Const(List<Param> value)
        {
            return new AddFunction(left.Const(value), right.Const(value));
        }

        public override float GetValue(Param value)
        {
            return left.GetValue(value) + right.GetValue(value);
        }

        public override Function Clone()
        {
            return new AddFunction(left.Clone(), right.Clone());
        }

        public override float GetValue()
        {
            return left.GetValue() + right.GetValue();
        }

        public override string ToString()
        {
            return "(" + left + " + " + right + ")";
        }
    }
}