using System.Collections.Generic;
using System.Threading.Tasks;

namespace Roulette.Core.Interfaces
{
    public interface IRouletteRepository
    {
        Task<IEnumerable<Core.Entities.Roulette>> GetRoulettes();
        Task<Core.Entities.Roulette> GetRouletteById(int id);
        Task<Core.Entities.Roulette> PostRoulette(Core.Entities.Roulette roulette);
        Task<Core.Entities.Roulette> PutRoulette(Core.Entities.Roulette roulette);
        Task<bool> DeleteRoulette(Core.Entities.Roulette roulette);
        Task<string> OpeningRoulette(Core.Entities.Roulette roulette);
        Task<string> CloseRoulette(Core.Entities.Roulette roulette);
    }
}
