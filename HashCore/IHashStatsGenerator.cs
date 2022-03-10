namespace HashCore;

public interface IHashStatsGenerator
{
    IEnumerable<HashStat> Generate(GeneratorConfig config);
}

