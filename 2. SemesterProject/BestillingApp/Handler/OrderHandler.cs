#region References

using BestillingApp.Model;
using BestillingApp.ViewModel;

#endregion

namespace BestillingApp.Handler
{
    internal class OrderHandler
    {
        #region Constructor

        public OrderHandler(MainViewModel mainViewModel, MenuViewModel menuViewModel)
        {
            MainViewModel = mainViewModel;
            MenuViewModel = menuViewModel;
        }

        #endregion

        public void SetSelectedGasStation(GasStation g)
        {
            SelectedGasStation = g;
        }

        #region Properties

        public MainViewModel MainViewModel { get; set; }
        public MenuViewModel MenuViewModel { get; set; }
        private GasStation SelectedGasStation { get; set; }

        #endregion
    }
}