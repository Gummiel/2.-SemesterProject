#region References

using BestillingApp.Singleton;

#endregion

namespace BestillingApp.ViewModel
{
    internal class MainViewModel
    {
        public MainViewModel()
        {
            CustomerSingleton = CustomerSingleton.Instance;
        }

        public CustomerSingleton CustomerSingleton { get; set; }
    }
}