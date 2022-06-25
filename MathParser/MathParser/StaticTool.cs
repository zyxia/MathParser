using System.IO;
using MathParser;
using TokenParser.Functions;

namespace TokenParser
{
    /// <summary>
    /// The static tool class
    /// </summary>
    public static class StaticTool
    {
        /// <summary>
        /// Returns the function using the specified value
        /// <code>
        /// "sin(t)".ToFunction()
        /// </code>
        /// </summary>
        /// <param name="value">The string value</param>
        /// <returns>The function</returns>
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