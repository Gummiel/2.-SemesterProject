#region References

using System;
using System.Collections.ObjectModel;
using Windows.UI.Popups;
using BestillingApp.Model;
using BestillingApp.Persistency;

#endregion

namespace BestillingApp.Singleton
{
    internal class ItemTypeSingleton
    {
        #region Constructor

        private ItemTypeSingleton()
        {
        }

        #endregion

        #region LoadItemTypeAsync

        public async void LoadItemTypesAsync()
        {
            try
            {
                var itemtypes = await PersistencyService.LoadItemTypesFromJsonAsync();
                if (itemtypes == null)
                    return;
                if (itemtypes.Count == 0)
                    await new MessageDialog("Der findes nogen itemtypes i databasen").ShowAsync();
                else
                    foreach (var itemtype in itemtypes)
                        ItemTypes.Add(itemtype);
            }
            catch (Exception ex)
            {
                new MessageDialog("Der kunne ikke oprettes forbindelse til databasen").ShowAsync();
                throw;
            }
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

        #region Instancefield

        private static ItemTypeSingleton _instance;
        private ObservableCollection<ItemType> _itemtypes;

        #endregion

        #region Properties

        public static ItemTypeSingleton Instance => _instance ?? (_instance = new ItemTypeSingleton());

        public ObservableCollection<ItemType> ItemTypes
            => _itemtypes ?? (_itemtypes = new ObservableCollection<ItemType>());

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