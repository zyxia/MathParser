using System;
using System.Collections.Generic;
using System.Numerics;

namespace MathParser.Functions;

public struct Function3
{
    private Function _x;
    private Function _y;
    private Function _z;

    public Function3 ReduceOnce()
    {
        return new Function3()
        {
            _x = this._x.ReduceOnce(),
            _y = this._y.ReduceOnce(),
            _z = this._z.ReduceOnce(),
        };
    }

    public Function3 SimplestReduce()
    {
        return new Function3()
        {
            _x = this._x.SimplestReduce(),
            _y = this._y.SimplestReduce(),
            _z = this._z.SimplestReduce(),
        };
    }

    public Function3 GetDerivative(string name)
    {
        return new Function3()
        {
            _x = this._x.GetDerivative(name),
            _y = this._y.GetDerivative(name),
            _z = this._z.GetDerivative(name),
        };
    }

    public Function3 GetDerivativeByT()
    {
        return new Function3()
        {
            _x = this._x.GetDerivativeByT(),
            _y = this._y.GetDerivativeByT(),
            _z = this._z.GetDerivativeByT(),
        };
    }

    /// <summary>
    /// Consts the param value
    /// </summary>
    /// <param name="value">The param value</param>
    /// <exception cref="NotImplementedException"></exception>
    /// <returns>The function</returns>
    public Function3 Const(Param value)
    {
        return new Function3()
        {
            _x = this._x.Const(value),
            _y = this._y.Const(value),
            _z = this._z.Const(value),
        };
    }

    /// <summary>
    /// Consts the param value list
    /// </summary>
    /// <param name="value">The param value list</param>
    /// <exception cref="NotImplementedException"></exception>
    /// <returns>a new function</returns>
    public Function3 Const(List<Param> value)
    {
        return new Function3()
        {
            _x = this._x.Const(value),
            _y = this._y.Const(value),
            _z = this._z.Const(value),
        };
    }

    /// <summary>
    /// Gets the value using the specified param value
    /// </summary>
    /// <param name="value">The param value</param>
    /// <exception cref="NotImplementedException"></exception>
    /// <returns>The value</returns>
    public Vector3 GetValue(Param value)
    {
        return new Vector3(
            this._x.GetValue(value),
            this._y.GetValue(value),
            this._z.GetValue(value)
        );
    }

    public Vector3 GetValueByT(float t)
    {
        return this.GetValue(new Param("t", t));
    }

    public Vector3 GetValueByUV(float u, float v)
    {
        List<Param> pList = new List<Param>(2);
        pList.Add(new Param("u", u));
        pList.Add(new Param("v", v));
        return this.GetValue(pList);
    }

    public Vector3 GetValue()
    {
        return new Vector3(
            this._x.GetValue(),
            this._y.GetValue(),
            this._z.GetValue()
        );
    }

    /// <summary>
    /// Clones this instance
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    /// <returns>The function</returns>
    public Function3 Clone()
    {
        return new Function3()
        {
            _x = this._x.Clone(),
            _y = this._y.Clone(),
            _z = this._z.Clone(),
        };
    }

    /// <summary>
    /// Gets the value using the specified param value
    /// </summary>
    /// <param name="value">The param value</param>
    /// <returns>The value</returns>
    public Vector3 GetValue(List<Param> value)
    {
        var func = Const(value);
        func = func.SimplestReduce();
        return func.GetValue();
    }

    public override string ToString()
    {
        return $@"x={this._x.ToString()},y={this._y.ToString()},z={this._z.ToString()}";
    }
}