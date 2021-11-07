using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Roulette.Api.Responses;
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
        private readonly IRouletteService _rouletteService;
        private readonly IMapper _mapper;
        public RoulettesController(IRouletteService rouletteService, IMapper mapper)
        {
            _rouletteService = rouletteService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetRoulettes()
        {
            var roulettes = await _rouletteService.GetRoulettes();
            var roulettesDto = _mapper.Map<IEnumerable<RouletteDto>>(roulettes);
            var response = new ApiResponse<IEnumerable<RouletteDto>>(roulettesDto);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Post(RouletteDto rouletteDto)
        {
            var roulette = _mapper.Map<Core.Entities.Roulette>(rouletteDto);
            await _rouletteService.PostRoulette(roulette);
            rouletteDto = _mapper.Map<RouletteDto>(roulette);
            var response = new ApiResponse<RouletteDto>(rouletteDto);
            return Ok(response);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] RouletteDto rouletteDto)
        {
            if (id != rouletteDto.Id)
            {
                return NotFound();
            }
            var roulette = _mapper.Map<Core.Entities.Roulette>(rouletteDto);
            await _rouletteService.PutRoulette(roulette);
            rouletteDto = _mapper.Map<RouletteDto>(roulette);
            var response = new ApiResponse<RouletteDto>(rouletteDto);
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _rouletteService.DeleteRoulette(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
        [HttpPut("opening/{id}")]
        public async Task<IActionResult> RouletteOpening(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var result = await _rouletteService.OpeningRoulette(id);
            var response = new ApiResponse<string>(result);
            return Ok(response);
        }
    }
}
