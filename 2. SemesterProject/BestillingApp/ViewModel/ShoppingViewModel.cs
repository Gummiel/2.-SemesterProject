#region References

using System.Windows.Input;
using BestillingApp.Handler;
using BestillingApp.Model;
using BestillingApp.Singleton;
using ZPointApp.Common;

#endregion

namespace BestillingApp.ViewModel
{
    internal class ShoppingViewModel
    {
        #region Instancefield

        private ICommand _selectedItemCommand;

        #endregion

        #region Constructor

        public ShoppingViewModel()
        {
            OrderHandler = new OrderHandler(null, null, this);
            ItemSingleton = ItemSingleton.Instance;
            //Eksempel for hvordan det ser ud i 1 singleton
            //Singleton = CatalogSingleton.Instance;
            ItemSingleton.LoadItemsAsync();
        }

        #endregion

        #region Properties

        public ICommand SelectedItemCommand
        {
            get
            {
                return _selectedItemCommand ??
                       (_selectedItemCommand =
                           new RelayArgCommand<Item>(item => OrderHandler.SetSelectedItems(item)));
            }
            set { _selectedItemCommand = value; }
        }

        public static GasStation SelectedGasStation { get; set; }

        public OrderHandler OrderHandler { get; set; }
        //Eksempel for hvordan det ser ud i 1 singleton
        //public static CatalogSingleton Singleton { get; set; }
        public ItemSingleton ItemSingleton { get; set; }

        #endregion
    }
}