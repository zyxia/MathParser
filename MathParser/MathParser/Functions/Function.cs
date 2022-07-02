﻿using System;
using System.Collections.Generic;

namespace TokenParser.Functions
{
    /// <summary> 
    /// The Base Function class
    /// </summary>
    public abstract class Function
    {
        /// <summary>
        /// Reduces this function Tree
        /// "sin(x)*1" will be reduce out the "sin(x)",tree node "sin" mul "1" can be reduce out "sin" node
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        /// <returns>The function</returns>
        public virtual Function Reduce()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Gets the derivative using the specified param name
        /// </summary>
        /// <param name="name">The param name</param>
        /// <exception cref="NotImplementedException"></exception>
        /// <returns>The function</returns>
        public virtual Function GetDerivative(string name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Consts the param value
        /// </summary>
        /// <param name="value">The param value</param>
        /// <exception cref="NotImplementedException"></exception>
        /// <returns>The function</returns>
        public virtual Function Const(Param value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Consts the param value list
        /// </summary>
        /// <param name="value">The param value list</param>
        /// <exception cref="NotImplementedException"></exception>
        /// <returns>a new function</returns>
        public virtual Function Const(List<Param> value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the value using the specified param value
        /// </summary>
        /// <param name="value">The param value</param>
        /// <exception cref="NotImplementedException"></exception>
        /// <returns>The value</returns>
        public virtual float GetValue(Param value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the value
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        /// <returns>The value</returns>
        public virtual float GetValue()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Clones this instance
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        /// <returns>The function</returns>
        public virtual Function Clone()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the value using the specified param value
        /// </summary>
        /// <param name="value">The param value</param>
        /// <returns>The value</returns>
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