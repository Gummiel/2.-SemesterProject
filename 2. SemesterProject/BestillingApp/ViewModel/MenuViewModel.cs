#region References

using BestillingApp.Handler;
using BestillingApp.Singleton;

#endregion

namespace BestillingApp.ViewModel
{
    internal class MenuViewModel
    {
        #region Constructor

        public MenuViewModel()
        {
            OrderHandler = new OrderHandler(null, this, null);
            ItemTypeSingleton = ItemTypeSingleton.Instance;
            ItemSingleton = ItemSingleton.Instance;
            //Eksempel for hvordan det ser ud i 1 singleton
            //Singleton = CatalogSingleton.Instance;
            ItemTypeSingleton.LoadItemTypesAsync();
            ItemSingleton.LoadItemsAsync();
        }

        #endregion

        #region Properties

        public OrderHandler OrderHandler { get; set; }
        public ItemTypeSingleton ItemTypeSingleton { get; set; }
        public ItemSingleton ItemSingleton { get; set; }
        public static string SelectedGasStation { get; set; } = "";

        #endregion
    }
}