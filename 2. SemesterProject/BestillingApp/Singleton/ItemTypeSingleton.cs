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
    class ItemTypeSingleton
    {

        #region Instancefield

        private static ItemTypeSingleton _instance;

        #endregion

        #region Constructor

        private ItemTypeSingleton()
        {
        }

        #endregion

        #region LoadItemTypeAsync

        public async void LoadItemTypesAsync()
        {
            var itemtypes = await PersistencyService.LoadItemTypesFromJsonAsync();
            if(itemtypes != null)
                foreach(var itemtype in itemtypes)
                    ItemTypes.Add(itemtype);
        }

        #endregion

        #region Remove

        public void RemoveItemType(ItemType c)
        {
            //ItemTypes.Remove(c);
            PersistencyService.DeleteItemTypeAsync(c);
            //Hvis create og read er på samme side
            //LoadItemTypesAsync();
        }

        #endregion

        #region Properties

        public static ItemTypeSingleton Instance => _instance ?? (_instance = new ItemTypeSingleton());

        public ObservableCollection<ItemType> ItemTypes = new ObservableCollection<ItemType>();

        #endregion

        #region Add

        public void AddItemType(string name, string email, string address, int telNo, int zipcode, string city)
        {
            //var newItemType = new ItemType(name, email, address, telNo, zipcode, city);
            //ItemTypes.Add(newItemType);
            //PersistencyService.SaveItemTypeAsJsonAsync(newItemType);
            //Hvis create og read er på samme side
            //LoadItemTypesAsync();
        }

        public void AddItemType(ItemType c)
        {
            //ItemType newItemType = new ItemType(id, name, email, address, telNo, zipcode, city);
            //ItemTypes.Add(newItemType);
            PersistencyService.SaveItemTypeAsJsonAsync(c);
            //Hvis create og read er på samme side
            //LoadItemTypesAsync();
        }

        #endregion
    }
}
