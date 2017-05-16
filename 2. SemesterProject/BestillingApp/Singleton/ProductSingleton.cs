#region References

using System;
using System.Collections.ObjectModel;
using Windows.UI.Popups;
using BestillingApp.Model;
using BestillingApp.Persistency;

#endregion

namespace BestillingApp.Singleton
{
    internal class ProductSingleton
    {
        #region Constructor

        private ProductSingleton()
        {
        }

        #endregion

        #region LoadItemAsync

        public async void LoadItemsAsync()
        {
            if (Products.Count > 0)
                Products.Clear();
            try
            {
                var loadedproducts = await PersistencyService.LoadProductsFromJsonAsync();
                if (loadedproducts == null)
                    return;
                if (loadedproducts.Count == 0)
                    await new MessageDialog("Der findes nogen products i databasen").ShowAsync();
                else
                    foreach (var prod in loadedproducts)
                        Products.Add(prod);
            }
            catch (Exception ex)
            {
                new MessageDialog("Der kunne ikke oprettes forbindelse til databasen").ShowAsync();
                throw;
            }
        }

        #endregion

        #region Remove

        public void RemoveItem(Product p)
        {
            //Items.Remove(c);
            PersistencyService.DeleteProductAsync(p);
            //Hvis create og read er på samme side
            //LoadItemsAsync();
        }

        #endregion

        #region Instancefield

        private static ProductSingleton _instance;
        private ObservableCollection<Product> _products;

        #endregion

        #region Properties

        public static ProductSingleton Instance => _instance ?? (_instance = new ProductSingleton());
        public ObservableCollection<Product> Products => _products ?? (_products = new ObservableCollection<Product>());

        #endregion

        #region Add

        public void AddProduct(string name, string email, string address, int telNo, int zipcode, string city)
        {
            //var newItem = new Item(name, email, address, telNo, zipcode, city);
            //Items.Add(newItem);
            //PersistencyService.SaveItemAsJsonAsync(newItem);
            //Hvis create og read er på samme side
            //LoadItemsAsync();
        }

        public void AddProduct(Product p)
        {
            //Item newItem = new Item(id, name, email, address, telNo, zipcode, city);
            //Items.Add(newItem);
            PersistencyService.SaveProductAsJsonAsync(p);
            //Hvis create og read er på samme side
            //LoadItemsAsync();
        }

        #endregion
    }
}