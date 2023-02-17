using Exercise16.Client.Models;
using Exercise16.Shared.Entities;
using Microsoft.AspNetCore.Components;

namespace Exercise16.Client.Pages
{
    public partial class DeviceDetail
    {
       
        [Parameter]
        public string DeviceId { get; set; }

        public Device? Device { get; set; } = new Device();

        protected override Task OnInitializedAsync()
        {
           Device = MockDataService.Devices.FirstOrDefault(d => d.DeviceId == DeviceId);
            return base.OnInitializedAsync();
           
        }

    }
}
