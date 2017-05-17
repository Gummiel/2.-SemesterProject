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
            LoginHandler = new LoginHandler(this);
            //CustomerSingleton = CustomerSingleton.Instance;
            //GasStationSingleton = GasStationSingleton.Instance;
            //ReceiptSingleton = ReceiptSingleton.Instance;
            //ReviewSingleton = ReviewSingleton.Instance;
            //OrderSingleton = OrderSingleton.Instance;
        }

        #endregion

        #region Properties

        public LoginHandler LoginHandler { get; set; }

        public ICommand LoginCommand
        {
            get { return _loginCommand ?? (_loginCommand = new RelayCommand(LoginHandler.Login())); }
            set { _loginCommand = value; }
        }

        //public static CustomerSingleton CustomerSingleton { get; set; }
        //public static GasStationSingleton GasStationSingleton { get; set; }
        //public static ReceiptSingleton ReceiptSingleton { get; set; }
        //public static ReviewSingleton ReviewSingleton { get; set; }
        //public static OrderSingleton OrderSingleton { get; set; }

        #endregion
    }
}