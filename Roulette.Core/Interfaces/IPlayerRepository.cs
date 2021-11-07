using Roulette.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Core.Interfaces
{
    public interface IPlayerRepository
    {
        Task<Player> GetPlayerById(int playerId);
        Task<Player> InsertMoneyToPlayer(Player player);
        Task<Player> PutPlayer(Player player);
    }
}
