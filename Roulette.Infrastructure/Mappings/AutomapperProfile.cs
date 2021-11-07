using AutoMapper;
using Roulette.Core.Command;
using Roulette.Core.DTOs;
using Roulette.Core.Entities;

namespace Roulette.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Roulette.Core.Entities.Roulette, RouletteDto>();
            CreateMap<RouletteDto, Roulette.Core.Entities.Roulette>();
            CreateMap<Player, PlayerDto>();
            CreateMap<PlayerDto, Player>();
            CreateMap<Bet, BetDto>();
            CreateMap<BetDto, Bet>();
            CreateMap<PostBetCommand, Bet>();
        }
    }
}
