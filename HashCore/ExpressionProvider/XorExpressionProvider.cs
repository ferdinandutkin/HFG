using System.Linq.Expressions;

namespace HashCore.ExpressionProvider;

public class XorExpressionProvider : IParametrizedExpressionProvider
{
    public Expression GetExpression(ParameterExpression parameterExpression, GeneratorConfig config)
    {
        return Expression.ExclusiveOrAssign(parameterExpression, Expression.Constant(new Random().Next()));
    }
}