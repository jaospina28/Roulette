using Roulette.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Roulette.Core.Interfaces
{
    public interface IBetRepository
    {
        Task<IEnumerable<Bet>> GetBetsByRouletteId(int rouletteId);
        Task<Bet> PostBet(Bet bet);
    }
}
