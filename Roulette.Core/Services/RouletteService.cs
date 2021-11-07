using Roulette.Core.Exceptions;
using Roulette.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Core.Services
{
    public class RouletteService : IRouletteService
    {
        private readonly IRouletteRepository _rouletteRepository;
        public RouletteService(IRouletteRepository rouletteRepository)
        {
            _rouletteRepository = rouletteRepository;
        }
        public async Task<IEnumerable<Core.Entities.Roulette>> GetRoulettes()
        {
            return await _rouletteRepository.GetRoulettes();
        }
        public async Task<Core.Entities.Roulette> GetRoulette(int id)
        {
            return await _rouletteRepository.GetRouletteById(id);
        }
        public async Task PostRoulette(Core.Entities.Roulette roulette)
        {
            roulette.RouletteStatus = false;
            await _rouletteRepository.PostRoulette(roulette);
        }
        public async Task<Core.Entities.Roulette> PutRoulette(Core.Entities.Roulette roulette)
        {
            await _rouletteRepository.GetRouletteById(roulette.Id);
            return await _rouletteRepository.PutRoulette(roulette);
        }
        public async Task<bool> DeleteRoulette(int id)
        {
            Core.Entities.Roulette roulette = await _rouletteRepository.GetRouletteById(id);
            return await _rouletteRepository.DeleteRoulette(roulette);
        }
        public async Task<string> OpeningRoulette(int id)
        {
            Core.Entities.Roulette roulette = await _rouletteRepository.GetRouletteById(id);
            if (roulette == null)
            {
                throw new BusinessException("Ruleta no encontrada");
            }
            if(roulette.RouletteStatus == true)
            {
                return "Denegada";
            }
            roulette.RouletteStatus = true;
            string response = await _rouletteRepository.OpeningRoulette(roulette);
            return response;
        }
    }
}
