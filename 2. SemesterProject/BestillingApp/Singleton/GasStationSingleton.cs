﻿#region References

using System.Collections.ObjectModel;
using BestillingApp.Model;
using BestillingApp.Persistency;

#endregion

namespace BestillingApp.Singleton
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

        #region LoadGasStationAsync

        public async void LoadGasStationAsync()
        {
            var gasstations = await PersistencyService.LoadGasStationsFromJsonAsync();
            if (gasstations != null)
            {
                foreach (var gas in gasstations)
                    GasStations.Add(gas);
            }
        }

        #endregion

        #region Remove

        public void RemoveGasStation(GasStation g)
        {
            //GasStations.Remove(g);
            PersistencyService.DeleteGasStationAsync(g);
            //Hvis delete og read er på samme side
            //LoadGasStationAsync();
        }

        #endregion

        #region Properties

        public static GasStationSingleton Instance => _instance ?? (_instance = new GasStationSingleton());

        public ObservableCollection<GasStation> GasStations = new ObservableCollection<GasStation>();

        #endregion

        #region Add

        public void AddGasStation(int id, string name, string address, string city, int zipcode, string email, int telNo,
            string openHours)
        {
            var newGasStation = new GasStation(id, name, address, city, zipcode, email, telNo, openHours);
            //GasStations.Add(newGasStation);
            PersistencyService.SaveGasStationAsJsonAsync(newGasStation);
            //Hvis create og read er på samme side
            //LoadGasStationAsync();
        }

        public void AddGasStation(GasStation g)
        {
            //GasStation newGasStation = new GasStation(id, name, address, city, zipcode, email, telNo, openHours);
            //GasStations.Add(newGasStation);
            PersistencyService.SaveGasStationAsJsonAsync(g);
            //Hvis create og read er på samme side
            //LoadGasStationAsync();
        }

        #endregion
    }
}