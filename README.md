```
BenchmarkDotNet=v0.13.2, OS=macOS Monterey 12.6 (21G115) [Darwin 21.6.0]
Intel Core i7-8850H CPU 2.60GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK=7.0.100-rc.1.22431.12
 [Host]     : .NET 7.0.0 (7.0.22.42610), X64 RyuJIT AVX2
 DefaultJob : .NET 7.0.0 (7.0.22.42610), X64 RyuJIT AVX2
```
|               Method | Value |            Mean |         Error |        StdDev |          Median | Allocated |
|--------------------- |------ |----------------:|--------------:|--------------:|----------------:|----------:|
|         GetValueByIf |   Age |       0.9418 ns |     0.0181 ns |     0.0160 ns |       0.9416 ns |         - |
|     GetValueBySwitch |   Age |      17.2690 ns |     0.9225 ns |     2.6909 ns |      16.0481 ns |      24 B |
| GetValueByExpression |   Age | 153,718.7645 ns | 3,338.0707 ns | 9,469.5510 ns | 151,521.2644 ns |    4714 B |
|         GetValueByIf |  Name |       0.3733 ns |     0.0117 ns |     0.0104 ns |       0.3700 ns |         - |
|     GetValueBySwitch |  Name |       0.4218 ns |     0.0073 ns |     0.0068 ns |       0.4215 ns |         - |
| GetValueByExpression |  Name | 139,012.4504 ns | 2,735.5498 ns | 3,923.2438 ns | 140,199.3124 ns |    4699 B |
