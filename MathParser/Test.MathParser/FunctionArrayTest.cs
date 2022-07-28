using MathParser;
using NUnit.Framework;

namespace Test.MathParser
{
    public class FunctionArray
    {
        [Test]
        public void Test()
        {
            var sValue = "[1,0,0]";
            var function =  sValue.ToFunction();
        }
    }
}