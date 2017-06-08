#region References

using System;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Popups;
using BestillingApp.Model;
using BestillingApp.Persistency;

#endregion

namespace BestillingApp.Singleton
{
    public class CustomerSingleton
    {
        #region Constructor

        private CustomerSingleton()
        {
            //LoadCustomersAsync();
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

        public string GetName(string email)
        {
            foreach (var e in Customers)
                if (e.Email == email)
                    return e.Name;
            return "findes ikke";
        }

        #region LoadCustomerAsync

        public async void LoadCustomersAsync()
        {
            if (Customers.Count > 0)
                Customers.Clear();
            try
            {
                var loadedcustomers = await PersistencyService.LoadCustomersFromJsonAsync();

                //check if # observablecollection GasStations # is different from # var loadedgasstations #
                var firstNotSecond = Customers.Except(loadedcustomers).ToList();
                //check if # var loadedgasstations # is different from # observablecollection GasStations #
                var secondNotFirst = loadedcustomers.Except(Customers).ToList();

                if (loadedcustomers == null)
                    return;
                if (loadedcustomers.Count == 0)
                    LoadStatus("Der findes nogen customers i databasen");
                if (!firstNotSecond.Any() && !secondNotFirst.Any())
                    return;
                foreach (var cust in loadedcustomers)
                    Customers.Add(cust);
            }
            catch (Exception)
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

        public void AddCustomer(string name, string email, string password, string address, int telNo, int zipcode,
            string city)
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
            //LoadCustomersAsync();
        }

        #endregion
    }
}