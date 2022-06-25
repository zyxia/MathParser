﻿using System;
using System.Collections.Generic;
using System.IO;
using MathParser;
using Newtonsoft.Json;
using NUnit.Framework;
using TokenParser;
using TokenParser.Functions;

namespace Test.TokenParser
{
    public class TreeBuild
    {
        [Test]
        public void BuildTest()
        {
            var value = "(sin(x)-cos(y))";
            TestMathFormat(value);
            value = "(sin(x)-cos(y-x))";
            TestMathFormat(value);
            value = "(sin(x)-cos(y*x))";
            TestMathFormat(value);
            value = "(sin(x)-cos(x*x))";
            TestMathFormat(value);
        }

        [Test]
        public void BuildTest2()
        {
            const string value = "2*sin(t)*cos(1.570796)";
            TestMathFormat(value);
        }
        [Test]
        public void GetValueTest()
        {
            const string sValue = "2*sin(t)";
            var value = sValue.ToFunction().GetValue(new Param("t", 0));
            Assert.AreEqual(value, 0.0f);
            value = sValue.ToFunction().GetValue(new Param("t", (float)(Math.PI/2)));
            Assert.AreEqual(value, 2.0f);
        }
        private static void TestMathFormat(string value)
        {
            var function = value.ToFunction();
            var functionD = function.GetDerivative("x");
            functionD = functionD.Reduce();
            Console.WriteLine("the x partial  derivative of " + value + " is \n" + functionD.ToString());
        }
    }
}