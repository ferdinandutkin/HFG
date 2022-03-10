using System.Linq.Expressions;

namespace HashCore.ExpressionProvider;

public class RShiftXorExpressionProvider : IParametrizedExpressionProvider
{
    public Expression GetExpression(ParameterExpression parameterExpression, GeneratorConfig config)
    {
        return Expression.ExclusiveOrAssign(parameterExpression, Expression.RightShift(parameterExpression, Expression.Constant(new Random().Next(0, 32))));
    }
}