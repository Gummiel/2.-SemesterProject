#region References

using System.Collections.ObjectModel;
using BestillingApp.Model;
using BestillingApp.Persistency;

#endregion



namespace BestillingApp.Singleton
{
    class ReceiptSingleton
    {
        #region Instancefield

        private static ReceiptSingleton _instance;

        #endregion

        #region Constructor

        public ReceiptSingleton()
        {
            
        }

        #endregion

        #region Properties

        public static ReceiptSingleton Instance => _instance ?? (_instance = new ReceiptSingleton());

        public ObservableCollection<Receipt> Receipt = new ObservableCollection<Receipt>();


        #endregion

        #region LoadReceiptAsync

        public async void LoadReceiptAsync()
        {
            var receipts = await PersistencyService.LoadReceiptFromJsonAsync();
            if (receipts != null)
            {
                foreach (var rec in receipts)
                {
                    receipts.Add(rec);
                }
            }
            else
            {
                //possibly exception
            }
        }

        #endregion

        #region Add

        public void AddReceipt(string name, string email, string address, int telNo, int zipcode, string city,
            double totalPrice, string description, int amount, double price)
        {
            Receipt newReceipt = new Receipt(name, email, address, telNo, zipcode, city, totalPrice, description, amount,
                price);
            Receipt.Add(newReceipt);
            PersistencyService.SaveReceiptAsJsonAsync(newReceipt);
        }

        #endregion

        #region Remove

        public void RemoveReceipt(Receipt r)
        {
            Receipt.Remove(r);
            PersistencyService.DeleteReceiptAsync(r);
        }

        #endregion
    }
}
