using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BestillingApp.Model;
using BestillingApp.Persistency;

namespace BestillingApp.Singleton
{
    class ItemSingleton
    {
        #region Instancefield

        private static ItemSingleton _instance;
        private ObservableCollection<Item> _items;

        #endregion

        #region Constructor

        private ItemSingleton()
        {
        }

        #endregion

        #region LoadItemAsync

        public async void LoadItemsAsync()
        {
            var items = await PersistencyService.LoadItemsFromJsonAsync();
            if(items != null)
                foreach(var item in items)
                    Items.Add(item);
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