using Microsoft.EntityFrameworkCore;
using Roulette.Core.Entities;
using Roulette.Core.Interfaces;
using Roulette.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Infrastructure.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly RouletteDBContext _context;
        public PlayerRepository(RouletteDBContext context)
        {
            _context = context;
        }
        public async Task<Player> GetPlayerById(int playerId)
        {
            var player = await _context.Players.FindAsync(playerId);
            return player;
        }
        public async Task<Player> InsertMoneyToPlayer(Player player)
        {
            _context.Players.Add(player);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Inserción de dinero no fue posible");
            }
            return player;
        }
        public async Task<Player> PutPlayer(Player player)
        {
            _context.Entry(player).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("El jugador no fue modificado");
            }
            return player;
        }
    }
}
