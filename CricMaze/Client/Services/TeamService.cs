using CricMaze.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CricMaze.Client.Services
{
    public class TeamService : ITeamService
    {
        private readonly HttpClient httpClient;

        public TeamService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<Team> GetTeam(int teamId)
        {
            return await httpClient.GetFromJsonAsync<Team>($"/api/teams/{teamId}");
        }

        public async Task<IEnumerable<Team>> GetTeams()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<Team>>("/api/teams");
        }
    }
}
