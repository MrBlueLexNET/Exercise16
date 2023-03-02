using Exercise16.Client.Widgets;
using Exercise16.Shared.Entities;

namespace Exercise16.Client.Pages
{
    public partial class Index
    {
        public Employee Employee { get; set; } = default!;
        protected override Task OnInitializedAsync()
        {
            Employee = new Employee
            {
                FirstName = "OnInitializedAsync FirstName",
                LastName = "Michel LastName",
            };

            return base.OnInitializedAsync();
        }

        public void Button_Click()
        {
            Employee.FirstName = "Button_Click FirstName";

        }

        public void Test()
        {

        }

        //public List<Type> Widgets { get; set; } = new List<Type>() { typeof(DeviceCountWidget), typeof(InboxWidget) };
        public List<Type> Widgets { get; set; } = new List<Type>() {typeof(InboxWidget) };
    }
}
