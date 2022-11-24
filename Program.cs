// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using introduction.expression;

var summary = BenchmarkRunner.Run<Benchmark>();

// var bench = new Benchmark{ Value = "Frank" };
//
// bench.GetValueByIf();
// bench.GetValueBySwitch();
// bench.GetValueByExpression();