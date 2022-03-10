using HashCore;
using Web.DTO;

namespace Web.Interfaces;

public interface IHashStatService
{
    event Action<HashStatDto> BestChanged;
    IAsyncEnumerable<HashStatDto> Generate(GeneratorConfig config, IProgress<int>? progress);
}