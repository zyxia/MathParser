using System;
using System.Collections.Generic;
using System.Numerics;

namespace MathParser.Functions;

public struct Function3
{
    internal Function X;
    internal Function Y;
    internal Function Z;

    public Function3 ReduceOnce()
    {
        return new Function3()
        {
            X = this.X.ReduceOnce(),
            Y = this.Y.ReduceOnce(),
            Z = this.Z.ReduceOnce(),
        };
    }

    public Function3 SimplestReduce()
    {
        return new Function3()
        {
            X = this.X.SimplestReduce(),
            Y = this.Y.SimplestReduce(),
            Z = this.Z.SimplestReduce(),
        };
    }

    public Function3 GetDerivative(string name)
    {
        return new Function3()
        {
            X = this.X.GetDerivative(name),
            Y = this.Y.GetDerivative(name),
            Z = this.Z.GetDerivative(name),
        };
    }

    public Function3 GetDerivativeByT()
    {
        return new Function3()
        {
            X = this.X.GetDerivativeByT(),
            Y = this.Y.GetDerivativeByT(),
            Z = this.Z.GetDerivativeByT(),
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
            X = this.X.Const(value),
            Y = this.Y.Const(value),
            Z = this.Z.Const(value),
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
            X = this.X.Const(value),
            Y = this.Y.Const(value),
            Z = this.Z.Const(value),
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
            this.X.GetValue(value),
            this.Y.GetValue(value),
            this.Z.GetValue(value)
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
            this.X.GetValue(),
            this.Y.GetValue(),
            this.Z.GetValue()
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
            X = this.X.Clone(),
            Y = this.Y.Clone(),
            Z = this.Z.Clone(),
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
        return $@"x={this.X.ToString()},y={this.Y.ToString()},z={this.Z.ToString()}";
    }
}