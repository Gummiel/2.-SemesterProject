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
        public void SetSelectedProductCatagory(ProductCatagory i)
        {
            MenuViewModel.SelectedProductCatagory = i;
            var products =
                MenuViewModel.ProductSingleton.Products.Where(item => item.FK_ProductCatagory == i.ID).ToList();

            foreach (var prod in products)
                MenuViewModel.ProductList.Add(prod);
        }

        #region Properties

        public MainViewModel MainViewModel { get; set; }
        public MenuViewModel MenuViewModel { get; set; }
        private GasStation SelectedGasStation { get; set; }

        #endregion
    }
}