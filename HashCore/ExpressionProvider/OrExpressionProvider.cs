using System.Linq.Expressions;

namespace HashCore.ExpressionProvider;

class OrExpressionProvider : IParametrizedExpressionProvider
{
    public Expression GetExpression(ParameterExpression parameterExpression, GeneratorConfig config)
        => Expression.OrAssign(parameterExpression, Expression.Constant(new Random().Next()));
}