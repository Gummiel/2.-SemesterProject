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
        #region Constructor

        public MainViewModel()
        {
            OrderHandler = new OrderHandler(null,null,this,null,null);
            GasStationSingleton = GasStationSingleton.Instance;
            //Eksempel for hvordan det ser ud i 1 singleton
            //Singleton = CatalogSingleton.Instance;
            GasStationSingleton.LoadGasStationAsync();
        }

        #endregion

        #region Instancefield

        private ICommand _selectedGasStationCommand;
        private ICommand _selectedProductCommand;

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

        public ICommand SelectedProductCommand
        {
            get
            {
                return _selectedProductCommand ??
                       (_selectedProductCommand =
                           new RelayArgCommand<GasStation>(station => OrderHandler.SetSelectedGasStation(station)));
            }
            set { _selectedProductCommand = value; }
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