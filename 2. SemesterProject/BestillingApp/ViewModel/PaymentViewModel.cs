#region References

using System;
using System.Windows.Input;
using BestillingApp.Handler;
using BestillingApp.Singleton;

#endregion

namespace BestillingApp.ViewModel
{
    internal class PaymentViewModel
    {
        private ICommand _payCommand;

        #region Constructor

        public PaymentViewModel()
        {
            OrderHandler = new OrderHandler(null, null, null, null, this);
            LoginSingleton = LoginSingleton.Instance;
            ;
            Email = LoginSingleton.Email;
            Name = "";
        }

        #endregion

        #region Properties

        public static ReceiptSingleton ReceiptSingleton { get; set; }
        public static OrderHandler OrderHandler { get; set; }
        public LoginSingleton LoginSingleton { get; set; }

        public string AccountHolder { get; set; }
        public int CreditCardNumber { get; set; }
        public DateTime DateTime { get; set; }
        public string ExpireDateMonth { get; set; }
        public string ExpireDateYear { get; set; }
        public int CvcNumber { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }

        #endregion
    }
}