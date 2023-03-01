using Exercise16.Client.Models;
using Exercise16.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Exercise16.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            //builder.Services.AddHttpClient<IMockDataService, MockDataService>();
            builder.Services.AddHttpClient<IAppClient, AppClient>();

            await builder.Build().RunAsync();
        }
    }
}