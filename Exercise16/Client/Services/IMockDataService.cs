using Exercise16.Shared.Entities;

namespace Exercise16.Client.Services
{
    public interface IMockDataService
    {
        Task<IEnumerable<Device>> GetAsync();
        Task<Device> GetAsync(string id);

        Task<Device?> PostAsync(CreateDevice createDevice);
    }
}