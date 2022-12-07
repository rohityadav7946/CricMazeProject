using CricMaze.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CricMaze.Server.Models
{
    public interface IPlayerRepository
    {
        Task<IEnumerable<Player>> Search(string name, Role? role);
        Task<PlayerDataResult> GetPlayers(int skip, int take, string orderBy);
        Task<IEnumerable<Player>> GetAllPlayers();
        Task<Player> GetPlayer(int playerId);
        Task<Player> GetPlayerbyCountry(string country);
        Task<Player> AddPlayer(Player player);
        Task<Player> UpdatePlayer(Player player);
        Task DeletePlayer(int playerId);
    }
}
