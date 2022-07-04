using NUnit.Framework;

namespace Test.MathParser
{
    internal class OperatorTest
    {
        [Test]
        public void Test()
        { 
            CommonTest.ParseTest( "x+y+z");
            CommonTest.ParseTest( "x-y*z/x-z");
        }
        [Test]
        public void Test2()
        { 
            CommonTest.ParseTest( "x-2*z");
            CommonTest.ParseTest( "-2.02*(x-2)*z");
            CommonTest.ParseTest( "-2.7*sin(x-2*z)"); 
        }
        [Test]
        public void Test3()
        {  
            CommonTest.ParseTest( "sin(sin(x)+y-cos(t))");
        }
    }
}