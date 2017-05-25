#region References

using System;
using System.Collections.ObjectModel;
using Windows.UI.Popups;
using BestillingApp.Model;
using BestillingApp.Persistency;

#endregion

namespace BestillingApp.Singleton
{
    internal class ReceiptSingleton
    {
        #region LoadReceiptAsync

        public async void LoadReceiptAsync()
        {
            if(Receipts.Count > 0)
                Receipts.Clear();
            try
            {
                var loadedreceipts = await PersistencyService.LoadReceiptFromJsonAsync();
                if(loadedreceipts == null)
                    return;
                if(loadedreceipts.Count == 0)
                    LoadStatus("Der findes nogen receipts i databasen");
                else
                    foreach(var rec in loadedreceipts)
                        Receipts.Add(rec);
            }
            catch(Exception)
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

        #region Remove

        public void RemoveReceipt(Receipt r)
        {
            //Receipt.Remove(r);
            PersistencyService.DeleteReceiptAsync(r);
            //Hvis delete og read er på samme side
            //LoadReceiptAsync();
        }

        #endregion

        #region Add

        public void AddReceipt(Receipt r)
        {
            //Receipt.Add(r);
            PersistencyService.SaveReceiptAsJsonAsync(r);
            //Hvis create og read er på samme side
            //LoadReceiptAsync();
        }

        #endregion

        #region Instancefield

        private static ReceiptSingleton _instance;
        private ObservableCollection<Receipt> _receipts;

        #endregion

        #region Constructor

        #endregion

        #region Properties

        public static ReceiptSingleton Instance => _instance ?? (_instance = new ReceiptSingleton());
        public ObservableCollection<Receipt> Receipts => _receipts ?? (_receipts = new ObservableCollection<Receipt>());

        #endregion
    }
}