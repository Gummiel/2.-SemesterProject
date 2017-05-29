#region References

using System.Windows.Input;
using BestillingApp.Handler;
using BestillingApp.Singleton;
using ZPointApp.Common;

#endregion

namespace BestillingApp.ViewModel
{
    internal class RegisterViewModel
    {
        #region Constructor

        public RegisterViewModel()
        {
            RegisterHandler = new RegisterHandler(this);
            CustomerSingleton = CustomerSingleton.Instance;
            CustomerSingleton.LoadCustomersAsync();

            //RegisterCommand = new RelayCommand(RegisterHandler.Register);
        }

        #endregion

        #region Properties

        private ICommand _registerCommand;

        public ICommand RegisterCommand
        {
            //Hvis _registerCommand er null, så opretter den en ny.
            get { return _registerCommand ?? (_registerCommand = new RelayCommand(RegisterHandler.Register)); }
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
        public static RegisterHandler RegisterHandler { get; set; }
        public static CustomerSingleton CustomerSingleton { get; set; }

        #endregion
    }
}