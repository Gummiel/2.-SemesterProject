﻿#region References

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

        #region Remove

        public void RemoveProductCatagory(ProductCatagory c)
        {
            //ProductCatagorys.Remove(c);
            PersistencyService.DeleteProductCatagoryAsync(c);
            //Hvis create og read er på samme side
            //LoadProductCatagorysAsync();
        }

        #endregion

        #region LoadProductCatagoryAsync

        public async void LoadProductCatagoryAsync()
        {
            if (ProductCatagories.Count > 0)
                ProductCatagories.Clear();
            try
            {
                var loadedproductcatagories = await PersistencyService.LoadProductCatagoriesFromJsonAsync();
                if (loadedproductcatagories == null)
                    return;
                if (loadedproductcatagories.Count == 0)
                    LoadStatus("Der findes nogen itemtypes i databasen");
                else
                    foreach (var prodcat in loadedproductcatagories)
                        ProductCatagories.Add(prodcat);
            }
            catch (Exception)
            {
                LoadStatus("Der kunne ikke oprettes forbindelse til databasen");
                throw;
            }
        }

        public async void LoadStatus(string message)
        {
            // Create the message dialog and set its content
            var messageDialog = new MessageDialog(message);

            messageDialog.Commands.Add(new UICommand("OK", null));

            // Set the command that will be invoked by default
            messageDialog.DefaultCommandIndex = 0;

            // Set the command to be invoked when escape is pressed
            messageDialog.CancelCommandIndex = 0;

            // Show the message dialog
            await messageDialog.ShowAsync();
        }

        #endregion

        #region Instancefield

        private static ProductCatagorySingleton _instance;
        private ObservableCollection<ProductCatagory> _productcatagories;

        #endregion

        #region Properties

        public static ProductCatagorySingleton Instance => _instance ?? (_instance = new ProductCatagorySingleton());

        public ObservableCollection<ProductCatagory> ProductCatagories
            => _productcatagories ?? (_productcatagories = new ObservableCollection<ProductCatagory>());

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