#region References

using System.Collections.Generic;
using BestillingApp.Model;
using BestillingApp.ViewModel;

#endregion

namespace BestillingApp.Handler
{
    internal class OrderHandler
    {
        private List<Item> _selectedItems;

        #region Constructor

        public OrderHandler(MainViewModel mainViewModel, MenuViewModel menuViewModel, ShoppingViewModel shoppingViewModel)
        {
            MainViewModel = mainViewModel;
            MenuViewModel = menuViewModel;
            ShoppingViewModel = shoppingViewModel;
        }

        #endregion

        public void SetSelectedGasStation(GasStation g)
        {
            SelectedGasStation = g;
            MenuViewModel.SelectedGasStation = g.ID + " - " + g.Name;
        }
        public void SetSelectedItems(Item i)
        {
            SelectedItems.Add(i);
        }

        #region Properties

        public MainViewModel MainViewModel { get; set; }
        public MenuViewModel MenuViewModel { get; set; }
        public ShoppingViewModel ShoppingViewModel { get; set; }
        private GasStation SelectedGasStation { get; set; }
        public List<Item> SelectedItems => _selectedItems ?? (_selectedItems = new List<Item>());

        #endregion
    }
}