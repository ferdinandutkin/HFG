using System.Linq.Expressions;

namespace HashCore.ExpressionProvider;

class RandomExpressionProvider : IParametrizedExpressionProvider
{
    private static readonly IParametrizedExpressionProvider[] ParametrizedExpressionProviders = {
        new XorExpressionProvider(),
        new SubtractExpressionProvider(),
        new OrExpressionProvider(),
        new AddExpressionProvider(),
        new RShiftXorExpressionProvider(),
        new LShiftXorExpressionProvider(),
        new LShiftAddExpressionProvider(),
        new LShiftSubtractExpressionProvider()
    };

    private static readonly Random Random = new();
    public Expression GetExpression(ParameterExpression parameterExpression, GeneratorConfig config) => 
        ParametrizedExpressionProviders[Random.Next(ParametrizedExpressionProviders.Length)].GetExpression(parameterExpression, config);
}