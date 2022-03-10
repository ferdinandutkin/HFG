using System.Linq.Expressions;
using HashCore.ExpressionProvider;

namespace HashCore;

public class FunctionGenerator : FunctionGeneratorBase<int>
{
    protected override Expression Body => new ParametrizedExpressionProvider().GetExpression(Input, Config);
    
    public FunctionGenerator(GeneratorConfig config) : base(config)
    {
    }
}