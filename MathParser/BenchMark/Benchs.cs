using BenchmarkDotNet.Attributes;
using TokenParser;
using TokenParser.Functions;

namespace BenchMark
{
    [MemoryDiagnoser]
    public class Benchs
    { 
        [Benchmark]
        public Function ToFunction() =>  "(sin(x)-cos(y-x))".ToFunction();
    
        
    }
}