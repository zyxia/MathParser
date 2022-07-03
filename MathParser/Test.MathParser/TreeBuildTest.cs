using System;
using MathParser;
using MathParser.Functions;
using NUnit.Framework;

namespace Test.MathParser
{
    internal class TreeBuildTest
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
            var function = "2*sin(t)".ToFunction();
            var value = function.GetValue(new Param("t", 0));
            var dFunction = function.GetDerivative("t");
            var value2 =dFunction.GetValue(new Param("t", 0));
            Assert.AreEqual(value, 0.0f);
            value = function.GetValue(new Param("t", (float)(Math.PI/2)));
            Assert.AreEqual(value, 2.0f);
            Assert.AreEqual(value2,2.0f);
        }
        [Test]
        public void GetValueTest2()
        {  
            var function = "t".ToFunction();
            Assert.AreEqual(function.GetValueByT(3.0f),3.0f);
            var dv = function.GetDerivativeByT().GetValueByT(3.0f);
            Assert.AreEqual(dv ,1.0f);
            function = "3".ToFunction();
            Assert.AreEqual(  3.0f,function.GetValueByT(0));
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