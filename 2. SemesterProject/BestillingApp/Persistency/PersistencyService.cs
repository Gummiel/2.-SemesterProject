#region References

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Windows.UI.Popups;
using BestillingApp.Model;

#endregion

namespace BestillingApp.Persistency
{
    internal class PersistencyService
    {
        #region Instancefield

        private const string serverurl = "http://localhost:7743/";

        private static readonly HttpClientHandler Handler = new HttpClientHandler {UseDefaultCredentials = true};

        private static HttpClient _client;

        #endregion

        #region Customer

        public static async void SaveCustomerAsJsonAsync(Customer c)
        {
            _client = new HttpClient(Handler, false) { BaseAddress = new Uri(serverurl) };
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var response = await Task.FromResult(_client.PostAsJsonAsync("api/Customers/", c).Result);
                if(!response.IsSuccessStatusCode)
                {
                    response.EnsureSuccessStatusCode();
                }
            }
            catch(Exception ex)
            {
                string message;

                //if(ex is FormatException)
                //{
                //    // write to a log, whatever...
                //    message = "FormatException";
                //    return;
                //}
                //if(ex is OverflowException)
                //{
                //    // write to a log, whatever...
                //    message = "OverflowException";
                //    return;
                //}
                //if (ex is ArgumentNullException)
                //{
                //    // write to a log, whatever...
                //    message = "ArgumentNullException";
                //    return;
                //}
                //else
                //{
                    message = "Unknown Error";
                //}

                //switch(ex.GetType().ToString())
                //    {
                //        case "System.InvalidOperationException":
                //        message = "InvalidOperationException";
                //        break;
                //        case "System.NotSupportedException":
                //        message = "NotSupportedException";
                //        break;
                //        case "System.Web.Services.Protocols.SoapException":
                //        message = "SoapException";
                //        break;
                //        case "System.AggregateException":
                //        message = "AggregateException";
                //        break;
                //        default:
                //        message = ex.Message;
                //        break;
                //    }

                new MessageDialog(message).ShowAsync();
                throw;
            }
        }

        public static async void DeleteCustomerAsync(Customer c)
        {
            _client = new HttpClient(Handler, false) { BaseAddress = new Uri(serverurl) };
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var response = await Task.FromResult(_client.DeleteAsync("api/Customers/" + c).Result);
                if(!response.IsSuccessStatusCode)
                {
                    response.EnsureSuccessStatusCode();
                }
            }
            catch(Exception ex)
            {
                new MessageDialog(ex.Message).ShowAsync();
                throw;
            }
        }

        public static async Task<List<Customer>> LoadCustomersFromJsonAsync()
        {
            _client = new HttpClient(Handler, false) { BaseAddress = new Uri(serverurl) };
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var response = await Task.FromResult(_client.GetAsync("api/Customers/").Result);
                if(!response.IsSuccessStatusCode)
                {
                    response.EnsureSuccessStatusCode();
                }
                var customerData =
                    await Task.FromResult(response.Content.ReadAsAsync<IEnumerable<Customer>>().Result);
                return customerData.ToList();

            }
            catch(Exception ex)
            {
                new MessageDialog(ex.Message).ShowAsync();
                throw;
            }
        }

        #endregion

        #region GasStation

        public static async void SaveGasStationAsJsonAsync(GasStation c)
        {
            _client = new HttpClient(Handler, false) { BaseAddress = new Uri(serverurl) };
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var response = await Task.FromResult(_client.PostAsJsonAsync("api/GasStations/", c).Result);
            }
            catch(Exception ex)
            {
                new MessageDialog(ex.Message).ShowAsync();
                throw;
            }
        }

        public static async void DeleteGasStationAsync(GasStation c)
        {
            _client = new HttpClient(Handler, false) { BaseAddress = new Uri(serverurl) };
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var response = await Task.FromResult(_client.DeleteAsync("api/GasStations/" + c).Result);
            }
            catch(Exception ex)
            {
                new MessageDialog(ex.Message).ShowAsync();
                throw;
            }
        }

        public static async Task<List<GasStation>> LoadGasStationsFromJsonAsync()
        {
            _client = new HttpClient(Handler, false) { BaseAddress = new Uri(serverurl) };
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var response = await Task.FromResult(_client.GetAsync("api/GasStations/").Result);

                if(!response.IsSuccessStatusCode)
                    return null;
                var gasStationData =
                    await Task.FromResult(response.Content.ReadAsAsync<IEnumerable<GasStation>>().Result);
                return gasStationData.ToList();
            }
            catch(Exception ex)
            {
                new MessageDialog("Der skete en fejl under hentningen af elementer i databasen").ShowAsync();
                throw;
            }
        }

        #endregion

        #region Item

        public static async void SaveItemAsJsonAsync(Item c)
        {
            _client = new HttpClient(Handler, false) { BaseAddress = new Uri(serverurl) };
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var response = await Task.FromResult(_client.PostAsJsonAsync("api/Items/", c).Result);
            }
            catch(Exception ex)
            {
                new MessageDialog(ex.Message).ShowAsync();
                throw;
            }
        }

        public static async void DeleteItemAsync(Item c)
        {
            _client = new HttpClient(Handler, false) { BaseAddress = new Uri(serverurl) };
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var response = await Task.FromResult(_client.DeleteAsync("api/Items/" + c).Result);
            }
            catch(Exception ex)
            {
                new MessageDialog(ex.Message).ShowAsync();
                throw;
            }
        }

        public static async Task<List<Item>> LoadItemsFromJsonAsync()
        {
            _client = new HttpClient(Handler, false) { BaseAddress = new Uri(serverurl) };
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var response = await Task.FromResult(_client.GetAsync("api/Items/").Result);

                if(!response.IsSuccessStatusCode)
                    return null;
                var itemData =
                    await Task.FromResult(response.Content.ReadAsAsync<IEnumerable<Item>>().Result);
                return itemData.ToList();
            }
            catch(Exception ex)
            {
                new MessageDialog(ex.Message).ShowAsync();
                throw;
            }
        }

        #endregion

        #region ItemType

        public static async void SaveItemTypeAsJsonAsync(ItemType c)
        {
            _client = new HttpClient(Handler, false) { BaseAddress = new Uri(serverurl) };
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var response = await Task.FromResult(_client.PostAsJsonAsync("api/ItemTypes/", c).Result);
            }
            catch(Exception ex)
            {
                new MessageDialog(ex.Message).ShowAsync();
                throw;
            }
        }

        public static async void DeleteItemTypeAsync(ItemType c)
        {
            _client = new HttpClient(Handler, false) { BaseAddress = new Uri(serverurl) };
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var response = await Task.FromResult(_client.DeleteAsync("api/ItemTypes/" + c).Result);
            }
            catch(Exception ex)
            {
                new MessageDialog(ex.Message).ShowAsync();
                throw;
            }
        }

        public static async Task<List<ItemType>> LoadItemTypesFromJsonAsync()
        {
            _client = new HttpClient(Handler, false) { BaseAddress = new Uri(serverurl) };
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var response = await Task.FromResult(_client.GetAsync("api/ItemTypes/").Result);

                if(!response.IsSuccessStatusCode)
                    return null;
                var itemData =
                    await Task.FromResult(response.Content.ReadAsAsync<IEnumerable<ItemType>>().Result);
                return itemData.ToList();
            }
            catch(Exception ex)
            {
                new MessageDialog(ex.Message).ShowAsync();
                throw;
            }
        }

        #endregion

        #region OrderItem

        public static async void SaveOrderItemAsJsonAsync(OrderItem c)
        {
            _client = new HttpClient(Handler, false) { BaseAddress = new Uri(serverurl) };
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var response = await Task.FromResult(_client.PostAsJsonAsync("api/OrderItems/", c).Result);
            }
            catch(Exception ex)
            {
                new MessageDialog(ex.Message).ShowAsync();
                throw;
            }
        }

        public static async void DeleteOrderItemAsync(OrderItem c)
        {
            _client = new HttpClient(Handler, false) { BaseAddress = new Uri(serverurl) };
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var response = await Task.FromResult(_client.DeleteAsync("api/OrderItems/" + c).Result);
            }
            catch(Exception ex)
            {
                new MessageDialog(ex.Message).ShowAsync();
                throw;
            }
        }

        public static async Task<List<OrderItem>> LoadOrderItemsFromJsonAsync()
        {
            _client = new HttpClient(Handler, false) { BaseAddress = new Uri(serverurl) };
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var response = await Task.FromResult(_client.GetAsync("api/OrderItems/").Result);

                if(!response.IsSuccessStatusCode)
                    return null;
                var orderItemsData =
                    await Task.FromResult(response.Content.ReadAsAsync<IEnumerable<OrderItem>>().Result);
                return orderItemsData.ToList();
            }
            catch(Exception ex)
            {
                new MessageDialog(ex.Message).ShowAsync();
                throw;
            }
        }

        #endregion

        #region Order

        public static async void SaveOrderAsJsonAsync(Order c)
        {
            _client = new HttpClient(Handler, false) { BaseAddress = new Uri(serverurl) };
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var response = await Task.FromResult(_client.PostAsJsonAsync("api/Orders/", c).Result);
            }
            catch(Exception ex)
            {
                new MessageDialog(ex.Message).ShowAsync();
                throw;
            }
        }

        public static async void DeleteOrderAsync(Order c)
        {
            _client = new HttpClient(Handler, false) { BaseAddress = new Uri(serverurl) };
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var response = await Task.FromResult(_client.DeleteAsync("api/Orders/" + c).Result);
            }
            catch(Exception ex)
            {
                new MessageDialog(ex.Message).ShowAsync();
                throw;
            }
        }

        public static async Task<List<Order>> LoadOrdersFromJsonAsync()
        {
            _client = new HttpClient(Handler, false) { BaseAddress = new Uri(serverurl) };
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var response = await Task.FromResult(_client.GetAsync("api/Orders/").Result);

                if(!response.IsSuccessStatusCode)
                    return null;
                var orderData =
                    await Task.FromResult(response.Content.ReadAsAsync<IEnumerable<Order>>().Result);
                return orderData.ToList();
            }
            catch(Exception ex)
            {
                new MessageDialog(ex.Message).ShowAsync();
                throw;
            }
        }

        #endregion

        #region Payment

        public static async void SavePaymentAsJsonAsync(Payment c)
        {
            _client = new HttpClient(Handler, false) { BaseAddress = new Uri(serverurl) };
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var response = await Task.FromResult(_client.PostAsJsonAsync("api/Payments/", c).Result);
            }
            catch(Exception ex)
            {
                new MessageDialog(ex.Message).ShowAsync();
                throw;
            }
        }

        public static async void DeletePaymentAsync(Payment c)
        {
            _client = new HttpClient(Handler, false) { BaseAddress = new Uri(serverurl) };
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var response = await Task.FromResult(_client.DeleteAsync("api/Payments/" + c).Result);
            }
            catch(Exception ex)
            {
                new MessageDialog(ex.Message).ShowAsync();
                throw;
            }
        }

        public static async Task<List<Payment>> LoadPaymentsFromJsonAsync()
        {
            _client = new HttpClient(Handler, false) { BaseAddress = new Uri(serverurl) };
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var response = await Task.FromResult(_client.GetAsync("api/Payments/").Result);

                if(!response.IsSuccessStatusCode)
                    return null;
                var paymentData =
                    await Task.FromResult(response.Content.ReadAsAsync<IEnumerable<Payment>>().Result);
                return paymentData.ToList();
            }
            catch(Exception ex)
            {
                new MessageDialog(ex.Message).ShowAsync();
                throw;
            }
        }

        #endregion

        #region Review

        public static async void SaveReviewAsJsonAsync(Review c)
        {
            _client = new HttpClient(Handler, false) { BaseAddress = new Uri(serverurl) };
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var response = await Task.FromResult(_client.PostAsJsonAsync("api/Reviews/", c).Result);
            }
            catch(Exception ex)
            {
                new MessageDialog(ex.Message).ShowAsync();
                throw;
            }
        }

        public static async void DeleteReviewAsync(Review c)
        {
            _client = new HttpClient(Handler, false) { BaseAddress = new Uri(serverurl) };
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var response = await Task.FromResult(_client.DeleteAsync("api/Reviews/" + c).Result);
            }
            catch(Exception ex)
            {
                new MessageDialog(ex.Message).ShowAsync();
                throw;
            }
        }

        public static async Task<List<Review>> LoadReviewsFromJsonAsync()
        {
            _client = new HttpClient(Handler, false) { BaseAddress = new Uri(serverurl) };
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var response = await Task.FromResult(_client.GetAsync("api/Reviews/").Result);

                if(!response.IsSuccessStatusCode)
                    return null;
                var reviewData =
                    await Task.FromResult(response.Content.ReadAsAsync<IEnumerable<Review>>().Result);
                return reviewData.ToList();
            }
            catch(Exception ex)
            {
                new MessageDialog(ex.Message).ShowAsync();
                throw;
            }
        }

        #endregion

        #region Receipt

        public static async void SaveReceiptAsJsonAsync(Receipt c)
        {
            _client = new HttpClient(Handler, false) { BaseAddress = new Uri(serverurl) };
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var response = await Task.FromResult(_client.PostAsJsonAsync("api/Receipts/", c).Result);
            }
            catch(Exception ex)
            {
                new MessageDialog(ex.Message).ShowAsync();
                throw;
            }
        }

        public static async void DeleteReceiptAsync(Receipt c)
        {
            _client = new HttpClient(Handler, false) { BaseAddress = new Uri(serverurl) };
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var response = await Task.FromResult(_client.DeleteAsync("api/Receipts/" + c).Result);
            }
            catch(Exception ex)
            {
                new MessageDialog(ex.Message).ShowAsync();
                throw;
            }
        }

        public static async Task<List<Receipt>> LoadReceiptFromJsonAsync()
        {
            _client = new HttpClient(Handler, false) { BaseAddress = new Uri(serverurl) };
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var response = await Task.FromResult(_client.GetAsync("api/Receipts/").Result);

                if(!response.IsSuccessStatusCode)
                    return null;
                var receiptData =
                    await Task.FromResult(response.Content.ReadAsAsync<IEnumerable<Receipt>>().Result);
                return receiptData.ToList();
            }
            catch(Exception ex)
            {
                new MessageDialog(ex.Message).ShowAsync();
                throw;
            }
        }

        #endregion
    }
}