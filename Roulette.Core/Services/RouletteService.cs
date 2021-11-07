using Roulette.Core.Exceptions;
using Roulette.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Roulette.Core.Command;
using Roulette.Core.Entities;
using AutoMapper;
using Roulette.Core.DTOs;

namespace Roulette.Core.Services
{
    public class RouletteService : IRouletteService
    {
        private readonly IRouletteRepository _rouletteRepository;
        private readonly IBetRepository _betRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly IMapper _mapper;
        public RouletteService(IRouletteRepository rouletteRepository,
            IBetRepository betRepository,
            IPlayerRepository playerRepository,
            IMapper mapper
            )
        {
            _rouletteRepository = rouletteRepository;
            _betRepository = betRepository;
            _playerRepository = playerRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Core.Entities.Roulette>> GetRoulettes()
        {
            return await _rouletteRepository.GetRoulettes();
        }
        public async Task<Core.Entities.Roulette> GetRoulette(int rouletteId)
        {
            return await _rouletteRepository.GetRouletteById(rouletteId);
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
        public async Task<bool> DeleteRoulette(int rouletteId)
        {
            Core.Entities.Roulette roulette = await _rouletteRepository.GetRouletteById(rouletteId);
            return await _rouletteRepository.DeleteRoulette(roulette);
        }
        public async Task<string> OpeningRoulette(int rouletteId)
        {
            Core.Entities.Roulette roulette = await _rouletteRepository.GetRouletteById(rouletteId);
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
        public async Task<IEnumerable<BetDto>> CloseRoulette(int rouletteId)
        {
            Core.Entities.Roulette roulette = await _rouletteRepository.GetRouletteById(rouletteId);
            if (roulette == null)
            {
                throw new BusinessException("Ruleta no encontrada");
            }
            if (roulette.RouletteStatus == false)
            {
                throw new BusinessException("La ruleta se cerro anteriormente");
            }
            var winningNumber = new Random().Next(0, 36);
            var winningColor = winningNumber % 2 == 0 ? "rojo" : "negro";
            roulette.RouletteStatus = false;
            string response = await _rouletteRepository.CloseRoulette(roulette);
            var betsPlaced = await _betRepository.GetBetsByRouletteId(rouletteId);
            //var winnersByNumberBet = await _betRepository.GetWinningPlayerByNumberBet(winningNumber);
            //var winnersByColorBet = await _betRepository.GetWinningPlayerByColorBet(winningColor);
            var winnersByNumberBet = betsPlaced.Where(x => x.NumberBet == winningNumber && x.ColorBet == null).ToList();
            var winnersByColorBet = betsPlaced.Where(x => x.ColorBet == winningColor.ToLower() && x.NumberBet == null).ToList();
            var losersByNumberBet = betsPlaced.Where(x => x.NumberBet != winningNumber && x.ColorBet == null).ToList();
            var losersByColorBet = betsPlaced.Where(x => x.ColorBet != winningColor.ToLower() && x.NumberBet == null).ToList();
            foreach(var winnerByNumerBet in winnersByNumberBet)
            {
                Player player = await _playerRepository.GetPlayerById(winnerByNumerBet.PlayerId);
                player.Money = (player.Money - winnerByNumerBet.MoneyBet) + winnerByNumerBet.MoneyBet * 5;
                await _playerRepository.PutPlayer(player);
            }
            foreach (var winnerByColorBet in winnersByColorBet)
            {
                Player player = await _playerRepository.GetPlayerById(winnerByColorBet.PlayerId);
                player.Money = (player.Money - winnerByColorBet.MoneyBet) + winnerByColorBet.MoneyBet * 1.8;
                await _playerRepository.PutPlayer(player);
            }
            foreach (var loserByNumerBet in losersByNumberBet)
            {
                Player player = await _playerRepository.GetPlayerById(loserByNumerBet.PlayerId);
                player.Money = (player.Money - loserByNumerBet.MoneyBet);
                await _playerRepository.PutPlayer(player);
            }
            foreach (var loserByColorBet in losersByColorBet)
            {
                Player player = await _playerRepository.GetPlayerById(loserByColorBet.PlayerId);
                player.Money = (player.Money - loserByColorBet.MoneyBet);
                await _playerRepository.PutPlayer(player);
            }
            IEnumerable<BetDto> betsDto = _mapper.Map<IEnumerable<BetDto>>(betsPlaced);
            return betsDto;
        }
        public async Task<Bet> PostBet(PostBetCommand postBetCommand)
        {
            Core.Entities.Roulette roulette = await _rouletteRepository.GetRouletteById(postBetCommand.RouletteId);
            Player player = await _playerRepository.GetPlayerById(postBetCommand.PlayerId);
            if (player == null)
            {
                throw new BusinessException("Jugador no registrado");
            }
            if (roulette == null)
            {
                throw new BusinessException("Ruleta no encontrada");
            }
            if (roulette.RouletteStatus == false)
            {
                throw new BusinessException("La ruleta se cerro anteriormente");
            }
            if (postBetCommand.MoneyBet < 1 || postBetCommand.MoneyBet > 1000)
            {
                throw new BusinessException("Cantidad de dinero no permitida");
            }
            if (postBetCommand.NumberBet < 0 || postBetCommand.NumberBet > 36)
            {
                throw new BusinessException("Los números válidos para apostar son del 0 al 36");
            }
            if (!postBetCommand.ColorBet.ToLower().Contains("rojo") || !postBetCommand.ColorBet.ToLower().Contains("rojo"))
            {
                throw new BusinessException("Color no permitido para la apuesta");
            }
            postBetCommand.ColorBet.ToLower();
            Bet bet = await _betRepository.PostBet(_mapper.Map<Bet>(postBetCommand));
            var betsPlaced = _betRepository.GetBetsByRouletteId(postBetCommand.RouletteId);
            return bet;
        }
    }
}
