using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BestillingApp.Model;
using BestillingApp.Singleton;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace BestillingsTest
{
    [TestClass]
    public class UnitTest1
    {
        // create instances for testing
        private Customer _customer;
        private ObservableCollection<Customer> customers;

        [TestInitialize]
        public void StartTest()
        {
            // initializing those variables above

            // set expected value of the customer
            _customer = new Customer("Ibrahim Delice", "ibo@gmail.com", "1234", "Hansvej 1", 48278972, 4300, "Holbæk");

            customers = new ObservableCollection<Customer>();
        }

        [TestMethod]
        public void TestGet()
        {
            //CustomerSingleton.Instance.LoadCustomersAsync();
            //customers = CustomerSingleton.Instance.Customers;
            //int before = customers.Count;

            //CustomerSingleton.Instance.AddCustomer(_customer);
            //CustomerSingleton.Instance.LoadCustomersAsync();
            //customers = CustomerSingleton.Instance.Customers;
            //int after = customers.Count;

            //if (before == after)
            //{
            //    Assert.Fail();
            //}
            //Assert.AreEqual(_customer);


            //CustomerSingleton.Instance.RemoveCustomer(_customer);
            try
            {
                // getting singleton instance
                CustomerSingleton _customerSingleton = CustomerSingleton.Instance;

                // getting list from the singleton
                customers = _customerSingleton.Customers;

                // getting the customer with ID = 1
                Customer _dbCustomer = customers.FirstOrDefault(x => x.ID == 1);

                // match those values. here just the name property
                Assert.AreEqual(_customer.Name, _dbCustomer.Name);
            }
            catch (Exception)
            {

                Assert.Fail();
            }


        }
    }
}
