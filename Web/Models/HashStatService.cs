using AutoMapper;
using HashCore;
using Web.DTO;
using Web.Interfaces;

namespace Web.Models;

class HashStatService : IHashStatService
{
    private readonly IMapper _mapper;
    private readonly IHashStatsGenerator _hashStatsGenerator;
    private float _maxAvalancheEffect = 0;

    public event Action<HashStatDto> BestChanged;
    public HashStatService(IMapper mapper, IHashStatsGenerator hashStatsGenerator)
    {
        _mapper = mapper;
        _hashStatsGenerator = hashStatsGenerator;
    }
    public async IAsyncEnumerable<HashStatDto> Generate(GeneratorConfig config, IProgress<int>? progress)
    {
        foreach (var (hashStat, number) in _hashStatsGenerator.Generate(config).Select((stat, i) => (stat, i + 1)))
        {
            var toReturn = await Task.Run(() => _mapper.Map<HashStatDto>(hashStat));

            if (toReturn.AvalancheEffect > _maxAvalancheEffect)
            {
                _maxAvalancheEffect = toReturn.AvalancheEffect;
                BestChanged?.Invoke(toReturn);
            }

            
            progress?.Report((int)((number * 100 )/ config.Count));

            yield return toReturn;
        }
    }
}