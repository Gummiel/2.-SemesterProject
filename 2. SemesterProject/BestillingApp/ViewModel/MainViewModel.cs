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
            MainPageHandler = new MainPageHandler(this);
            CustomerSingleton = CustomerSingleton.Instance;
            GasStationSingleton = GasStationSingleton.Instance;
            ReceiptSingleton = ReceiptSingleton.Instance;
            ReviewSingleton = ReviewSingleton.Instance;
            OrderSingleton = OrderSingleton.Instance;
            //Singleton = CatalogSingleton.Instance;
            GasStationSingleton.LoadGasStationAsync();
        }

        #endregion

        #region Properties

        public ICommand SelectedGasStationCommand
        {
            get { return _selectedGasStationCommand ?? (_selectedGasStationCommand = new RelayArgCommand<GasStation>(station => MainPageHandler.SetSelectedGasStation(station))); }
            set { _selectedGasStationCommand = value; }
        }

        public static GasStation SelectedGasStation { get; set; }

        public MainPageHandler MainPageHandler { get; set; }
        //Eksempel for hvordan det ser ud i 1 singleton
        //public static CatalogSingleton Singleton { get; set; }
        public static CustomerSingleton CustomerSingleton { get; set; }
        public static GasStationSingleton GasStationSingleton { get; set; }
        public static ReceiptSingleton ReceiptSingleton { get; set; }
        public static ReviewSingleton ReviewSingleton { get; set; }
        public static OrderSingleton OrderSingleton { get; set; }

        #endregion

    }
}