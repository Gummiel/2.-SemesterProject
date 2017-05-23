#region References

using System.Linq;
using BestillingApp.Model;
using BestillingApp.ViewModel;

#endregion

namespace BestillingApp.Handler
{
    internal class CustomerHandler
    {
        public CustomerHandler(LoginViewModel loginViewModel)
        {
            LoginViewModel = loginViewModel;
        }

        public LoginViewModel LoginViewModel { get; set; }

        //public void Login()
        //{
        //    //login
        //    //Returner den customer som matcher email og password
        //    var firstOrDefault = LoginViewModel.CustomerSingleton.Customers.FirstOrDefault(delegate(Customer customer)
        //    {
        //        var email = customer.Email == LoginViewModel.Email;
        //        var pass = customer.Password == LoginViewModel.Password;
        //        return email && pass;
        //    });
        //}

        
    }
}