﻿#region References

using System;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Popups;
using BestillingApp.Model;
using BestillingApp.Persistency;

#endregion

namespace BestillingApp.Singleton
{
    internal class GasStationSingleton
    {
        #region Constructor

        private GasStationSingleton()
        {
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

        #region LoadGasStationAsync

        public async void LoadGasStationAsync()
        {
            if (GasStations.Count > 0)
                GasStations.Clear();
            try
            {
                var loadedgasstations = await PersistencyService.LoadGasStationsFromJsonAsync();

                //check if # observablecollection GasStations # is different from # var loadedgasstations #
                var firstNotSecond = GasStations.Except(loadedgasstations).ToList();
                //check if # var loadedgasstations # is different from # observablecollection GasStations #
                var secondNotFirst = loadedgasstations.Except(GasStations).ToList();

                if (loadedgasstations == null) return;
                if (loadedgasstations.Count == 0)
                    LoadStatus("Der findes nogen gasstations i databasen");
                if (!firstNotSecond.Any() && !secondNotFirst.Any()) return;
                foreach (var gas in loadedgasstations)
                    GasStations.Add(gas);
            }
            catch (Exception)
            {
                LoadStatus("Der kunne ikke oprettes forbindelse til databasen");
                throw;
            }
        }

        public async void LoadStatus(string message)
        {
            // Create the message dialog and set its content
            var messageDialog = new MessageDialog(message);

            messageDialog.Commands.Add(new UICommand("OK", null));

            // Set the command that will be invoked by default
            messageDialog.DefaultCommandIndex = 0;

            // Set the command to be invoked when escape is pressed
            messageDialog.CancelCommandIndex = 0;

            // Show the message dialog
            await messageDialog.ShowAsync();
        }

        #endregion

        #region Instancefield

        private static GasStationSingleton _instance;
        private ObservableCollection<GasStation> _gasstations;

        #endregion

        #region Properties

        public static GasStationSingleton Instance => _instance ?? (_instance = new GasStationSingleton());

        public ObservableCollection<GasStation> GasStations
            => _gasstations ?? (_gasstations = new ObservableCollection<GasStation>());

        #endregion

        #region Add

        public void AddGasStation(string name, string address, string city, int zipcode, string email, int telNo,
            string openHours)
        {
            //var newGasStation = new GasStation(name, address, city, zipcode, email, telNo, openHours);
            //GasStations.Add(newGasStation);
            //PersistencyService.SaveGasStationAsJsonAsync(newGasStation);
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