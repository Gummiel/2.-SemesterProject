#region Directives

using System.Collections.ObjectModel;
using Bestillingsapp.Model;

#endregion

namespace Bestillingsapp.Singleton
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