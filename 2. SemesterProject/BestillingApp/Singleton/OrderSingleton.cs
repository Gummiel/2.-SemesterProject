#region References

using System;
using System.Collections.ObjectModel;
using Windows.UI.Popups;
using BestillingApp.Model;
using BestillingApp.Persistency;

#endregion

namespace BestillingApp.Singleton
{
    internal class OrderSingleton
    {
        #region Constructor

        private OrderSingleton()
        {
        }

        #endregion

        #region LoadOrderAsync

        public async void LoadOrderAsync()
        {
            if (Orders.Count > 0)
                Orders.Clear();
            try
            {
                var loadedorders = await PersistencyService.LoadOrdersFromJsonAsync();
                if (loadedorders == null)
                    return;
                if (loadedorders.Count == 0)
                    await new MessageDialog("Der findes nogen orders i databasen").ShowAsync();
                else
                    foreach (var ord in loadedorders)
                        Orders.Add(ord);
            }
            catch (Exception ex)
            {
                new MessageDialog("Der kunne ikke oprettes forbindelse til databasen").ShowAsync();
                throw;
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

        #region Instancefield

        private static OrderSingleton _instance;
        private ObservableCollection<Order> _orders;

        #endregion

        #region Properties

        public static OrderSingleton Instance => _instance ?? (_instance = new OrderSingleton());
        public ObservableCollection<Order> Orders => _orders ?? (_orders = new ObservableCollection<Order>());

        #endregion

        #region Add

        public void AddOrder(int totalPrice)
        {
            //var newOrder = new Order(totalPrice);
            //Orders.Add(newOrder);
            //PersistencyService.SaveOrderAsJsonAsync(newOrder);
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