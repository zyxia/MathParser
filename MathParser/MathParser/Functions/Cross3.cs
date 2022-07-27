using System;
using System.Collections.Generic;
using System.Numerics; 
namespace MathParser.Functions;
 
internal class Cross3
{
    private Function3 _result;

    public Cross3(Function3 value)
    {
        this._result = value;
    }
    public Cross3(Function3 left, Function3 right)
    {
         var (l,m,n) = (left.X,left.Y,left.Z);
         var (o,p,q) = (right.X,right.Y,right.Z);
         _result = new Function3()
         {
             X = new SubFunction(new MulFunction(m, q), new MulFunction(n, p)),
             Y = new SubFunction(new MulFunction(n, o), new MulFunction(l, q)),
             Z = new SubFunction(new MulFunction(l, p), new MulFunction(m, o)),
         };
    }

    public Function3 ReduceOnce()
    {
        return _result.ReduceOnce();
    }

    public Function3 GetDerivative(string name)
    {
        return _result.GetDerivative(name);
    }

    public Function3 Const(Param value)
    {
        return _result.Const(value);
    }

    public Function3 Const(List<Param> value)
    {
        return _result.Const(value);
    }

    public Vector3 GetValue(Param value)
    {
        return _result.GetValue(value);
    }

    public Cross3 Clone()
    {
        return new Cross3(_result.Clone());
    }

    public Vector3 GetValue()
    {
        return _result.GetValue();
    }

    public override string ToString()
    {
        return "Cross " + _result.ToString();
    }
}