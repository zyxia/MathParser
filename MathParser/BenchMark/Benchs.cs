using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Validators;
using MathParser;
using MathParser.Functions;


public class AllowNonOptimized : ManualConfig
{
    public AllowNonOptimized()
    {
        Add(JitOptimizationsValidator.DontFailOnError); // ALLOW NON-OPTIMIZED DLLS
        Add(DefaultConfig.Instance.GetLoggers().ToArray()); // manual config has no loggers by default
        Add(DefaultConfig.Instance.GetExporters().ToArray()); // manual config has no exporters by default
        Add(DefaultConfig.Instance.GetColumnProviders().ToArray()); // manual config has no columns by default
    }
}


namespace BenchMark
{
    [MemoryDiagnoser]
    [Config(typeof(AllowNonOptimized))]
    public class Benchs
    {
        [Benchmark]
        public Function ToFunction() => "(sin(x)-cos(y-x))".ToFunction();
    }
}