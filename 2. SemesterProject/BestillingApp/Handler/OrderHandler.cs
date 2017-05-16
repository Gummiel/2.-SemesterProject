﻿#region References

using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Popups;
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

        #region Properties

        public MainViewModel MainViewModel { get; set; }
        public MenuViewModel MenuViewModel { get; set; }
        private GasStation SelectedGasStation { get; set; }

        #endregion
    }
}