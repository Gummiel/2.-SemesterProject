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

        #region LoadOrderAsync

        public async void LoadOrderAsync()
        {
            var orders = await PersistencyService.LoadOrdersFromJsonAsync();
            if (orders != null)
            {
                foreach (var ord in orders)
                    Orders.Add(ord);
            }
        }

        #endregion

        #region Remove

        public void RemoveOrder(Order o)
        {
            //Orders.Remove(o);
            PersistencyService.DeleteOrderAsync(o);
            //Hvis delete og read er på samme side
            //LoadOrderAsync();
        }

        #endregion

        #region Add

        public void AddReceipt(Receipt r)
        {
            //Receipt newReceipt = new Receipt(name, email, address, telNo, zipcode, city, totalPrice, description, amount, price);
            //Receipt.Add(r);
            PersistencyService.SaveReceiptAsJsonAsync(r);
            //Hvis create og read er på samme side
            //LoadReceiptAsync();
        }

        #endregion

        #region Properties

        public static OrderSingleton Instance => _instance ?? (_instance = new OrderSingleton());

        public ObservableCollection<Order> Orders = new ObservableCollection<Order>();

        #endregion

        #region Add

        public void AddOrder(int id, int totalPrice)
        {
            var newOrder = new Order(id, totalPrice);
            //Orders.Add(newOrder);
            PersistencyService.SaveOrderAsJsonAsync(newOrder);
            //Hvis create og read er på samme side
            //LoadOrderAsync();
        }

        public void AddOrder(Order o)
        {
            //Order newOrder = new Order(name, email, address, telNo, zipcode, city, totalPrice, description, amount, price);
            //Orders.Add(r);
            PersistencyService.SaveOrderAsJsonAsync(o);
            //Hvis create og read er på samme side
            //LoadOrderAsync();
        }

        #endregion
    }
}