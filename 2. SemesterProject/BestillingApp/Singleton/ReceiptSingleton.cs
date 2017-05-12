#region References

using System.Collections.ObjectModel;
using BestillingApp.Model;
using BestillingApp.Persistency;

#endregion

namespace BestillingApp.Singleton
{
    internal class ReceiptSingleton
    {
        #region Instancefield

        private static ReceiptSingleton _instance;
        private ObservableCollection<Receipt> _receipts;

        #endregion

        #region LoadReceiptAsync

        public async void LoadReceiptAsync()
        {
            var receipts = await PersistencyService.LoadReceiptFromJsonAsync();
            if (receipts != null)
                foreach (var rec in receipts)
                    Receipts.Add(rec);
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

        #region Constructor

        #endregion

        #region Properties

        public static ReceiptSingleton Instance => _instance ?? (_instance = new ReceiptSingleton());
        public ObservableCollection<Receipt> Receipts => _receipts ?? (_receipts = new ObservableCollection<Receipt>());

        #endregion

        #region Add

        public void AddReceipt(string name, string email, string address, int telNo, int zipcode, string city,
            double totalPrice, string description, int amount, double price)
        {
            var newReceipt = new Receipt(name, email, address, telNo, zipcode, city, totalPrice, description, amount,
                price);
            //Receipt.Add(newReceipt);
            PersistencyService.SaveReceiptAsJsonAsync(newReceipt);
            //Hvis create og read er på samme side
            //LoadReceiptAsync();
        }

        public void AddReceipt(Receipt r)
        {
            //Receipt newReceipt = new Receipt(name, email, address, telNo, zipcode, city, totalPrice, description, amount, price);
            //Receipt.Add(r);
            PersistencyService.SaveReceiptAsJsonAsync(r);
            //Hvis create og read er på samme side
            //LoadReceiptAsync();
        }

        #endregion
    }
}