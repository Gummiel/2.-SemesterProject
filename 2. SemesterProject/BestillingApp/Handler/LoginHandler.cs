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
            LoginSingleton = LoginSingleton.Instance;
        }

        public LoginViewModel LoginViewModel { get; set; }
        public LoginSingleton LoginSingleton { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }

        public Customer Login()
        {
            //Returner den customer som matcher email og password
            var firstOrDefault = LoginViewModel.CustomerSingleton.Customers.FirstOrDefault(delegate(Customer customer)
            {
                var email = customer.Email == LoginViewModel.Email;
                var pass = customer.Password == LoginViewModel.Password;
                //LoginSingleton.Email = LoginViewModel.Email;


                return email && pass;
            });
            LoginSingleton.Email = firstOrDefault.Email;
            LoginSingleton.Name = firstOrDefault.Name;
            return firstOrDefault;
        }
    }
}