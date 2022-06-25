using MathParser;
using QUT.Gppg;

namespace MathParser
{
    internal partial class Parser
    {
        public Parser(AbstractScanner<Scanner.Node, LexLocation> scanner) : base(scanner)
        {
        }

        public Scanner.Node GetRootNode()
        {
            return MathParser.Scanner.Node.Root;
        }
    }
}