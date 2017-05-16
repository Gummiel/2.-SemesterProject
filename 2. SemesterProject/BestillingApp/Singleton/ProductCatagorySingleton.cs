#region References

using System;
using System.Collections.ObjectModel;
using Windows.UI.Popups;
using BestillingApp.Model;
using BestillingApp.Persistency;

#endregion

namespace BestillingApp.Singleton
{
    internal class ProductCatagorySingleton
    {
        #region Constructor

        private ProductCatagorySingleton()
        {
        }

        #endregion

        #region LoadProductCatagoryAsync

        public async void LoadProductCatagoryAsync()
        {
            if (ProductCatagorys.Count > 0)
                ProductCatagorys.Clear();
            try
            {
                var loadedproductcatagories = await PersistencyService.LoadProductCatagoriesFromJsonAsync();
                if (loadedproductcatagories == null)
                    return;
                if (loadedproductcatagories.Count == 0)
                    await new MessageDialog("Der findes nogen itemtypes i databasen").ShowAsync();
                else
                    foreach (var itemtype in loadedproductcatagories)
                        ProductCatagorys.Add(itemtype);
            }
            catch (Exception ex)
            {
                new MessageDialog("Der kunne ikke oprettes forbindelse til databasen").ShowAsync();
                throw;
            }
        }

        #endregion

        #region Remove

        public void RemoveProductCatagory(ProductCatagory c)
        {
            //ProductCatagorys.Remove(c);
            PersistencyService.DeleteProductCatagoryAsync(c);
            //Hvis create og read er på samme side
            //LoadProductCatagorysAsync();
        }

        #endregion

        #region Instancefield

        private static ProductCatagorySingleton _instance;
        private ObservableCollection<ProductCatagory> _itemtypes;

        #endregion

        #region Properties

        public static ProductCatagorySingleton Instance => _instance ?? (_instance = new ProductCatagorySingleton());

        public ObservableCollection<ProductCatagory> ProductCatagorys
            => _itemtypes ?? (_itemtypes = new ObservableCollection<ProductCatagory>());

        #endregion

        #region Add

        public void AddProductCatagory(string name, string email, string address, int telNo, int zipcode, string city)
        {
            //var newProductCatagory = new ProductCatagory(name, email, address, telNo, zipcode, city);
            //ProductCatagorys.Add(newProductCatagory);
            //PersistencyService.SaveProductCatagoryAsJsonAsync(newProductCatagory);
            //Hvis create og read er på samme side
            //LoadProductCatagorysAsync();
        }

        public void AddProductCatagory(ProductCatagory c)
        {
            //ProductCatagory newProductCatagory = new ProductCatagory(id, name, email, address, telNo, zipcode, city);
            //ProductCatagorys.Add(newProductCatagory);
            PersistencyService.SaveProductCatagoryAsJsonAsync(c);
            //Hvis create og read er på samme side
            //LoadProductCatagorysAsync();
        }

        #endregion
    }
}