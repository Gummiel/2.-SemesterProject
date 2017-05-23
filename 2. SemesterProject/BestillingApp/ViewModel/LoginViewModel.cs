#region References

using System.Windows.Input;
using BestillingApp.Handler;
using BestillingApp.Model;
using BestillingApp.Singleton;
using ZPointApp.Common;

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
        }

        #endregion

        #region Properties

        public string Email { get; set; }
        public string Password { get; set; }
        public static LoginHandler LoginHandler { get; set; }
        public static CustomerSingleton CustomerSingleton { get; set; }

        #endregion
    }
}