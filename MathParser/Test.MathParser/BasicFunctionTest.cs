using NUnit.Framework;

namespace Test.MathParser
{
    internal class BasicFunctionTest
    {
    
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Basic1()
        {
            CommonTest.ParseTest("x"); 
        }
        [Test]
        public void Basic2()
        {
            CommonTest.ParseTest("x + x"); 
        }
        [Test]
        public void Linear()
        {
            CommonTest.ParseTest("2*x");  
        }
        [Test]
        public void Number()
        {
            CommonTest.ParseTest("23.0"); 
            CommonTest.ParseTest("23.01"); 
            CommonTest.ParseTest("-23.01");
            CommonTest.ParseTest("0.01");
        }
        [Test]
        public void SinTest()
        {
            CommonTest.ParseTest("sin(x)"); 
        }
        
        [Test]
        public void CosTest()
        {
            CommonTest.ParseTest("cos(x)");  
        }
       
        [Test]
        public void ScaleSinTest()
        {
           CommonTest. ParseTest("2.7*sin(-2.03*x)");  
        }
        [Test]
        public void VariableT()
        {
            CommonTest.ParseTest("t");  
        }
    }
}