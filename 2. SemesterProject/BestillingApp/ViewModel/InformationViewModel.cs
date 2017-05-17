#region References

using BestillingApp.Singleton;

#endregion

namespace BestillingApp.ViewModel
{
    internal class InformationViewModel
    {
        #region Constructor

        public InformationViewModel()
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