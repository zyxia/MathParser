using System.IO;
using MathParser;
using NUnit.Framework;

namespace Test.TokenParser
{
    internal static class CommonTest
    {
        public static void ParseTest(string value)
        {
            var scanner = new Scanner();
            var parser = new Parser(scanner);
            scanner.SetSource(value,0);
            Assert.IsTrue(parser.Parse());
        }
    }
}