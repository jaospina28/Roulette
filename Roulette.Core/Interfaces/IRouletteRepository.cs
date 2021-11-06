using System.Collections.Generic;
using System.Threading.Tasks;

namespace Roulette.Core.Interfaces
{
    public interface IRouletteRepository
    {
        Task<IEnumerable<Core.Entities.Roulette>> GetRoulettes();
        Task<Core.Entities.Roulette> Post(Core.Entities.Roulette roulette);
        Task<Core.Entities.Roulette> Put(Core.Entities.Roulette roulette);
        Task<bool> Delete(Core.Entities.Roulette roulette);
    }
}
