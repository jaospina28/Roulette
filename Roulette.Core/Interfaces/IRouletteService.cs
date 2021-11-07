using Roulette.Core.Command;
using Roulette.Core.DTOs;
using Roulette.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Roulette.Core.Interfaces
{
    public interface IRouletteService
    {
        Task<IEnumerable<Core.Entities.Roulette>> GetRoulettes();
        Task<Entities.Roulette> GetRoulette(int rouletteId);
        Task PostRoulette(Entities.Roulette roulette);
        Task<Core.Entities.Roulette> PutRoulette(Core.Entities.Roulette roulette);
        Task<bool> DeleteRoulette(int rouletteId);
        Task<string> OpeningRoulette(int rouletteId);
        Task<IEnumerable<BetDto>> CloseRoulette(int rouletteId);
        Task<Bet> PostBet(PostBetCommand postBetCommand);
    }
}