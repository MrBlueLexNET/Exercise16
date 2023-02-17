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
                FirstName = "Jean-Yves",
                LastName = "Michel",
            };

            return base.OnInitializedAsync();
        }

        public void Button_Click()
        {
            Employee.FirstName = "J-Y";

        }

        public void Test()
        {

        }
    }
}
