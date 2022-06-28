using System.Runtime.CompilerServices;
using MathParser;
using QUT.Gppg;

namespace MathParser
{
    internal partial class Parser
    {
        public Parser(AbstractScanner<Scanner.Node, LexLocation> scanner) : base(scanner)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Scanner.Node GetRootNodeInline()
        {
            return MathParser.Scanner.Node.Root;
        }
        public Scanner.Node GetRootNode()
        {
            return MathParser.Scanner.Node.Root;
        }
    }
}