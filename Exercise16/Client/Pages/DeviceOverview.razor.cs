using Exercise16.Client.Models;
using Exercise16.Client.Services;
using Exercise16.Shared.Entities;
using Microsoft.AspNetCore.Components;

namespace Exercise16.Client.Pages
{
    public partial class DeviceOverview
    {
        private List<Device> devices = new List<Device>();

        [Inject]
        public IAppClient AppClient { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            var res = await AppClient.GetAsync();
            if (res is not null)
                devices = res.ToList();
        }

        private async Task AddItem(CreateDevice createDevice)
        {
            if (createDevice is null)
            {
                throw new ArgumentNullException(nameof(createDevice));
            }

            var device = await AppClient.PostAsync(createDevice);

            if (device is null)
                throw new ArgumentNullException(nameof(device));

            devices.Add(device);
        }
    }
}
