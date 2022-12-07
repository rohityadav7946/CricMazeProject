using CricMaze.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CricMaze.Client.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly HttpClient httpClient;

        public PlayerService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<Player> AddPlayer(Player player)
        {
            var response = await httpClient.PostAsJsonAsync<Player>("/api/players", player);
            return await response.Content.ReadFromJsonAsync<Player>();
        }

        public async Task DeletePlayer(int playerId)
        {
            await httpClient.DeleteAsync($"/api/players/{playerId}");
        }

        public Task<Player> GetPlayer(int playerId)
        {
            throw new NotImplementedException();
        }

        public Task<Player> GetPlayerbyCountry(string country)
        {
            throw new NotImplementedException();
        }

        public async Task<PlayerDataResult> GetPlayers(int skip, int take, string orderBy)
        {
            return await httpClient.GetFromJsonAsync<PlayerDataResult>($"/api/players?skip={skip}&take={take}&orderBy={orderBy}");
        }

        public async Task<IEnumerable<Player>> GetAllPlayers()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<Player>>("/api/players/all");
        }

        public Task<IEnumerable<Player>> Search(string name, Role? role)
        {
            throw new NotImplementedException();
        }

        public async Task<Player> UpdatePlayer(Player player)
        {
            var response = await httpClient.PutAsJsonAsync<Player>($"/api/players/{player.PlayerId}", player);
            return await response.Content.ReadFromJsonAsync<Player>();
        }
    }
}
