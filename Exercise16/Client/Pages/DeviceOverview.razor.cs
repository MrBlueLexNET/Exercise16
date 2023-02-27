using Exercise16.Client.Models;
using Exercise16.Client.Services;
using Exercise16.Shared.Entities;
using Microsoft.AspNetCore.Components;

namespace Exercise16.Client.Pages
{
    public partial class DeviceOverview
    {
        private List<Device> items = new List<Device>();

        [Inject]
        public IMockDataService MockDataService { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            var res = await MockDataService.GetAsync();
            if (res is not null)
                items = res.ToList();
        }

        private async Task AddItem(CreateDevice createDevice)
        {
            if (createDevice is null)
            {
                throw new ArgumentNullException(nameof(createDevice));
            }

            var device = await MockDataService.PostAsync(createDevice);

            if (device is null)
                throw new ArgumentNullException(nameof(device));

            items.Add(device);
        }
    }
}
