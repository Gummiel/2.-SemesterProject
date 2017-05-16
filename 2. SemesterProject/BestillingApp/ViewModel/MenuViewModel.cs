#region References

using System.Collections.Generic;
using System.Windows.Input;
using BestillingApp.Handler;
using BestillingApp.Model;
using BestillingApp.Singleton;
using ZPointApp.Common;

#endregion

namespace BestillingApp.ViewModel
{
    internal class MenuViewModel
    {
        #region Constructor

        public MenuViewModel()
        {
            OrderHandler = new OrderHandler(null, this);
            ItemTypeSingleton = ItemTypeSingleton.Instance;
            ItemSingleton = ItemSingleton.Instance;
            //Eksempel for hvordan det ser ud i 1 singleton
            //Singleton = CatalogSingleton.Instance;
            ItemTypeSingleton.LoadItemTypesAsync();
            ItemSingleton.LoadItemsAsync();
        }

        #endregion

        #region Instancefield

        private List<Item> _itemList;
        private ICommand _selectedItemTypeCommand;

        #endregion

        #region Properties

        public ICommand SelectedItemTypeCommand
        {
            get
            {
                return _selectedItemTypeCommand ??
                       (_selectedItemTypeCommand =
                           new RelayArgCommand<ItemType>(itemtype => OrderHandler.SetSelectedItemType(itemtype)));
            }
            set { _selectedItemTypeCommand = value; }
        }

        public static ItemType SelectedItemType { get; set; }

        public List<Item> ItemList
        {
            get { return _itemList ?? (_itemList = new List<Item>()); }
            set { _itemList = value; }
        }

        public OrderHandler OrderHandler { get; set; }
        public ItemTypeSingleton ItemTypeSingleton { get; set; }
        public ItemSingleton ItemSingleton { get; set; }
        public static string SelectedGasStation { get; set; } = "";

        #endregion
    }
}