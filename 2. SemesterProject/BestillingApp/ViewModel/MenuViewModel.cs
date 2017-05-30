#region References

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using BestillingApp.Common;
using BestillingApp.Handler;
using BestillingApp.Model;
using BestillingApp.Properties;
using BestillingApp.Singleton;

#endregion

namespace BestillingApp.ViewModel
{
    internal class MenuViewModel : INotifyPropertyChanged
    {
        #region Constructor

        public MenuViewModel()
        {
            OrderHandler = new OrderHandler(null, null, null, this, null);
            ProductCatagorySingleton = ProductCatagorySingleton.Instance;
            ProductSingleton = ProductSingleton.Instance;
            //Eksempel for hvordan det ser ud i 1 singleton
            //Singleton = CatalogSingleton.Instance;
            ProductCatagorySingleton.LoadProductCatagoryAsync();
            ProductSingleton.LoadItemsAsync();
            OrderSingleton = OrderSingleton.Instance;
            OrderItemCount = OrderSingleton.OrderItems.Count;
        }

        #endregion

        #region Instancefield

        private ObservableCollection<Product> _productList;
        private ICommand _selectedProductCatagoryCommand;
        private ICommand _selectedProductCommand;
        private int _orderItemCount;

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

        public ICommand SelectedProductCommand
        {
            get
            {
                return _selectedProductCommand ??
                       (_selectedProductCommand =
                           new RelayArgCommand<Product>(
                               product => OrderHandler.AddSelectedProductToOrderItems(product)));
            }
            set { _selectedProductCommand = value; }
        }

        public static ProductCatagory SelectedProductCatagory { get; set; }
        public static Product SelectedProduct { get; set; }

        public ObservableCollection<Product> ProductList
        {
            get { return _productList; }
            set
            {
                _productList = value;
                OnPropertyChanged();
            }
        }

        public int OrderItemCount
        {
            get { return _orderItemCount; }
            set
            {
                _orderItemCount = value;
                OnPropertyChanged();
            }
        }

        public OrderHandler OrderHandler { get; set; }
        public ProductCatagorySingleton ProductCatagorySingleton { get; set; }
        public ProductSingleton ProductSingleton { get; set; }
        public OrderSingleton OrderSingleton { get; set; }

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