#region References

using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using BestillingApp.Annotations;
using BestillingApp.Handler;
using BestillingApp.Model;
using BestillingApp.Singleton;
using ZPointApp.Common;

#endregion

namespace BestillingApp.ViewModel
{
    internal class MenuViewModel : INotifyPropertyChanged
    {
        #region Constructor

        public MenuViewModel()
        {
            OrderHandler = new OrderHandler(null, this);
            ProductCatagorySingleton = ProductCatagorySingleton.Instance;
            ProductSingleton = ProductSingleton.Instance;
            //Eksempel for hvordan det ser ud i 1 singleton
            //Singleton = CatalogSingleton.Instance;
            ProductCatagorySingleton.LoadProductCatagoryAsync();
            ProductSingleton.LoadItemsAsync();
        }

        #endregion

        #region Instancefield

        private List<Product> _productList;
        private ICommand _selectedProductCatagoryCommand;

        #endregion

        #region Properties

        public ICommand SelectedProductCatagoryCommand
        {
            get
            {
                return _selectedProductCatagoryCommand ??
                       (_selectedProductCatagoryCommand =
                           new RelayArgCommand<ProductCatagory>(
                               productcatagory => OrderHandler.SetSelectedProductCatagory(productcatagory)));
            }
            set { _selectedProductCatagoryCommand = value; }
        }

        public static ProductCatagory SelectedProductCatagory { get; set; }

        public List<Product> ProductList
        {
            get { return _productList ?? (_productList = new List<Product>()); }
            set
            {
                _productList = value;
                OnPropertyChanged();
            }
        }

        public OrderHandler OrderHandler { get; set; }
        public ProductCatagorySingleton ProductCatagorySingleton { get; set; }
        public ProductSingleton ProductSingleton { get; set; }
        public static string SelectedGasStation { get; set; } = "";

        #endregion

        #region PropertyChangedSupport

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}