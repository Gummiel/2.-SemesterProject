#region References

using System.Windows.Input;
using BestillingApp.Handler;
using BestillingApp.Singleton;
using ZPointApp.Common;

#endregion

namespace BestillingApp.ViewModel
{
    internal class LoginViewModel
    {
        private ICommand _loginCommand;

        #region Constructor

        public LoginViewModel()
        {
            CustomerHandler = new CustomerHandler(this);
            CustomerSingleton = CustomerSingleton.Instance;
        }

        #endregion

        #region Properties

        public string Email { get; set; }
        public string Password { get; set; }
        public CustomerHandler CustomerHandler { get; set; }

        public ICommand LoginCommand
        {
            get { return _loginCommand ?? (_loginCommand = new RelayCommand(CustomerHandler.Login)); }
            set { _loginCommand = value; }
        }

        public static CustomerSingleton CustomerSingleton { get; set; }

        #endregion
    }
}