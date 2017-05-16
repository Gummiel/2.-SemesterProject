#region References

using System.Linq;
using BestillingApp.Model;
using BestillingApp.ViewModel;

#endregion

namespace BestillingApp.Handler
{
    internal class OrderHandler
    {
        #region Constructor

        public OrderHandler(MainViewModel mainViewModel, MenuViewModel menuViewModel)
        {
            MainViewModel = mainViewModel;
            MenuViewModel = menuViewModel;
        }

        #endregion

        public void SetSelectedGasStation(GasStation g)
        {
            SelectedGasStation = g;
            MenuViewModel.SelectedGasStation = g.ID + " - " + g.Name;
        }

        //public void SetSelectedItems(Item i)
        //{
        //    SelectedItems.Add(i);
        //}
        public void SetSelectedItemType(ItemType i)
        {
            MenuViewModel.SelectedItemType = i;
            var items = MenuViewModel.ItemSingleton.Items.Where(item => item.FK_ItemType == i.ID).ToList();

            foreach (var it in items)
                MenuViewModel.ItemList.Add(it);
        }

        #region Properties

        public MainViewModel MainViewModel { get; set; }
        public MenuViewModel MenuViewModel { get; set; }
        private GasStation SelectedGasStation { get; set; }

        #endregion
    }
}