#region References

using BestillingApp.Singleton;

#endregion

namespace BestillingApp.ViewModel
{
    internal class InfoViewModel
    {
        #region Constructor

        public InfoViewModel()
        {
            InformationSingleton = InformationSingleton.Instance;
            InformationSingleton.LoadInformationAsync();
        }

        #endregion

        #region Properties

        public static InformationSingleton InformationSingleton { get; set; }

        #endregion
    }
}