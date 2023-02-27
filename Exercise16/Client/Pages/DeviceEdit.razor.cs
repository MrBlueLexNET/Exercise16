using Exercise16.Client.Services;
using Exercise16.Shared.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Diagnostics;

namespace Exercise16.Client.Pages
{
    public partial class DeviceEdit
    {
        private CreateDevice createDevice = new CreateDevice();
        private EditContext editContext = default!;

        [Parameter]
        public EventCallback<CreateDevice> AddDevice { get; set; }

        protected override void OnInitialized()
        {
            editContext = new EditContext(createDevice);
        }

        public async Task OnAddDevice()
        {
            await AddDevice.InvokeAsync(createDevice);
            createDevice.Name = string.Empty;
        }
    }
}
