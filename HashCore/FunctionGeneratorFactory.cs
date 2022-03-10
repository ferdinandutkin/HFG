namespace HashCore;

public class FunctionGeneratorFactory : IFunctionGeneratorFactory<int>
{
    public IFunctionGenerator<int> CreateInstance(GeneratorConfig config)
        => new FunctionGenerator(config);
}