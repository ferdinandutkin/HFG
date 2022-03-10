using AutoMapper;
using HashCore;
using Web.DTO;

namespace Web.AutoMapper;

public class AppProfile : Profile
{
    public AppProfile()
    {
        CreateMap<HashStat, HashStatDto>().ConstructUsing(hashStat =>
            new(hashStat.AvalancheEffect, hashStat.Function.ToString()));
    }
}