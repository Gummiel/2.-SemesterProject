#region References

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

        public void Login()
        {
            //login
        }
    }
}