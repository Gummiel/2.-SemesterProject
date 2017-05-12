using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BestillingApp.Model;
using BestillingApp.Persistency;

namespace BestillingApp.Singleton
{
    class CatalogSingleton
    {
        #region Instancefields

        private static CatalogSingleton _instance;
        private ObservableCollection<Customer> _customers;
        private ObservableCollection<GasStation> _gasstations;
        private ObservableCollection<Item> _items;
        private ObservableCollection<ItemType> _itemtypes;
        private ObservableCollection<Order> _orders;
        private ObservableCollection<Receipt> _receipts;
        private ObservableCollection<Review> _reviews;

        #endregion

        #region Properties

        public static CatalogSingleton Instance => _instance ?? (_instance = new CatalogSingleton());
        public ObservableCollection<Customer> Customers => _customers ?? (_customers = new ObservableCollection<Customer>());
        public ObservableCollection<GasStation> GasStations => _gasstations ?? (_gasstations = new ObservableCollection<GasStation>());
        public ObservableCollection<Item> Items => _items ?? (_items = new ObservableCollection<Item>());
        public ObservableCollection<ItemType> ItemTypes => _itemtypes ?? (_itemtypes = new ObservableCollection<ItemType>());
        public ObservableCollection<Order> Orders => _orders ?? (_orders = new ObservableCollection<Order>());
        public ObservableCollection<Receipt> Receipts => _receipts ?? (_receipts = new ObservableCollection<Receipt>());
        public ObservableCollection<Review> Reviews => _reviews ?? (_reviews = new ObservableCollection<Review>());

        #endregion

        #region Customer

        #region LoadCustomersAsync

        public async void LoadCustomersAsync()
        {
            var customers = await PersistencyService.LoadCustomersFromJsonAsync();
            if(customers != null)
                foreach(var cust in customers)
                    Customers.Add(cust);
        }

        #endregion

        #region RemoveCustomer

        public void RemoveCustomer(Customer c)
        {
            //Customers.Remove(c);
            PersistencyService.DeleteCustomerAsync(c);
            //Hvis create og read er på samme side
            //LoadCustomersAsync();
        }

        #endregion

        #region AddCustomer

        public void AddCustomer(string name, string email, string address, int telNo, int zipcode, string city)
        {
            //var newCustomer = new Customer(name, email, address, telNo, zipcode, city);
            //Customers.Add(newCustomer);
            //PersistencyService.SaveCustomerAsJsonAsync(newCustomer);
            //Hvis create og read er på samme side
            //LoadCustomersAsync();
        }

        public void AddCustomer(Customer c)
        {
            //Customer newCustomer = new Customer(id, name, email, address, telNo, zipcode, city);
            //Customers.Add(newCustomer);
            PersistencyService.SaveCustomerAsJsonAsync(c);
            //Hvis create og read er på samme side
            //LoadCustomersAsync();
        }

        #endregion

        #endregion

        #region GasStation


        #region LoadGasStationAsync

        public async void LoadGasStationAsync()
        {
            var gasstations = await PersistencyService.LoadGasStationsFromJsonAsync();
            if(gasstations != null)
                foreach(var gas in gasstations)
                    GasStations.Add(gas);
        }

        #endregion

        #region RemoveGasStation

        public void RemoveGasStation(GasStation g)
        {
            //GasStations.Remove(g);
            PersistencyService.DeleteGasStationAsync(g);
            //Hvis delete og read er på samme side
            //LoadGasStationAsync();
        }

        #endregion

        #region AddGasStation

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

        #endregion

        #region Item

        #region LoadItemsAsync

        public async void LoadItemsAsync()
        {
            var items = await PersistencyService.LoadItemsFromJsonAsync();
            if(items != null)
                foreach(var item in items)
                    Items.Add(item);
        }

        #endregion

        #region RemoveItem

        public void RemoveItem(Item i)
        {
            //Items.Remove(c);
            PersistencyService.DeleteItemAsync(i);
            //Hvis create og read er på samme side
            //LoadItemsAsync();
        }

        #endregion

        #region AddItem

        public void AddItem(string name, string email, string address, int telNo, int zipcode, string city)
        {
            //var newItem = new Item(name, email, address, telNo, zipcode, city);
            //Items.Add(newItem);
            //PersistencyService.SaveItemAsJsonAsync(newItem);
            //Hvis create og read er på samme side
            //LoadItemsAsync();
        }

        public void AddItem(Item i)
        {
            //Item newItem = new Item(id, name, email, address, telNo, zipcode, city);
            //Items.Add(newItem);
            PersistencyService.SaveItemAsJsonAsync(i);
            //Hvis create og read er på samme side
            //LoadItemsAsync();
        }

        #endregion

        #endregion

        #region ItemType

        #region LoadItemTypesAsync

        public async void LoadItemTypesAsync()
        {
            var itemtypes = await PersistencyService.LoadItemTypesFromJsonAsync();
            if(itemtypes != null)
                foreach(var itemtype in itemtypes)
                    ItemTypes.Add(itemtype);
        }

        #endregion

        #region RemoveItemType

        public void RemoveItemType(ItemType c)
        {
            //ItemTypes.Remove(c);
            PersistencyService.DeleteItemTypeAsync(c);
            //Hvis create og read er på samme side
            //LoadItemTypesAsync();
        }

        #endregion

        #region AddItemType

        public void AddItemType(string name, string email, string address, int telNo, int zipcode, string city)
        {
            //var newItemType = new ItemType(name, email, address, telNo, zipcode, city);
            //ItemTypes.Add(newItemType);
            //PersistencyService.SaveItemTypeAsJsonAsync(newItemType);
            //Hvis create og read er på samme side
            //LoadItemTypesAsync();
        }

        public void AddItemType(ItemType c)
        {
            //ItemType newItemType = new ItemType(id, name, email, address, telNo, zipcode, city);
            //ItemTypes.Add(newItemType);
            PersistencyService.SaveItemTypeAsJsonAsync(c);
            //Hvis create og read er på samme side
            //LoadItemTypesAsync();
        }

        #endregion

        #endregion

        #region Order

        #region LoadOrderAsync

        public async void LoadOrderAsync()
        {
            var orders = await PersistencyService.LoadOrdersFromJsonAsync();
            if(orders != null)
                foreach(var ord in orders)
                    Orders.Add(ord);
        }

        #endregion

        #region RemoveOrder

        public void RemoveOrder(Order o)
        {
            //Orders.Remove(o);
            PersistencyService.DeleteOrderAsync(o);
            //Hvis delete og read er på samme side
            //LoadOrderAsync();
        }

        #endregion

        #region AddOrder

        public void AddOrder(int totalPrice)
        {
            //var newOrder = new Order(totalPrice);
            //Orders.Add(newOrder);
            //PersistencyService.SaveOrderAsJsonAsync(newOrder);
            //Hvis create og read er på samme side
            //LoadOrderAsync();
        }

        public void AddOrder(Order o)
        {
            //Order newOrder = new Order(name, email, address, telNo, zipcode, city, totalPrice, description, amount, price);
            //Orders.Add(r);
            PersistencyService.SaveOrderAsJsonAsync(o);
            //Hvis create og read er på samme side
            //LoadOrderAsync();
        }

        #endregion

        #endregion

        #region Receipt

        #region LoadReceiptAsync

        public async void LoadReceiptAsync()
        {
            var receipts = await PersistencyService.LoadReceiptFromJsonAsync();
            if(receipts != null)
                foreach(var rec in receipts)
                    Receipts.Add(rec);
        }

        #endregion

        #region RemoveReceipt

        public void RemoveReceipt(Receipt r)
        {
            //Receipt.Remove(r);
            PersistencyService.DeleteReceiptAsync(r);
            //Hvis delete og read er på samme side
            //LoadReceiptAsync();
        }

        #endregion

        #region AddReceipt

        public void AddReceipt(string name, string email, string address, int telNo, int zipcode, string city,
            double totalPrice, string description, int amount, double price)
        {
            var newReceipt = new Receipt(name, email, address, telNo, zipcode, city, totalPrice, description, amount,
                price);
            //Receipt.Add(newReceipt);
            PersistencyService.SaveReceiptAsJsonAsync(newReceipt);
            //Hvis create og read er på samme side
            //LoadReceiptAsync();
        }

        public void AddReceipt(Receipt r)
        {
            //Receipt newReceipt = new Receipt(name, email, address, telNo, zipcode, city, totalPrice, description, amount, price);
            //Receipt.Add(r);
            PersistencyService.SaveReceiptAsJsonAsync(r);
            //Hvis create og read er på samme side
            //LoadReceiptAsync();
        }

        #endregion

        #endregion

        #region Review

        #region LoadReviewAsync

        public async void LoadReviewAsync()
        {
            var reviews = await PersistencyService.LoadReviewsFromJsonAsync();
            if(reviews != null)
                foreach(var rev in reviews)
                    Reviews.Add(rev);
        }

        #endregion

        #region RemoveReview

        public void RemoveReview(Review r)
        {
            //Reviews.Remove(r);
            PersistencyService.DeleteReviewAsync(r);
            //Hvis delete og read er på samme side
            //LoadReviewAsync();
        }

        #endregion

        #region AddReview

        public void AddReview(string description, int stars)
        {
            //var newReview = new Review(description, stars);
            //Reviews.Add(newReview);
            //PersistencyService.SaveReviewAsJsonAsync(newReview);
            //Hvis create og read er på samme side
            //LoadReviewAsync();
        }

        public void AddReview(Review r)
        {
            //Review newReview = new Review(id, description, stars);
            //Reviews.Add(newReview);
            PersistencyService.SaveReviewAsJsonAsync(r);
            //Hvis create og read er på samme side
            //LoadReviewAsync();
        }

        #endregion

        #endregion
    }
}
