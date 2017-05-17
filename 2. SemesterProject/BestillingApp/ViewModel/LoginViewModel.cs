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
            //GasStationSingleton = GasStationSingleton.Instance;
            //ReceiptSingleton = ReceiptSingleton.Instance;
            //ReviewSingleton = ReviewSingleton.Instance;
            //OrderSingleton = OrderSingleton.Instance;
        }

        #endregion

        #region Properties

        public string Email { get; set; }
        public string Password { get; set; }
        public CustomerHandler CustomerHandler { get; set; }

        public ICommand LoginCommand
        {
            get { return _loginCommand /*?? (_loginCommand = new RelayCommand(CustomerHandler.Login()))*/; }
            set { _loginCommand = value; }
        }

        public static CustomerSingleton CustomerSingleton { get; set; }
        //public static GasStationSingleton GasStationSingleton { get; set; }
        //public static ReceiptSingleton ReceiptSingleton { get; set; }
        //public static ReviewSingleton ReviewSingleton { get; set; }
        //public static OrderSingleton OrderSingleton { get; set; }

        #endregion
    }
}