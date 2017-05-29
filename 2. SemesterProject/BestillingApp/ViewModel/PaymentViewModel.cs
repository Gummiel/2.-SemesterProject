#region References

using System;
using System.Windows.Input;
using BestillingApp.Handler;
using BestillingApp.Singleton;
using ZPointApp.Common;

#endregion

namespace BestillingApp.ViewModel
{
    internal class PaymentViewModel
    {
        private ICommand _payCommand;

        #region Constructor

        public PaymentViewModel()
        {
            OrderHandler = new OrderHandler(null, null, null, null,this);
        }

        #endregion

        #region Properties

        public static CustomerSingleton CustomerSingleton { get; set; }
        public static GasStationSingleton GasStationSingleton { get; set; }
        public static ReceiptSingleton ReceiptSingleton { get; set; }
        public static ReviewSingleton ReviewSingleton { get; set; }
        public static OrderSingleton OrderSingleton { get; set; }
        public OrderHandler OrderHandler { get; set; }

        public ICommand PayCommand
        {
            get { return _payCommand ?? (_payCommand = new RelayCommand(OrderHandler.Pay)); }
            set { _payCommand = value; }
        }

        public string AccountHolder { get; set; }
        public int CreditCardNumber { get; set; }
        public DateTime DateTime { get; set; }
        public string ExpireDateMonth { get; set; }
        public string ExpireDateYear { get; set; }

        public int CvcNumber { get; set; }

        #endregion
    }
}