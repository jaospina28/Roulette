using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Roulette.Core.DTOs;
using Roulette.Core.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Roulette.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoulettesController : ControllerBase
    {
        private readonly IRouletteRepository _rouletteRepository;
        private readonly IMapper _mapper;
        public RoulettesController(IRouletteRepository rouletteRepository, IMapper mapper)
        {
            _rouletteRepository = rouletteRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetRoulettes()
        {
            var roulettes = await _rouletteRepository.GetRoulettes();
            var roulettesDto = _mapper.Map<IEnumerable<RouletteDto>>(roulettes);
            return Ok(roulettesDto);
        }
        [HttpPost]
        public async Task<IActionResult> Post(RouletteDto rouletteDto)
        {
            var roulette = _mapper.Map<Core.Entities.Roulette>(rouletteDto);
            await _rouletteRepository.Post(roulette);
            return Ok(roulette);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] RouletteDto rouletteDto)
        {
            try
            {
                if (id != rouletteDto.Id)
                {
                    return NotFound();
                }
                var roulette = _mapper.Map<Core.Entities.Roulette>(rouletteDto);
                await _rouletteRepository.Put(roulette);
                return Ok(new { message = "La Ruleta fue modificada con exito" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id,Core.Entities.Roulette roulette)
        {
            await _rouletteRepository.Delete(roulette);
            return Ok(new { message = "La Ruleta fue eliminada con exito" });
        }
    }
}
