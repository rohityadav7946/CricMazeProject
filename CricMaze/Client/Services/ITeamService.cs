using CricMaze.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CricMaze.Client.Services
{
    public interface ITeamService
    {
        Task<IEnumerable<Team>> GetTeams();
        Task<Team> GetTeam(int teamId);
    }
}
