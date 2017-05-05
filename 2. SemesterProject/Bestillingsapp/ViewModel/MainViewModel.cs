#region Directives

using Bestillingsapp.Singleton;

#endregion

namespace Bestillingsapp.ViewModel
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