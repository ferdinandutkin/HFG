namespace HashCore;

public class HashStatsGenerator : IHashStatsGenerator
{
    private readonly IFunctionGeneratorFactory<int> _functionGeneratorFactoryFactory;

    public HashStatsGenerator(IFunctionGeneratorFactory<int> functionGeneratorFactory)
    {
        _functionGeneratorFactoryFactory = functionGeneratorFactory;
    }

    public IEnumerable<HashStat> Generate(GeneratorConfig config)
    {
        var generator = _functionGeneratorFactoryFactory.CreateInstance(config);

        for (int i = 0; i < config.Count; i++)
        {
            yield return new HashStat(generator.GetFunction());
        }
    }
}

