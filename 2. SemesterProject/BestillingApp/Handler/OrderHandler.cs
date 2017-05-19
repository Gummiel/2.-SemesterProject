#region References

using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Popups;
using BestillingApp.Model;
using BestillingApp.Singleton;
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
        }

        public void SetSelectedProducts(Product p)
        {
            new MessageDialog(MenuViewModel.SelectedProducts).ShowAsync();
        }

        public void SetSelectedProductCatagory(ProductCatagory i)
        {
            MenuViewModel.SelectedProductCatagory = i;
            var products =
                MenuViewModel.ProductSingleton.Products.Where(product => product.FK_ProductCatagory == i.ID).ToList();
            MenuViewModel.ProductList = new ObservableCollection<Product>();
            foreach (var prod in products)
                MenuViewModel.ProductList.Add(prod);
        }

        public void SetSelectedProduct(Product i)
        {
            //MenuViewModel.SelectedProduct= i;
            MenuViewModel.OrderSingleton.OrderItems.Add(i);
                
     
        }
        #region Properties

        public MainViewModel MainViewModel { get; set; }
        public MenuViewModel MenuViewModel { get; set; }
        public static GasStation SelectedGasStation { get; set; }

        #endregion
    }
}