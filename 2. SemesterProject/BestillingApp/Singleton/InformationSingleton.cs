#region References

using System;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Popups;
using BestillingApp.Model;
using BestillingApp.Persistency;

#endregion

namespace BestillingApp.Singleton
{
    internal class InformationSingleton
    {
        #region Constructor

        private InformationSingleton()
        {
        }

        #endregion

        #region LoadInformationAsync

        public async void LoadInformationAsync()
        {
            //if(Informations.Count > 0)
            //    Informations.Clear();
            try
            {
                var loadedinformations = await PersistencyService.LoadInformationFromJsonAsync();

                //check if # observablecollection Information # is different from # var loadedgasstations #
                //var firstNotSecond = Informations.Except(loadedinformations).ToList();
                //check if # var loadedgasstations # is different from # observablecollection Information #
                //var secondNotFirst = loadedinformations.Except(Informations).ToList();

                if(loadedinformations == null)
                    return;
                if(loadedinformations.Count == 0)
                    await new MessageDialog("Der findes nogen informationer i databasen").ShowAsync();
                //if (!firstNotSecond.Any() && !secondNotFirst.Any())
                //    return;
                foreach(var inf in loadedinformations)
                {
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
                }
            }
            catch(Exception ex)
            {
                new MessageDialog("Der kunne ikke oprettes forbindelse til databasen").ShowAsync();
                throw;
            }
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

        #region Instancefield

        private static InformationSingleton _instance;

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