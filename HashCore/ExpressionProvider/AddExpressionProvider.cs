using System.Linq.Expressions;

namespace HashCore.ExpressionProvider;

class AddExpressionProvider : IParametrizedExpressionProvider
{
    private static readonly Random Random = new();
    public Expression GetExpression(ParameterExpression parameterExpression, GeneratorConfig config)
        => Expression.AddAssign(parameterExpression, Expression.Constant(Random.Next(0, int.MaxValue)));

}