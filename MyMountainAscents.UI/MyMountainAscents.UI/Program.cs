using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyMountainAscents.Data.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyMountainAscents.UI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp =>
                new HttpClient 
                { 
                    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),
                });

            builder.Services.AddScoped<IDataService, DataService>();

            await builder.Build().RunAsync();
        }
    }
}
