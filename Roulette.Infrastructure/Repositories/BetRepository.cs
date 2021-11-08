using Microsoft.EntityFrameworkCore;
using Roulette.Core.Entities;
using Roulette.Core.Interfaces;
using Roulette.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Infrastructure.Repositories
{
    public class BetRepository : IBetRepository
    {
        private readonly RouletteDBContext _context;
        public BetRepository(RouletteDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Bet>> GetBetsByRouletteId(int rouletteId)
        {
            var bets = await _context.Bets.Where(x => x.RouletteId == rouletteId).ToListAsync();
            return bets;
        }
        public async Task<Bet> PostBet(Bet bet)
        {
            _context.Bets.Add(bet);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("La apuesta no se guardo");
            }
            return bet;
        }
    }
}
