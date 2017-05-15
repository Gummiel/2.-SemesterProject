#region References

using System;
using System.Collections.ObjectModel;
using Windows.UI.Popups;
using BestillingApp.Model;
using BestillingApp.Persistency;

#endregion

namespace BestillingApp.Singleton
{
    internal class ItemSingleton
    {
        #region Constructor

        private ItemSingleton()
        {
        }

        #endregion

        #region LoadItemAsync

        public async void LoadItemsAsync()
        {
            try
            {
                var items = await PersistencyService.LoadItemsFromJsonAsync();
                if (items == null)
                    return;
                if (items.Count == 0)
                    await new MessageDialog("Der findes nogen items i databasen").ShowAsync();
                else
                    foreach (var item in items)
                        Items.Add(item);
            }
            catch (Exception ex)
            {
                new MessageDialog("Der kunne ikke oprettes forbindelse til databasen").ShowAsync();
                throw;
            }
        }

        #endregion

        #region Remove

        public void RemoveItem(Item i)
        {
            //Items.Remove(c);
            PersistencyService.DeleteItemAsync(i);
            //Hvis create og read er på samme side
            //LoadItemsAsync();
        }

        #endregion

        #region Instancefield

        private static ItemSingleton _instance;
        private ObservableCollection<Item> _items;

        #endregion

        #region Properties

        public static ItemSingleton Instance => _instance ?? (_instance = new ItemSingleton());
        public ObservableCollection<Item> Items => _items ?? (_items = new ObservableCollection<Item>());

        #endregion

        #region Add

        public void AddItem(string name, string email, string address, int telNo, int zipcode, string city)
        {
            //var newItem = new Item(name, email, address, telNo, zipcode, city);
            //Items.Add(newItem);
            //PersistencyService.SaveItemAsJsonAsync(newItem);
            //Hvis create og read er på samme side
            //LoadItemsAsync();
        }

        public void AddItem(Item i)
        {
            //Item newItem = new Item(id, name, email, address, telNo, zipcode, city);
            //Items.Add(newItem);
            PersistencyService.SaveItemAsJsonAsync(i);
            //Hvis create og read er på samme side
            //LoadItemsAsync();
        }

        #endregion
    }
}