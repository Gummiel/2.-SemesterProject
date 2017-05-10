#region References

using System.Collections.ObjectModel;
using BestillingApp.Model;
using BestillingApp.Persistency;

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

        #region LoadCustomerAsync

        public async void LoadCustomersAsync()
        {
            var customers = await PersistencyService.LoadCustomersFromJsonAsync();
            if (customers != null)
            {
                foreach (var cust in customers)
                {
                    customers.Add(cust);
                }
            }
            else
            {
                //possibly exception
            }
        }

        #endregion

        #region Add

        public void AddCustomer(int id, string name, string email, string address, int telNo, int zipcode, string city)
        {
            Customer newCustomer = new Customer(id, name, email, address, telNo, zipcode, city);
            Customers.Add(newCustomer);
            PersistencyService.SaveCustomerAsJsonAsync(newCustomer);
        }

        #endregion

        #region Remove

        public void RemoveCustomer (Customer c)
        {
            Customers.Remove(c);
            PersistencyService.DeleteCustomerAsync(c);
        }

        #endregion
    }
}