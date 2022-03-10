using System.Linq.Expressions;

namespace HashCore;

public class Function<T>
{
    private readonly Expression<Func<T, T>> _expression;

    private Func<T, T>? _func;
    private Func<T, T> Func => _func ??= _expression.Compile();

    public Function(Expression<Func<T, T>> expression)
    {
        _expression = expression;
    }

    public T Invoke(T param) => Func(param);
        
    public string ToString(IExpressionTranspiler expressionTranspiler) 
        => expressionTranspiler.Transpile(_expression);

    public override string ToString() => ToString(new СSharpTranspiler());

}