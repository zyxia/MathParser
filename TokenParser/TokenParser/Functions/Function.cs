using System;
using System.Collections.Generic;

namespace TokenParser.Functions
{
    public abstract class Function
    {
        public virtual Function Reduce()
        {
            throw new NotImplementedException();
        }
        public virtual Function GetDerivative(string name)
        {
            throw new NotImplementedException();
        }

        public virtual Function Const(Param value)
        {
            throw new NotImplementedException();
        }

        public virtual Function Const(List<Param> value)
        {
            throw new NotImplementedException();
        }

        public virtual float GetValue(Param value)
        {
            throw new NotImplementedException();
        }

        public virtual float GetValue()
        {
            throw new NotImplementedException();
        }

        public virtual Function Clone()
        {
            throw new NotImplementedException();
        }

        public float GetValue(List<Param> value)
        {
            var func = Const(value);
            return func.GetValue();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}