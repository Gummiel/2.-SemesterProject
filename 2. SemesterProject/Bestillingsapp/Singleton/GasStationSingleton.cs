#region Directives

using System.Collections.ObjectModel;
using Bestillingsapp.Model;

#endregion

namespace Bestillingsapp.Singleton
{
    internal class GasStationSingleton
    {
        #region Instancefield

        private static GasStationSingleton _instance;

        #endregion

        #region Constructor

        private GasStationSingleton()
        {
        }

        #endregion

        #region Properties

        public static GasStationSingleton Instance => _instance ?? (_instance = new GasStationSingleton());

        public ObservableCollection<GasStation> GasStations = new ObservableCollection<GasStation>();

        #endregion
    }
}