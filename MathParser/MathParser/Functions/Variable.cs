using System;
using System.Collections.Generic;

namespace MathParser.Functions
{
    internal class VariableFunction : Function
    {
        private string Name { get; }

        public VariableFunction(string v)
        {
            Name = v;
        }

        public override Function ReduceOnce()
        {
            return this;
        }

        public override Function GetDerivative(string name)
        {
            if (this.Name == name)
            {
                return new ConstValueFunction(1);
            }
            else
            {
                return new ConstValueFunction(0);
            }
        }

        public override Function Const(Param param)
        {
            return Name == param.Name ? new ConstValueFunction(param.Value) : new ConstValueFunction(0);
        }

        public override Function Const(List<Param> paramList)
        {
            Param pFind =Param.None;
            foreach (var param in paramList)
            {
                if (param.Name == this.Name)
                {
                    pFind = param;
                    break;
                }
            }
            return !pFind.Equals(Param.None)  ? new ConstValueFunction(pFind.Value) : new ConstValueFunction(0);
        }

        public override float GetValue(Param param)
        {
            if (param.Name == this.Name)
                return param.Value;
            throw new NotImplementedException();
        }

        public override Function Clone()
        {
            return new VariableFunction(this.Name);
        }

        public override float GetValue()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}