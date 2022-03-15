using System.Linq.Expressions;

namespace HashCore.ExpressionProvider;

public class LShiftSubtractExpressionProvider : IParametrizedExpressionProvider
{
    public Expression GetExpression(ParameterExpression parameterExpression, GeneratorConfig config)
        => Expression.SubtractAssign(parameterExpression, Expression.LeftShift(parameterExpression, Expression.Constant(new Random().Next(0, 32))));
}