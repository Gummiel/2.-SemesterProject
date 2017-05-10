#region References

using System.Collections.ObjectModel;
using BestillingApp.Model;
using BestillingApp.Persistency;

#endregion

namespace BestillingApp.Singleton
{
    internal class OrderSingleton
    {
        #region Instancefield

        private static OrderSingleton _instance;

        #endregion

        #region Constructor

        private OrderSingleton()
        {
        }

        #endregion

        #region Properties

        public static OrderSingleton Instance => _instance ?? (_instance = new OrderSingleton());

        public ObservableCollection<Order> Orders = new ObservableCollection<Order>();

        #endregion

        #region LoadOrderAsync

        public async void LoadOrderAsync()
        {
            var orders = await PersistencyService.LoadOrdersFromJsonAsync();
            if (orders != null)
            {
                foreach (var ord in orders)
                {
                    orders.Add(ord);
                }
            }
        }

        #region Add

        public void AddOrder(int id, int totalPrice)
        {
            Order newOrder = new Order(id, totalPrice);
            Orders.Add(newOrder);
            PersistencyService.SaveOrderAsJsonAsync(newOrder);
        }

        #endregion

        #region Remove

        public void RemoveOrder(Order o)
        {
            Orders.Remove(o);
            PersistencyService.DeleteOrderAsync(o);
        }

        #endregion
    }
}