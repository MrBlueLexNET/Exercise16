using Exercise16.Client.Services;
using Exercise16.Shared.Entities;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection.Metadata.Ecma335;

namespace Exercise16.Client.Models
{
    public class MockDataService : IMockDataService
    {
        
        private readonly HttpClient httpClient;

       
        public MockDataService(HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;
            var baseAddress = configuration.GetSection("BaseAddress").Value;

            ArgumentNullException.ThrowIfNull(baseAddress, nameof(configuration));

            this.httpClient.BaseAddress = new Uri(baseAddress);
            this.httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

                   

        public Task<Device> GetAsync(string id)
        {
            throw new NotImplementedException();
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
    }
}
