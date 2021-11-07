using Microsoft.EntityFrameworkCore;
using Roulette.Core.Entities;

namespace Roulette.Infrastructure.Context
{
    public class RouletteDBContext : DbContext
    {
        public RouletteDBContext(DbContextOptions options): base(options)
        {

        }
        public DbSet<Roulette.Core.Entities.Roulette> Roulettes { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Bet> Bets { get; set; }
    }
}
