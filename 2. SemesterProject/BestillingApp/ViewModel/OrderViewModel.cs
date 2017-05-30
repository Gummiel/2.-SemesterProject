#region References

using System.Linq;
using System.Windows.Input;
using BestillingApp.Common;
using BestillingApp.Handler;
using BestillingApp.Model;
using BestillingApp.Singleton;

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
            //OrderSingleton.OrderItems.Sum(delegate(Product product) { return product.Price; });
            TotalPrice = OrderSingleton.OrderItems.Sum(product => product.Price);
            //decimal sum = 0;
            //foreach (var product in OrderSingleton.OrderItems)
            //    sum += product.Price;
            //sum;
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

        public decimal TotalPrice { get; set; }

        public static Product SelectedOrderItem { get; set; }
        public OrderHandler OrderHandler { get; set; }
        public static CustomerSingleton CustomerSingleton { get; set; }
        public static ReceiptSingleton ReceiptSingleton { get; set; }
        public static OrderSingleton OrderSingleton { get; set; }

        #endregion
    }
}