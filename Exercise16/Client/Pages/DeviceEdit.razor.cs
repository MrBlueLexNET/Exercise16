using Exercise16.Client.Services;
using Exercise16.Shared.Entities;
using Microsoft.AspNetCore.Components;

namespace Exercise16.Client.Pages
{
    public partial class DeviceEdit
    {
        [Inject]
        public  IMockDataService? MockDataService { get; set; }
        [Parameter]
        public string DeviceId { get; set; } = string.Empty;
        public Device Device { get; set; } = new Device();

        protected override async Task OnInitializedAsync()
        {
            Device = await MockDataService.GetAsync(DeviceId);
        }
    }
}
