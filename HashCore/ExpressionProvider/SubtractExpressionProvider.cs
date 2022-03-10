using System.Linq.Expressions;

namespace HashCore.ExpressionProvider;

class SubtractExpressionProvider : IParametrizedExpressionProvider
{
    public Expression GetExpression(ParameterExpression parameterExpression, GeneratorConfig config)
    {
        return Expression.SubtractAssign(parameterExpression, Expression.Constant(new Random().Next()));
    }
}