using Exercise16.Shared.Entities;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Exercise16.Client.Services
{
    public class AppClient : IAppClient
    {
        private readonly HttpClient httpClient;

        public AppClient(HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;
            //this.httpClient.BaseAddress = new Uri("https://localhost:7199");
            //this.httpClient.BaseAddress = new Uri("https://exercise-17.azurewebsites.net");

            var baseAddress = configuration.GetValue<string>("ConnectionStrings:BaseAddress");

            ArgumentNullException.ThrowIfNull(baseAddress, nameof(configuration));

            this.httpClient.BaseAddress = new Uri(baseAddress);
            this.httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<Device>?> GetAsync()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<Device>>("api/devices");
        }

        public async Task<Device?> PostAsync(CreateDevice createDevice)
        {
            var response = await httpClient.PostAsJsonAsync("api/devices", createDevice);
            return response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<Device>() : null;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            return (await httpClient.DeleteAsync($"api/devices/{id}")).IsSuccessStatusCode;
        }

        public async Task<bool> PutAsync(Device device)
        {
            return (await httpClient.PutAsJsonAsync($"api/devices/{device.DeviceId}", device)).IsSuccessStatusCode;
        }
    }
}

