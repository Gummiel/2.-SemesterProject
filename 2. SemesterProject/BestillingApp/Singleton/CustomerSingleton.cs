#region References

using System.Collections.ObjectModel;
using BestillingApp.Model;

#endregion

namespace BestillingApp.Singleton
{
    internal class CustomerSingleton
    {
        #region Instancefield

        private static CustomerSingleton _instance;

        #endregion

        #region Constructor

        private CustomerSingleton()
        {
        }

        #endregion

        #region Properties

        public static CustomerSingleton Instance => _instance ?? (_instance = new CustomerSingleton());

        public ObservableCollection<Customer> Customers = new ObservableCollection<Customer>();

        #endregion
    }
}