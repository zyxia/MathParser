using System.IO;
using MathParser;
using TokenParser.Functions;

namespace TokenParser
{
    public static class StaticTool
    {
        public static Function ToFunction(this string value)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.WriteLine(value);
            writer.Flush();
            stream.Seek(0, SeekOrigin.Begin);
            var scanner = new Scanner(stream);
            var parser = new Parser(scanner);
            if (!parser.Parse())
            {
                return null;
            }

            stream.Dispose();
            writer.Dispose();
            var root = parser.GetRootNode();
            root.ToFunction(out var function);
            return function;
        }
    }
}