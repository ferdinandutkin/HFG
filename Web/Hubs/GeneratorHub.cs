using HashCore;
using Microsoft.AspNetCore.SignalR;
using Web.DTO;
using Web.Interfaces;

namespace Web.Hubs;

public class GeneratorHub : Hub<IGeneratorHub>
{
    private readonly IHashStatService _hashStatService;

    public GeneratorHub(IHashStatService _hashStatService)
    {
        this._hashStatService = _hashStatService;
        _hashStatService.BestChanged += BestChanged;
    }

    private void BestChanged(HashStatDto hashStatDto)
    {
        Clients.Caller.BestChanged(hashStatDto);
    }
    public async IAsyncEnumerable<HashStatDto> Generate(GeneratorConfig config)
    {
        var generatorConfig = config;
        IProgress<int> progress = new Progress<int>(val => Clients.Caller.Progress(val));

        await foreach (var hashStat in _hashStatService.Generate(config, progress))
        {
            progress.Report(new Random().Next(100));
            yield return hashStat;
        }
    }
}