using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BestillingApp.Model;
using BestillingApp.ViewModel;

namespace BestillingApp.Handler
{
    class RegisterHandler
    {
        public RegisterViewModel RegisterViewModel { get; set; }

        public RegisterHandler(RegisterViewModel registerViewModel)
        {
            RegisterViewModel = registerViewModel;
        }
        public void Register()
        {
            Customer aCustomer = new Customer(RegisterViewModel.Name, RegisterViewModel.Email, RegisterViewModel.Password, RegisterViewModel.Address, RegisterViewModel.TelNo, RegisterViewModel.Zipcode, RegisterViewModel.City);
            RegisterViewModel.CustomerSingleton.AddCustomer(aCustomer);
        }
    }
}
