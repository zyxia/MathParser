using MathParser.Functions; 

namespace MathParser
{
    /// <summary>
    /// The static tool class
    /// </summary>
    public static class StaticTool
    { 
        static Scanner scanner = new Scanner();
        static Parser parser = new Parser(scanner);
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
            scanner.SetSource(value,0);
            parser.Reset();
            if (!parser.Parse())
            {
                return null;
            }
            var root = parser.GetRootNodeInline();
            root.ToFunction(out var function);
            return function;
        } 
       
    }
}