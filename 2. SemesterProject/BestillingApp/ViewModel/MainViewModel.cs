#region References

using System.Windows.Input;
using BestillingApp.Handler;
using BestillingApp.Model;
using BestillingApp.Singleton;
using ZPointApp.Common;

#endregion

namespace BestillingApp.ViewModel
{
    internal class MainViewModel
    {
        #region Instancefield

        private ICommand _selectedGasStationCommand;

        #endregion

        #region Constructor

        public MainViewModel()
        {
            OrderHandler = new OrderHandler(this, null);
            GasStationSingleton = GasStationSingleton.Instance;
            //Eksempel for hvordan det ser ud i 1 singleton
            //Singleton = CatalogSingleton.Instance;
            GasStationSingleton.LoadGasStationAsync();
        }

        #endregion

        #region Properties

        public ICommand SelectedGasStationCommand
        {
            get
            {
                return _selectedGasStationCommand ??
                       (_selectedGasStationCommand =
                           new RelayArgCommand<GasStation>(station => OrderHandler.SetSelectedGasStation(station)));
            }
            set { _selectedGasStationCommand = value; }
        }

        public OrderHandler OrderHandler { get; set; }
        public static CustomerSingleton CustomerSingleton { get; set; }
        public static GasStationSingleton GasStationSingleton { get; set; }
        public static ReceiptSingleton ReceiptSingleton { get; set; }
        public static ReviewSingleton ReviewSingleton { get; set; }
        public static OrderSingleton OrderSingleton { get; set; }

        #endregion
    }
}