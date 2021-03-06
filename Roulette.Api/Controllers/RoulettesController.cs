using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Roulette.Api.Responses;
using Roulette.Core.Command;
using Roulette.Core.DTOs;
using Roulette.Core.Entities;
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
        [HttpPut("opening/{rouletteId}")]
        public async Task<IActionResult> OpeningRoulette(int rouletteId)
        {
            if (rouletteId == 0)
            {
                return NotFound();
            }
            var result = await _rouletteService.OpeningRoulette(rouletteId);
            var response = new ApiResponse<string>(result);
            return Ok(response);
        }
        [HttpPut("close/{rouletteId}")]
        public async Task<IActionResult> CloseRoulette(int rouletteId)
        {
            if (rouletteId == 0)
            {
                return NotFound();
            }
            var result = await _rouletteService.CloseRoulette(rouletteId);
            var response = new ApiResponse<IEnumerable<BetDto>>(result);
            return Ok(response);
        }
        [HttpPost("bet")]
        public async Task<IActionResult> PostBet([FromBody] PostBetCommand postBetCommand)
        {
            var bet =await _rouletteService.PostBet(postBetCommand);
            var betDto = _mapper.Map<BetDto>(bet);
            var response = new ApiResponse<BetDto>(betDto);
            return Ok(response);
        }
    }
}
