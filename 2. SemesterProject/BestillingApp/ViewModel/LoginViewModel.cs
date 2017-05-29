#region References

using BestillingApp.Handler;
using BestillingApp.Singleton;

#endregion

namespace BestillingApp.ViewModel
{
    internal class LoginViewModel
    {
        #region Constructor

        public LoginViewModel()
        {
            LoginHandler = new LoginHandler(this);
            CustomerSingleton = CustomerSingleton.Instance;
            CustomerSingleton.LoadCustomersAsync();
            LoginSingleton = LoginSingleton.Instance;
        }

        #endregion

        #region Properties

        public string Email { get; set; }
        public string Password { get; set; }
        public static LoginHandler LoginHandler { get; set; }
        public static CustomerSingleton CustomerSingleton { get; set; }
        public static LoginSingleton LoginSingleton { get; set; }

        #endregion
    }
}