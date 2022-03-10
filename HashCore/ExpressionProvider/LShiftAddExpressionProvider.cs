using System.Linq.Expressions;

namespace HashCore.ExpressionProvider;

public class LShiftAddExpressionProvider : IParametrizedExpressionProvider
{
    public Expression GetExpression(ParameterExpression parameterExpression, GeneratorConfig config)
    {
        return Expression.AddAssign(parameterExpression, Expression.LeftShift(parameterExpression, Expression.Constant(new Random().Next(0, 32))));
    }
}