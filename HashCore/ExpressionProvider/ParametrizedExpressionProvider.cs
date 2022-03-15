using System.Linq.Expressions;

namespace HashCore.ExpressionProvider;

class ParametrizedExpressionProvider : IParametrizedExpressionProvider
{
    public Expression GetExpression(ParameterExpression parameterExpression, GeneratorConfig config)
    {
        var randomExpressionProvider = new RandomExpressionProvider();

        return Expression.Block(Enumerable.Range(0, config.OperationsCount).Select(_ => randomExpressionProvider.GetExpression(parameterExpression, config)));
    }
}