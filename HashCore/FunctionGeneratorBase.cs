using System.Linq.Expressions;

namespace HashCore;

public abstract class FunctionGeneratorBase<T> : IFunctionGenerator<T>
{
    public GeneratorConfig Config { get; }

    protected FunctionGeneratorBase(GeneratorConfig config)
    {
        Config = config;
    }
    protected ParameterExpression Input { get; } = Expression.Parameter(typeof(T), "a");

    protected abstract Expression Body { get; }
    public Function<T> GetFunction() => new(Expression.Lambda<Func<T, T>>(Body, Input));
}