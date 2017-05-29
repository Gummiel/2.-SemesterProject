#region References

using System;
using Windows.UI.Popups;
using BestillingApp.Handler;
using BestillingApp.Model;
using BestillingApp.Persistency;

#endregion

namespace BestillingApp.Singleton
{
    internal class InformationSingleton
    {
        #region Instancefield

        private static InformationSingleton _instance;

        #endregion

        #region Constructor

        private InformationSingleton()
        {
        }

        #endregion

        #region Remove

        public void RemoveInformation(Information i)
        {
            //Information.Remove(g);
            PersistencyService.DeleteInformationAsync(i);
            //Hvis delete og read er på samme side
            //LoadInformationAsync();
        }

        #endregion

        #region LoadInformationAsync

        public async void LoadInformationAsync()
        {
            try
            {
                var loadedinformations = await PersistencyService.LoadInformationFromJsonAsync();

                if (loadedinformations == null)
                    return;
                if (loadedinformations.Count == 0)
                    LoadStatus("Der findes nogen informationer i databasen");
                foreach (var inf in loadedinformations)
                {
                    if (inf.ID != OrderHandler.SelectedGasStation.ID) continue;
                    WhoAreWeTitle = inf.WhoAreWeTitle;
                    WhoAreWeSection1 = inf.WhoAreWeSection1;
                    WhoAreWeSection2 = inf.WhoAreWeSection2;
                    WhoAreWeSection3 = inf.WhoAreWeSection3;
                    AboutUsTitle = inf.AboutUsTitle;
                    AboutUsSection1 = inf.AboutUsSection1;
                    AboutUsSection2 = inf.AboutUsSection2;
                    AboutUsSection3 = inf.AboutUsSection3;
                    PaymentTitle = inf.PaymentTitle;
                    PaymentSection1 = inf.PaymentSection1;
                    PaymentSection2 = inf.PaymentSection2;
                    PaymentSection3 = inf.PaymentSection3;
                    break;
                }
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

        #region Properties

        public static InformationSingleton Instance => _instance ?? (_instance = new InformationSingleton());

        public string WhoAreWeTitle { get; set; }
        public string WhoAreWeSection1 { get; set; }
        public string WhoAreWeSection2 { get; set; }
        public string WhoAreWeSection3 { get; set; }
        public string AboutUsTitle { get; set; }
        public string AboutUsSection1 { get; set; }
        public string AboutUsSection2 { get; set; }
        public string AboutUsSection3 { get; set; }
        public string PaymentTitle { get; set; }
        public string PaymentSection1 { get; set; }
        public string PaymentSection2 { get; set; }
        public string PaymentSection3 { get; set; }

        #endregion

        #region Add

        public void AddInformation(string name, string address, string city, int zipcode, string email, int telNo,
            string openHours)
        {
            //var newInformation = new Information(name, address, city, zipcode, email, telNo, openHours);
            //Information.Add(newInformation);
            //PersistencyService.SaveInformationAsJsonAsync(newInformation);
            //Hvis create og read er på samme side
            //LoadInformationAsync();
        }

        public void AddInformation(Information i)
        {
            //Information newInformation = new Information(id, name, address, city, zipcode, email, telNo, openHours);
            //Information.Add(newInformation);
            PersistencyService.SaveInformationAsJsonAsync(i);
            //Hvis create og read er på samme side
            //LoadInformationAsync();
        }

        #endregion
    }
}