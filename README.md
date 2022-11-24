```
BenchmarkDotNet=v0.13.2, OS=macOS Monterey 12.6 (21G115) [Darwin 21.6.0]
Intel Core i7-8850H CPU 2.60GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK=7.0.100-rc.1.22431.12
  [Host]     : .NET 7.0.0 (7.0.22.42610), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.0 (7.0.22.42610), X64 RyuJIT AVX2
```
|                      Method | Value |            Mean |         Error |        StdDev | Allocated |
|---------------------------- |------ |----------------:|--------------:|--------------:|----------:|
|                GetValueByIf |   Age |       1.0787 ns |     0.0489 ns |     0.0685 ns |         - |
|            GetValueBySwitch |   Age |      14.7518 ns |     0.3052 ns |     0.3392 ns |      24 B |
|        GetValueByExpression |   Age | 140,672.5374 ns | 2,798.7460 ns | 7,072.7883 ns |    4724 B |
| GetValueByExpressionGeneric |   Age | 135,630.3139 ns | 2,445.9730 ns | 2,168.2914 ns |    4720 B |
|        GetValueByReflection |   Age |      71.2033 ns |     1.4731 ns |     2.6563 ns |      24 B |
|                GetValueByIf |  Name |       0.3701 ns |     0.0462 ns |     0.0454 ns |         - |
|            GetValueBySwitch |  Name |       0.5160 ns |     0.0438 ns |     0.0409 ns |         - |
|        GetValueByExpression |  Name | 138,795.9468 ns | 2,554.3710 ns | 3,663.4025 ns |    4699 B |
| GetValueByExpressionGeneric |  Name | 144,344.0568 ns | 2,883.2573 ns | 5,691.2687 ns |    4700 B |
|        GetValueByReflection |  Name |      48.8208 ns |     0.7456 ns |     0.6609 ns |         - |
