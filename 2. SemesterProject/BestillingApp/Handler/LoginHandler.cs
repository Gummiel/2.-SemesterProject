#region References

using System.Linq;
using BestillingApp.Model;
using BestillingApp.Singleton;
using BestillingApp.ViewModel;

#endregion

namespace BestillingApp.Handler
{
    internal class LoginHandler
    {
        public LoginHandler(LoginViewModel loginViewModel)
        {
            LoginViewModel = loginViewModel;
        }

        public LoginViewModel LoginViewModel { get; set; }

        public Customer Login()
        {
            //Returner den customer som matcher email og password
            var firstOrDefault = LoginViewModel.CustomerSingleton.Customers.FirstOrDefault(delegate(Customer customer)
            {
                var email = customer.Email == LoginViewModel.Email;
                var pass = customer.Password == LoginViewModel.Password;


                return email && pass;
            });
            return firstOrDefault;
        }

        public void Register()
        {
            Customer aCustomer = new Customer(LoginViewModel.Name,LoginViewModel.Email,LoginViewModel.Password,LoginViewModel.Address,LoginViewModel.TelNo,LoginViewModel.Zipcode,LoginViewModel.City);
            LoginViewModel.CustomerSingleton.AddCustomer(aCustomer);
        }
    }
}