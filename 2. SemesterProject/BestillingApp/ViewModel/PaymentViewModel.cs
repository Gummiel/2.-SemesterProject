#region References

using BestillingApp.Singleton;

#endregion

namespace BestillingApp.ViewModel
{
    internal class PaymentViewModel
    {
        #region Constructor

        public PaymentViewModel()
        {
            CustomerSingleton = CustomerSingleton.Instance;
            GasStationSingleton = GasStationSingleton.Instance;
            ReceiptSingleton = ReceiptSingleton.Instance;
            ReviewSingleton = ReviewSingleton.Instance;
            OrderSingleton = OrderSingleton.Instance;
        }

        #endregion

        #region Properties

        public static CustomerSingleton CustomerSingleton { get; set; }
        public static GasStationSingleton GasStationSingleton { get; set; }
        public static ReceiptSingleton ReceiptSingleton { get; set; }
        public static ReviewSingleton ReviewSingleton { get; set; }
        public static OrderSingleton OrderSingleton { get; set; }

        public string AccountHolder { get; set; }

        #endregion
    }
}