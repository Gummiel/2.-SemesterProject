#region References

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.UI.Popups;
using BestillingApp.Model;
using BestillingApp.ViewModel;

#endregion

namespace BestillingApp.Handler
{
    internal class OrderHandler
    {
        #region Constructor

        public OrderHandler(ReviewViewModel reviewViewModel, OrderViewModel orderViewModel, MainViewModel mainViewModel,
            MenuViewModel menuViewModel, PaymentViewModel paymentViewModel)
        {
            ReviewViewModel = reviewViewModel;
            OrderViewModel = orderViewModel;
            MainViewModel = mainViewModel;
            MenuViewModel = menuViewModel;
            PaymentViewModel = paymentViewModel;
        }

        #endregion

        public async Task<bool> Pay(string textBoxAccountHolder, string textBoxExpireDateMonth,
            string textBoxExpireDateYear, string textBoxCvcNumber, string textBoxCreditCardNumber)
        {
            if ((textBoxAccountHolder != "") && (textBoxExpireDateMonth != "") && (textBoxExpireDateYear != "") &&
                (textBoxCvcNumber != "") && (textBoxCreditCardNumber != ""))
            {
                var onlynumbers = new Regex("[0-9]");
                var onlyletters = new Regex("^[a-zA-Z]*$");
                if (!onlyletters.IsMatch(textBoxAccountHolder) || !onlynumbers.IsMatch(textBoxCreditCardNumber) ||
                    !onlynumbers.IsMatch(textBoxCvcNumber))
                {
                    if (!onlyletters.IsMatch(textBoxAccountHolder))
                        await new MessageDialog("DER MÅ IKKE VÆRE TAL I KORTHOLDER").ShowAsync();
                    if (!onlynumbers.IsMatch(textBoxCreditCardNumber))
                        await new MessageDialog("DER MÅ IKKE VÆRE BOGSTAVER I KORTNUMMER").ShowAsync();
                    if (!onlynumbers.IsMatch(textBoxCvcNumber))
                        await new MessageDialog("DER MÅ IKKE VÆRE BOGSTAVER I CVC").ShowAsync();
                    if (!onlynumbers.IsMatch(textBoxExpireDateMonth))
                        await new MessageDialog("DER MÅ IKKE VÆRE BOGSTAVER I MÅNED").ShowAsync();
                    if (!onlynumbers.IsMatch(textBoxExpireDateYear))
                        await new MessageDialog("DER MÅ IKKE VÆRE BOGSTAVER I ÅRSTAL").ShowAsync();
                }
                else
                {
                    return true;
                }
            }
            else
            {
                await new MessageDialog("DER ER FELTER SOM IKKE ER UDFYLDT").ShowAsync();
            }
            return false;
        }

        #region Method

        public void SetSelectedGasStation(GasStation g)
        {
            SelectedGasStation = g;
        }

        public void SetSelectedProductCatagory(ProductCatagory i)
        {
            MenuViewModel.SelectedProductCatagory = i;
            var products = MenuViewModel.ProductSingleton.Products.Where(product => product.FK_ProductCatagory == i.ID).ToList();

            //var products = new List<Product>();
            //foreach (var product in MenuViewModel.ProductSingleton.Products)
            //{
            //    if (product.FK_ProductCatagory == i.ID)
            //    {
            //        products.Add(product);
            //    }
            //}

            MenuViewModel.ProductList = new ObservableCollection<Product>();
            foreach (var prod in products)
                MenuViewModel.ProductList.Add(prod);
        }


        public async void AddSelectedProductToOrderItems(Product p)
        {
            if (p == null)
                return;
            MenuViewModel.SelectedProduct = p;
            MenuViewModel.OrderSingleton.OrderItems.Add(p);
            await new MessageDialog(p.Brand + " " + p.Name + " ER BLEVET TILFØJET TIL KURVEN!").ShowAsync();
            MenuViewModel.OrderItemCount = MenuViewModel.OrderSingleton.OrderItems.Count;
        }

        public void RemoveSelectedProductToOrderItems(Product p)
        {
            if (p == null)
                return;
            OrderViewModel.SelectedOrderItem = p;
            ConfirmRemoveSelectedProductToOrderItems("ER DU SIKKER PÅ AT DU VIL SLETTE " + p.Brand + " " + p.Name + "?");
        }

        public async void ConfirmRemoveSelectedProductToOrderItems(string message)
        {
            // Create the message dialog and set its content
            var messageDialog = new MessageDialog(message);

            messageDialog.Commands.Add(new UICommand("JA", ConfirmedRemoveSelectedProductToOrderItems));
            messageDialog.Commands.Add(new UICommand("NEJ", null));

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
                OrderViewModel.OrderSingleton.OrderItems.Remove(OrderViewModel.SelectedOrderItem);
            }
            catch (Exception ex)
            {
                StatusRemoveSelectedProductToOrderItems("Der skete en fejl under sletning, prøv igen." + ex);
                throw;
            }
            finally
            {
                StatusRemoveSelectedProductToOrderItems("Sletning af " + OrderViewModel.SelectedOrderItem.Brand + " " +
                                                        OrderViewModel.SelectedOrderItem.Name + " blev fuldført");
            }
        }

        public async void StatusRemoveSelectedProductToOrderItems(string message)
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

        public void GetReviews()
        {
            var reviews =
                ReviewViewModel.ReviewSingleton.Reviews.Where(review => review.FK_GasStation == SelectedGasStation.ID)
                    .ToList();
            //Skal få customer info på reviews
            //var firstOrDefault = ReviewViewModel.CustomerSingleton.Customers.Where(customer => customer.ID == reviews.Where(review => review.FK_Customer == customer.ID).FK_Customer);
            ReviewViewModel.ReviewList = new ObservableCollection<Review>();
            foreach (var rev in reviews)
                ReviewViewModel.ReviewList.Add(rev);
        }

        #endregion

        #region Properties

        public PaymentViewModel PaymentViewModel { get; set; }
        public OrderViewModel OrderViewModel { get; set; }
        public MainViewModel MainViewModel { get; set; }
        public MenuViewModel MenuViewModel { get; set; }
        public static GasStation SelectedGasStation { get; set; }
        public ReviewViewModel ReviewViewModel { get; set; }

        #endregion
    }
}