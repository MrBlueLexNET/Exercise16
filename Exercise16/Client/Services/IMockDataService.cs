using Exercise16.Shared.Entities;

namespace Exercise16.Client.Services
{
    public interface IMockDataService
    {
        Task<IEnumerable<Device>> GetAsync();
    }
}