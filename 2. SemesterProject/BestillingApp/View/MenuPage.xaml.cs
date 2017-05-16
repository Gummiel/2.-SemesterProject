#region References

using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Controls;
using BestillingApp.Model;
using BestillingApp.ViewModel;

#endregion

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BestillingApp.View
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private void ListViewProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            #region Methodcontent

            var productlist = new List<string>();
            MenuViewModel.SelectedProduct = new List<Product>();
            if (productlist.Count > 0)
                productlist.Clear();
            productlist.AddRange(from Product selectedproduct in ListViewProducts.SelectedItems
                select selectedproduct.Name);
            foreach (var selecteditem in ListViewProducts.SelectedItems)
            {
                var selectedproduct = (Product) selecteditem;
                MenuViewModel.SelectedProduct.Add(selectedproduct);
            }

            var selectedProducts = string.Join(", ", productlist.ToArray());
            MenuViewModel.SelectedProducts = selectedProducts;

            #endregion
        }
    }
}