#region Directives

using System.Collections.ObjectModel;
using Bestillingsapp.Model;

#endregion

namespace Bestillingsapp.Singleton
{
    internal class OrderSingleton
    {
        #region Instancefield

        private static OrderSingleton _instance;

        #endregion

        #region Constructor

        private OrderSingleton()
        {
        }

        #endregion

        #region Properties

        public static OrderSingleton Instance => _instance ?? (_instance = new OrderSingleton());

        public ObservableCollection<Order> Orders = new ObservableCollection<Order>();

        #endregion
    }
}