using System.Linq.Expressions;

namespace HashCore.ExpressionProvider;

interface IParametrizedExpressionProvider
{
    public Expression GetExpression(ParameterExpression parameterExpression, GeneratorConfig config);
}