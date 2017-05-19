#region References

using BestillingApp.Singleton;

#endregion

namespace BestillingApp.ViewModel
{
    internal class OrderViewModel
    {
        #region Constructor

        public OrderViewModel()
        {
            CustomerSingleton = CustomerSingleton.Instance;
            ReceiptSingleton = ReceiptSingleton.Instance;
            OrderSingleton = OrderSingleton.Instance;
        }

        #endregion

        #region Properties

        public static CustomerSingleton CustomerSingleton { get; set; }
        public static ReceiptSingleton ReceiptSingleton { get; set; }
        public static OrderSingleton OrderSingleton { get; set; }

        #endregion
    }
}