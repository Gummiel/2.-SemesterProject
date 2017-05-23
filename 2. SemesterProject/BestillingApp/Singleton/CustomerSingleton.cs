#region References

using System;
using System.Collections.ObjectModel;
using Windows.UI.Popups;
using BestillingApp.Model;
using BestillingApp.Persistency;

#endregion

namespace BestillingApp.Singleton
{
    internal class CustomerSingleton
    {
        #region Constructor

        private CustomerSingleton()
        {
        }

        #endregion

        #region LoadCustomerAsync

        public async void LoadCustomersAsync()
        {
            if (Customers.Count > 0)
                Customers.Clear();
            try
            {
                var loadedcustomers = await PersistencyService.LoadCustomersFromJsonAsync();
                if (loadedcustomers == null)
                    return;
                if (loadedcustomers.Count == 0)
                    await new MessageDialog("Der findes nogen customers i databasen").ShowAsync();
                else
                    foreach (var cust in loadedcustomers)
                        Customers.Add(cust);
            }
            catch (Exception ex)
            {
                new MessageDialog("Der kunne ikke oprettes forbindelse til databasen").ShowAsync();
                throw;
            }
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

        #region Instancefield

        private static CustomerSingleton _instance;
        private ObservableCollection<Customer> _customers;

        #endregion

        #region Properties

        public static CustomerSingleton Instance => _instance ?? (_instance = new CustomerSingleton());

        public ObservableCollection<Customer> Customers
            => _customers ?? (_customers = new ObservableCollection<Customer>());

        #endregion

        #region Add

        public void AddCustomer(string name, string email, string password, string address, int telNo, int zipcode, string city)
        {
            //var newCustomer = new Customer(name, email, password, address, telNo, zipcode, city);
            //Customers.Add(newCustomer);
            //PersistencyService.SaveCustomerAsJsonAsync(newCustomer);
            //Hvis create og read er på samme side
            //LoadCustomersAsync();
        }

        public void AddCustomer(Customer c)
        {
            //Customer newCustomer = new Customer(id, name, email, address, telNo, zipcode, city);
            Customers.Add(c);
            PersistencyService.SaveCustomerAsJsonAsync(c);
            //Hvis create og read er på samme side
            //LoadCustomersAsync();
        }

        #endregion
    }
}