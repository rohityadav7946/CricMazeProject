using CricMaze.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Syncfusion.Blazor;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CricMaze.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTI1NDk1QDMxMzkyZTMzMmUzMGNSVFlISVhPVWY0dnFYT3VSRGxzOG8wNTlqbEUrQi9IOVBvTjFROVF5MUk9;NTI1NDk2QDMxMzkyZTMzMmUzMFFYQU9RZDJJNjJCcUpoUk0wTER6ejRuMWR5Q2hKdXk5SGo2OGZORXNBYW89;NTI1NDk3QDMxMzkyZTMzMmUzMExUZjBDNjhRSUE3NlV0dEtCRTQ2VVhzNGY1NjgwKzcvTzQzUW9aZERURTg9;NTI1NDk4QDMxMzkyZTMzMmUzMFNQVWtPUWpzRVd1bUpTaUk2NjczVmxUWTkvSWpEQzliT3VCWXREZVI5dGc9;NTI1NDk5QDMxMzkyZTMzMmUzMEdIOTN6bG9pVHNGRVVTZlVZcEtaR2FGaE5WRjgrZW1KaTVpekRUUGdjYXc9;NTI1NTAwQDMxMzkyZTMzMmUzMG93VTFBM1BZdmhjZHYrSEpWd3hhOHRid2lVOVNyK2lKRklDRUVqRjFwYzA9;NTI1NTAxQDMxMzkyZTMzMmUzMG56cGYvWVc2SE0xQnBQYVRaS1g2Nm1DQ292b0hha25rcFFUMlQwRmtLcjA9;NTI1NTAyQDMxMzkyZTMzMmUzMGNCNUcwYzdEdzBPUUJraHBZbWRhR0N4dVU2STMyWklFSW8yQUJudnl0WE09;NTI1NTAzQDMxMzkyZTMzMmUzMEN3OUdHNWNpYmduZVdaN1dxNGszOVNQY0xVUFM4YTI1aW1Ja29qU2lmZkU9;NTI1NTA0QDMxMzkyZTMzMmUzMG9qSmlxOFltbzVvVUFCT2RheGN2Z0wxTkZxdHlYWnhNTnFSMlhyK242N009;NTI1NTA1QDMxMzkyZTMzMmUzMGZpc1V0SUgwZHlPRk9EVEZ0RVJBSnVXQmc3NStUcWFwTXhiR1pZY2JiVFU9");


            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddHttpClient<IPlayerService, PlayerService>(client =>
             {
                 client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
             });

            builder.Services.AddHttpClient<ITeamService, TeamService>(client =>
            {
                client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
            });

            // builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddSyncfusionBlazor();
            builder.Services.AddScoped<PlayerAdaptor>();

            await builder.Build().RunAsync();
        }
    }
}
