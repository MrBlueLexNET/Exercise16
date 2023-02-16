using Exercise16.Client.Models;
using Exercise16.Shared.Entities;

namespace Exercise16.Client.Pages
{
    public partial class DeviceOverview
    {
        public List<Device>? Devices { get; set; } = default!;

        protected override void OnInitialized()
        {
            Devices = MockDataService.Devices;
        }
    }
}
