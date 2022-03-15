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
    public Expression GetExpression(ParameterExpression parameterExpression, GeneratorConfig config)
    {
        List<IParametrizedExpressionProvider> parametrizedExpressionProviders = new(ParametrizedExpressionProviders.Length);

        if (config.Xor)
        {
            parametrizedExpressionProviders.Add(new XorExpressionProvider());
        }
        if (config.Subtract)
        {
            parametrizedExpressionProviders.Add(new SubtractExpressionProvider());
        }
        if (config.Or)
        {
            parametrizedExpressionProviders.Add(new OrExpressionProvider());
        }
        if (config.Add)
        {
            parametrizedExpressionProviders.Add(new AddExpressionProvider());
        }
        if (config.RShiftXor)
        {
            parametrizedExpressionProviders.Add(new RShiftXorExpressionProvider());
        }
        if (config.LShiftXor)
        {
            parametrizedExpressionProviders.Add(new LShiftXorExpressionProvider());
        }
        if (config.LShiftAdd)
        {
            parametrizedExpressionProviders.Add(new LShiftAddExpressionProvider());
        }
        if (config.LShiftSubtract)
        {
            parametrizedExpressionProviders.Add(new LShiftSubtractExpressionProvider());
        }

        return parametrizedExpressionProviders[Random.Next(0, parametrizedExpressionProviders.Count)].GetExpression(parameterExpression, config);

    }
        
}