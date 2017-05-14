using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BestillingApp.Model;
using BestillingApp.ViewModel;

namespace BestillingApp.Handler
{
    class MainPageHandler
    {
        public MainViewModel MainViewModel { get; set; }

        public MainPageHandler(MainViewModel mainViewModel)
        {
            MainViewModel = mainViewModel;
        }

        public void SetSelectedGasStation(GasStation g)
        {
            MainViewModel.SelectedGasStation = g;
        }
    }
}
