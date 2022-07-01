``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1766 (21H2)
Intel Core i7-6700HQ CPU 2.60GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.300
  [Host]     : .NET 5.0.8 (5.0.821.31504), X64 RyuJIT
  DefaultJob : .NET 5.0.8 (5.0.821.31504), X64 RyuJIT


```
|     Method |     Mean |     Error |    StdDev |  Gen 0 |  Gen 1 | Allocated |
|----------- |---------:|----------:|----------:|-------:|-------:|----------:|
| ToFunction | 2.717 μs | 0.0285 μs | 0.0238 μs | 0.1183 | 0.0305 |     736 B |
