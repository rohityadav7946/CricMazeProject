using CricMaze.Shared;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CricMaze.Client.Services
{
    public class PlayerAdaptor : DataAdaptor
    {
        private readonly IPlayerService playerService;

        public PlayerAdaptor( IPlayerService playerService)
        {
            this.playerService = playerService;
        }
        public async override Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string key = null)
        {
            string orderBystring = null;
            if(dataManagerRequest.Sorted != null)
            {
                List<Sort> sortList = dataManagerRequest.Sorted;
                sortList.Reverse();
                orderBystring = string.Join(",", sortList.Select(s => string.Format("{0} {1}", s.Name, s.Direction)));
            }
            PlayerDataResult result = await playerService.GetPlayers(dataManagerRequest.Skip, dataManagerRequest.Take,orderBystring);
            DataResult dataResult = new DataResult()
            {
                Result = result.Players,
                Count = result.Count
            };
            return dataResult;
        }
    }
}
