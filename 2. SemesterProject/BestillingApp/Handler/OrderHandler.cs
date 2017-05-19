#region References

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
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

        public OrderHandler(OrderViewModel orderViewModel, MainViewModel mainViewModel, MenuViewModel menuViewModel)
        {
            OrderViewModel = orderViewModel;
            MainViewModel = mainViewModel;
            MenuViewModel = menuViewModel;
        }

        #endregion

        public void SetSelectedGasStation(GasStation g)
        {
            SelectedGasStation = g;
        }

        public void SetSelectedProductCatagory(ProductCatagory i)
        {
            MenuViewModel.SelectedProductCatagory = i;
            var products =
                MenuViewModel.ProductSingleton.Products.Where(product => product.FK_ProductCatagory == i.ID).ToList();
            MenuViewModel.ProductList = new ObservableCollection<Product>();
            foreach(var prod in products)
                MenuViewModel.ProductList.Add(prod);
        }

        public async void AddSelectedProductToOrderItems(Product p)
        {
            MenuViewModel.SelectedProduct = p;
            MenuViewModel.OrderSingleton.OrderItems.Add(p);
            await new MessageDialog(p.Brand + " " + p.Name + " ER BLEVET TILFØJET TIL KURVEN!").ShowAsync();
            MenuViewModel.OrderItemCount = MenuViewModel.OrderSingleton.OrderItems.Count;
        }
        public void RemoveSelectedProductToOrderItems(Product p)
        {
            MenuViewModel.SelectedOrderItem = p;
            ConfirmRemoveSelectedProductToOrderItems("Are you sure you want to delete?");
        }

        public async void ConfirmRemoveSelectedProductToOrderItems(string message)
        {
            // Create the message dialog and set its content
            var messageDialog = new MessageDialog(message);

            messageDialog.Commands.Add(new UICommand("YES", ConfirmedRemoveSelectedProductToOrderItems));
            messageDialog.Commands.Add(new UICommand("NO", null));

            // Set the command that will be invoked by default
            messageDialog.DefaultCommandIndex = 0;

            // Set the command to be invoked when escape is pressed
            messageDialog.CancelCommandIndex = 1;

            // Show the message dialog
            await messageDialog.ShowAsync();
        }

        private void ConfirmedRemoveSelectedProductToOrderItems(IUICommand command)
        {
            try
            {
                OrderViewModel.OrderSingleton.OrderItems.Remove(MenuViewModel.SelectedProduct);
            }
            catch(Exception ex)
            {
                StatusRemoveSelectedProductToOrderItems("There was an error with the remove, try again." + ex);
                throw;
            }
        }

        public async void StatusRemoveSelectedProductToOrderItems(string message)
        {
            // Create the message dialog and set its content
            var messageDialog = new MessageDialog(message);

            messageDialog.Commands.Add(new UICommand("OK", null));

            // Set the command that will be invoked by default
            messageDialog.DefaultCommandIndex = 0;

            // Show the message dialog
            await messageDialog.ShowAsync();
        }

        #region Properties

        public OrderViewModel OrderViewModel { get; set; }
        public MainViewModel MainViewModel { get; set; }
        public MenuViewModel MenuViewModel { get; set; }
        public static GasStation SelectedGasStation { get; set; }

        #endregion
    }
}