using System.Collections.Generic;
using System.Threading.Tasks;

namespace Roulette.Core.Interfaces
{
    public interface IRouletteService
    {
        Task<IEnumerable<Core.Entities.Roulette>> GetRoulettes();
        Task<Entities.Roulette> GetRoulette(int id);
        Task PostRoulette(Entities.Roulette roulette);
        Task<Core.Entities.Roulette> PutRoulette(Core.Entities.Roulette roulette);
        Task<bool> DeleteRoulette(int id);
        Task<string> OpeningRoulette(int id);
    }
}