using System.Linq.Expressions;

namespace HashCore.ExpressionProvider;

class AddExpressionProvider : IParametrizedExpressionProvider
{
    public Expression GetExpression(ParameterExpression parameterExpression, GeneratorConfig config)
    {
        return Expression.AddAssign(parameterExpression, Expression.Constant(new Random().Next()));
    }

}