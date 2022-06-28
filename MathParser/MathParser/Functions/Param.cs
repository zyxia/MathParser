using System;
using System.Collections;
using System.Collections.Generic;

namespace TokenParser.Functions
{
    public struct Param:IEqualityComparer<Param>
    {
        public readonly string Name;
        public readonly float Value;
        public static readonly Param None=new Param("None",0);
        public Param(string name, float value)
        {
            Name = name;
            Value = value;
        }


        public bool Equals(Param x, Param y)
        {
            return x.Name == y.Name && x.Value.Equals(y.Value);
        }

        public int GetHashCode(Param obj)
        {
            return HashCode.Combine(obj.Name, obj.Value);
        }
    }
}