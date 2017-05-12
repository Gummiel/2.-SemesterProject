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
        private ObservableCollection<Customer> _customers;

        #endregion

        #region Constructor

        private CustomerSingleton()
        {
        }

        #endregion

        #region LoadCustomerAsync

        public async void LoadCustomersAsync()
        {
            var customers = await PersistencyService.LoadCustomersFromJsonAsync();
            if(customers != null)
                foreach(var cust in customers)
                    Customers.Add(cust);
        }

        #endregion

        #region Remove

        public void RemoveCustomer(Customer c)
        {
            //Customers.Remove(c);
            PersistencyService.DeleteCustomerAsync(c);
            //Hvis create og read er på samme side
            //LoadCustomersAsync();
        }

        #endregion

        #region Properties

        public static CustomerSingleton Instance => _instance ?? (_instance = new CustomerSingleton());

        public ObservableCollection<Customer> Customers => _customers ?? (_customers = new ObservableCollection<Customer>());

        #endregion

        #region Add

        public void AddCustomer(string name, string email, string address, int telNo, int zipcode, string city)
        {
            //var newCustomer = new Customer(name, email, address, telNo, zipcode, city);
            //Customers.Add(newCustomer);
            //PersistencyService.SaveCustomerAsJsonAsync(newCustomer);
            //Hvis create og read er på samme side
            //LoadCustomersAsync();
        }

        public void AddCustomer(Customer c)
        {
            //Customer newCustomer = new Customer(id, name, email, address, telNo, zipcode, city);
            //Customers.Add(newCustomer);
            PersistencyService.SaveCustomerAsJsonAsync(c);
            //Hvis create og read er på samme side
            //LoadCustomersAsync();
        }

        #endregion
    }
}