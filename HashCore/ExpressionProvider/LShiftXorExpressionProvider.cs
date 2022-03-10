using System.Linq.Expressions;

namespace HashCore.ExpressionProvider;

internal class LShiftXorExpressionProvider : IParametrizedExpressionProvider
{
    public Expression GetExpression(ParameterExpression parameterExpression, GeneratorConfig config)
        => Expression.ExclusiveOrAssign(parameterExpression, Expression.LeftShift(parameterExpression, Expression.Constant(new Random().Next(0, 32))));
}