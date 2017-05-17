using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BestillingApp.ViewModel;

namespace BestillingApp.Handler
{
    class LoginHandler
    {
        public LoginViewModel LoginViewModel { get; set; }

        public LoginHandler(LoginViewModel loginViewModel)
        {
            LoginViewModel = loginViewModel;
        }

        public void Login()
        {
            //login
        }
    }
}
