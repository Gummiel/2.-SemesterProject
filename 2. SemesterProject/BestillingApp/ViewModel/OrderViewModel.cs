#region References

using System.Windows.Input;
using BestillingApp.Handler;
using BestillingApp.Model;
using BestillingApp.Singleton;
using ZPointApp.Common;

#endregion

namespace BestillingApp.ViewModel
{
    internal class OrderViewModel
    {
        #region Instancefield

        private ICommand _selectedOrderItemsCommand;

        #endregion

        #region Constructor

        public OrderViewModel()
        {
            OrderHandler = new OrderHandler(null, this, null, null, null);
            CustomerSingleton = CustomerSingleton.Instance;
            ReceiptSingleton = ReceiptSingleton.Instance;
            OrderSingleton = OrderSingleton.Instance;
        }

        #endregion

        #region Properties

        public ICommand SelectedOrderItemsCommand
        {
            get
            {
                return _selectedOrderItemsCommand ??
                       (_selectedOrderItemsCommand =
                           new RelayArgCommand<Product>(
                               product => OrderHandler.RemoveSelectedProductToOrderItems(product)));
            }
            set { _selectedOrderItemsCommand = value; }
        }

        public static Product SelectedOrderItem { get; set; }
        public OrderHandler OrderHandler { get; set; }
        public static CustomerSingleton CustomerSingleton { get; set; }
        public static ReceiptSingleton ReceiptSingleton { get; set; }
        public static OrderSingleton OrderSingleton { get; set; }

        #endregion
    }
}