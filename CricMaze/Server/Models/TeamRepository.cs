using CricMaze.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CricMaze.Server.Models
{
    public class TeamRepository : ITeamRepository
    {
        private readonly AppDbContext appDbContext;

        public TeamRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Team> GetTeam(int teamId)
        {
            return await appDbContext.Teams
                .FirstOrDefaultAsync(t => t.TeamId == teamId);
        }

        public async Task<IEnumerable<Team>> GetTeams()
        {
            return await appDbContext.Teams.ToListAsync();
        }

    }
}
