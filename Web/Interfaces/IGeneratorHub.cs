using Web.DTO;

namespace Web.Interfaces;

public interface IGeneratorHub
{
    Task BestChanged(HashStatDto hashStatDto);

    Task Progress(int percent);
}