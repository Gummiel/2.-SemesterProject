#region References

using System;
using System.Linq;
using Windows.UI.Popups;
using BestillingApp.Model;
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
    }
}