using System.Linq.Expressions;
using BenchmarkDotNet.Attributes;

namespace introduction.expression;

[MemoryDiagnoser(false)]
public class Benchmark
{
    private readonly User _user;
    
    public Benchmark()
    {
        _user = new User("frank", 18);
    }

    [Params("Name", "Age")]
    public string Value { get; set; }

    [Benchmark]
    public void GetValueByIf()
    {
        object? result;
        if (Value is nameof(User.Name))
            result = _user.Name;
        else if (Value is nameof(User.Age))
            result = _user.Age;
        else
            result = null;
        
        // Console.WriteLine($"{nameof(GetValueByIf)}: {result}");
    }

    [Benchmark]
    public void GetValueBySwitch()
    {
        object? result = Value switch
                         {
                             nameof(User.Name) => _user.Name,
                             nameof(User.Age) => _user.Age,
                             _ => null
                         };
        
        // Console.WriteLine($"{nameof(GetValueBySwitch)}: {result}");
    }
    
    [Benchmark]
    public void GetValueByExpression()
    {
        var parameter = Expression.Parameter(typeof(User));
        var accessor = Expression.PropertyOrField(parameter, Value);

        var lambda = Expression.Lambda(accessor, false, parameter);
        var result = lambda.Compile().DynamicInvoke(_user);
        
        // Console.WriteLine($"{nameof(GetValueByExpression)}: {result}");
    }

    [Benchmark]
    public void GetValueByExpressionGeneric()
    {
        GetValueByExpressionGeneric<User>();
    }
    
    private void GetValueByExpressionGeneric<T>()
    {
        var parameter = Expression.Parameter(typeof(T));
        var accessor = Expression.PropertyOrField(parameter, Value);

        var lambda = Expression.Lambda(accessor, false, parameter);
        var result = lambda.Compile().DynamicInvoke(_user);

        // Console.WriteLine($"{nameof(GetValueByExpressionGeneric)}: {result}");
    }

    [Benchmark]
    public void GetValueByReflection()
    {
        GetValueByReflection<User>();
    }
    
    private void GetValueByReflection<T>()
    {
        var type = typeof(T);
        var propertyInfo = type.GetProperty(Value);
        var result = propertyInfo?.GetValue(_user);

        // Console.WriteLine($"{nameof(GetValueByReflection)}: {result}");
    }
}

public record User(string Name, int Age);