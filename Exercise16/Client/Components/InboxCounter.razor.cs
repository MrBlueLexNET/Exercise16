using Exercise16.Client.State;
using Microsoft.AspNetCore.Components;

namespace Exercise16.Client.Components
{
    public partial class InboxCounter
    {
        [Inject]
        public ApplicationState ApplicationState { get; set; }

        private int MessageCount;

        protected override void OnInitialized()
        {
            MessageCount = new Random().Next(10);

            ApplicationState.NumberOfMessages = MessageCount;
        }

    }
}
