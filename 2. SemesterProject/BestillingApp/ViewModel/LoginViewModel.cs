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
        private ICommand _registerCommand;

        #region Constructor
        
        public LoginViewModel()
        {
            LoginHandler = new LoginHandler(this);
            CustomerSingleton = CustomerSingleton.Instance;
            CustomerSingleton.LoadCustomersAsync();

            //RegisterCommand = new RelayCommand(LoginHandler.Register);
        }

        #endregion

        #region Properties

        public ICommand RegisterCommand
        {
            get { return _registerCommand ?? (_registerCommand = new RelayCommand(LoginHandler.Register)); }
            //Hvis _registerCommand er null, så opretter den en ny.a
            set { _registerCommand = value; }
        }

        //public Customer ACustomer { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public int TelNo { get; set; }
        public int Zipcode { get; set; }
        public string City { get; set; }
        public static LoginHandler LoginHandler { get; set; }
        public static CustomerSingleton CustomerSingleton { get; set; }

        #endregion
    }
}