using CricMaze.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
namespace CricMaze.Server.Models
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly AppDbContext appDbContext;

        public PlayerRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Player> AddPlayer(Player player)
        {
            if (player.Team != null)
            {
                appDbContext.Entry(player.Team).State = EntityState.Unchanged;
            }

            var result = await appDbContext.Players.AddAsync(player);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeletePlayer(int playerId)
        {
            var result = await appDbContext.Players
                .FirstOrDefaultAsync(p => p.PlayerId == playerId);

            if (result != null)
            {
                appDbContext.Players.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<Player> GetPlayer(int playerId)
        {
            return await appDbContext.Players
                .Include(p => p.Team)
                .FirstOrDefaultAsync(p => p.PlayerId == playerId);
        }

        public async Task<Player> GetPlayerbyCountry(string country)
        {
            return await appDbContext.Players
                .FirstOrDefaultAsync(p => p.Country == country);
        }

        public async Task<PlayerDataResult> GetPlayers(int skip = 0, int take =5,string orderBy = "PlayerId")
        {
            PlayerDataResult result = new PlayerDataResult()
            {
                Players = appDbContext.Players.OrderBy(orderBy).Skip(skip).Take(take),
                Count = await appDbContext.Players.CountAsync()
            };
            return result;
        }


        public async Task<IEnumerable<Player>> GetAllPlayers()
        {
            return await appDbContext.Players.Include(p => p.Team).ToListAsync();
        }



        public async Task<IEnumerable<Player>> Search(string name, Role? role)
        {
            IQueryable<Player> query = appDbContext.Players;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => p.FirstName.Contains(name)
                            || p.LastName.Contains(name));
            }

            if (role != null)
            {
                query = query.Where(p => p.Role == role);
            }

            return await query.ToListAsync();
        }

        public async Task<Player> UpdatePlayer(Player player)
        {
            var result = await appDbContext.Players
                .FirstOrDefaultAsync(p => p.PlayerId == player.PlayerId);

            if (result != null)
            {
                result.FirstName = player.FirstName;
                result.LastName = player.LastName;
                result.Country = player.Country;
                result.Matches = player.Matches;
                result.Runs = player.Runs;
                result.Highest = player.Highest;
                result.Wickets = player.Wickets;
                //result.DateOfBrith = player.DateOfBrith;

                if (player.TeamId != 0)
                {
                    result.TeamId = player.TeamId;
                }
                else if (player.Team != null)
                {
                    result.TeamId = player.Team.TeamId;
                }

                result.Role = player.Role;

                result.TeamId = player.TeamId;



                // result.PhotoPath = player.PhotoPath;

                await appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

    }
}
