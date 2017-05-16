#region References

using System;
using Windows.UI.Popups;
using BestillingApp.Model;
using BestillingApp.ViewModel;

#endregion

namespace BestillingApp.Handler
{
    internal class ReceiptHandler
    {
        //dette er en status for confirm 
        public async void ConfirmDeleteReceipt(string message)
        {
            // Create the message dialog and set its content
            var messageDialog = new MessageDialog(message);

            messageDialog.Commands.Add(new UICommand("YES", CreateReceiptConfirmed));
            messageDialog.Commands.Add(new UICommand("NO", null));

            // Set the command that will be invoked by default
            messageDialog.DefaultCommandIndex = 0;

            // Set the command to be invoked when escape is pressed
            messageDialog.CancelCommandIndex = 1;

            // Show the message dialog
            await messageDialog.ShowAsync();
        }

        //dette er en status for om fjernelsen af receipt gik eller ej.
        public async void DeleteStatus(string message)
        {
            // Create the message dialog and set its content
            var messageDialog = new MessageDialog(message);

            messageDialog.Commands.Add(new UICommand("OK", null));

            // Set the command that will be invoked by default
            messageDialog.DefaultCommandIndex = 0;

            // Show the message dialog
            await messageDialog.ShowAsync();
        }

        private void CreateReceiptConfirmed(IUICommand command)
        {
            try
            {
                var receipt = new Receipt("name", "email", "address", 12345678, 1234, "city", new decimal(0.0),
                    "description", 0, new decimal(0.0));
                PaymentViewModel.ReceiptSingleton.AddReceipt(receipt);
            }
            catch (Exception e)
            {
                DeleteStatus("There was an error with the create, try again." + e);
                throw;
            }
        }

        #region CreateReceipt

        //Når man trykker opret i view så kommer den her
        public void CreateReceipt()
        {
            //Receipt receipt = new Receipt("name", "email", "address", 12345678, 1234, "city", new decimal(0.0), "description", 0, new decimal(0.0));
            //PaymentViewModel.ReceiptSingleton.AddReceipt(receipt);
            try
            {
                var receipt = new Receipt("name", "email", "address", 12345678, 1234, "city", new decimal(0.0),
                    "description", 0, new decimal(0.0));
                PaymentViewModel.ReceiptSingleton.AddReceipt(receipt);
            }
            catch (Exception e)
            {
                CreateStatus("There was an error with the create, try again." + e);
                throw;
            }
        }

        //dette er en status for om oprettelsen af receipt gik eller ej.
        public async void CreateStatus(string message)
        {
            // Create the message dialog and set its content
            var messageDialog = new MessageDialog(message);

            messageDialog.Commands.Add(new UICommand("OK", null));

            // Set the command that will be invoked by default
            messageDialog.DefaultCommandIndex = 0;

            // Show the message dialog
            await messageDialog.ShowAsync();
        }

        #endregion
    }
}