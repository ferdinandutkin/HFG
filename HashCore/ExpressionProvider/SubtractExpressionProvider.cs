using System.Linq.Expressions;

namespace HashCore.ExpressionProvider;

class SubtractExpressionProvider : IParametrizedExpressionProvider
{
    private static readonly Random Random = new();
    public Expression GetExpression(ParameterExpression parameterExpression, GeneratorConfig config)
        => Expression.SubtractAssign(parameterExpression, Expression.Constant(Random.Next(0, int.MaxValue)));
}