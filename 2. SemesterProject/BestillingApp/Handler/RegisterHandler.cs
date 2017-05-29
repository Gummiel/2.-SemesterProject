#region References

using BestillingApp.Model;
using BestillingApp.ViewModel;

#endregion

namespace BestillingApp.Handler
{
    internal class RegisterHandler
    {
        public RegisterHandler(RegisterViewModel registerViewModel)
        {
            RegisterViewModel = registerViewModel;
        }

        public RegisterViewModel RegisterViewModel { get; set; }

        public void Register()
        {
            var aCustomer = new Customer(RegisterViewModel.Name, RegisterViewModel.Email, RegisterViewModel.Password,
                RegisterViewModel.Address, RegisterViewModel.TelNo, RegisterViewModel.Zipcode, RegisterViewModel.City);
            RegisterViewModel.CustomerSingleton.AddCustomer(aCustomer);
        }
    }
}