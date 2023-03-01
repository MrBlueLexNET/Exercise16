using Exercise16.Shared.Entities;

namespace Exercise16.Client.Services
{
    public interface IAppClient
    {
        Task<IEnumerable<Device>?> GetAsync();
        Task<Device?> PostAsync(CreateDevice createDevice);
        Task<bool> PutAsync(Device device);
        Task<bool> RemoveAsync(string id);
    }
}