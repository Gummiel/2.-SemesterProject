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

        private const string serverurl = "http://localhost:5000/";

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
                    response.EnsureSuccessStatusCode();
            }
            catch(Exception ex)
            {
                string message;

                if(ex is FormatException)
                {
                    // write to a log, whatever...
                    message = "FormatException";
                }
                else if(ex is OverflowException)
                {
                    // write to a log, whatever...
                    message = "OverflowException";
                }
                else if(ex is ArgumentNullException)
                {
                    // write to a log, whatever...
                    message = "ArgumentNullException";
                }
                else if(ex is HttpRequestException)
                {
                    // write to a log, whatever...
                    message = "HttpRequestException";
                }
                else
                {
                    message = ex.Message;
                    //message = "Unknown Error";
                }

                //switch(ex.GetType().ToString())
                //{
                //    case "System.InvalidOperationException":
                //    message = "InvalidOperationException";
                //    break;
                //    case "System.NotSupportedException":
                //    message = "NotSupportedException";
                //    break;
                //    case "System.Web.Services.Protocols.SoapException":
                //    message = "SoapException";
                //    break;
                //    case "System.AggregateException":
                //    message = "AggregateException";
                //    break;
                //    default:
                //    message = ex.Message;
                //    break;
                //}

                HttpClientStatus(message);
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
                    response.EnsureSuccessStatusCode();
            }
            catch(Exception ex)
            {
                string message;

                if(ex is FormatException)
                {
                    // write to a log, whatever...
                    message = "FormatException";
                }
                else if(ex is OverflowException)
                {
                    // write to a log, whatever...
                    message = "OverflowException";
                }
                else if(ex is ArgumentNullException)
                {
                    // write to a log, whatever...
                    message = "ArgumentNullException";
                }
                else if(ex is HttpRequestException)
                {
                    // write to a log, whatever...
                    message = "HttpRequestException";
                }
                else
                {
                    message = ex.Message;
                    //message = "Unknown Error";
                }

                //switch(ex.GetType().ToString())
                //{
                //    case "System.InvalidOperationException":
                //    message = "InvalidOperationException";
                //    break;
                //    case "System.NotSupportedException":
                //    message = "NotSupportedException";
                //    break;
                //    case "System.Web.Services.Protocols.SoapException":
                //    message = "SoapException";
                //    break;
                //    case "System.AggregateException":
                //    message = "AggregateException";
                //    break;
                //    default:
                //    message = ex.Message;
                //    break;
                //}

                HttpClientStatus(message);
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
                    response.EnsureSuccessStatusCode();
                var customerData =
                    await Task.FromResult(response.Content.ReadAsAsync<IEnumerable<Customer>>().Result);
                return customerData.ToList();
            }
            catch(Exception ex)
            {
                string message;

                if(ex is FormatException)
                {
                    // write to a log, whatever...
                    message = "FormatException";
                }
                else if(ex is OverflowException)
                {
                    // write to a log, whatever...
                    message = "OverflowException";
                }
                else if(ex is ArgumentNullException)
                {
                    // write to a log, whatever...
                    message = "ArgumentNullException";
                }
                else if(ex is HttpRequestException)
                {
                    // write to a log, whatever...
                    message = "HttpRequestException";
                }
                else
                {
                    message = ex.Message;
                    //message = "Unknown Error";
                }

                //switch(ex.GetType().ToString())
                //{
                //    case "System.InvalidOperationException":
                //    message = "InvalidOperationException";
                //    break;
                //    case "System.NotSupportedException":
                //    message = "NotSupportedException";
                //    break;
                //    case "System.Web.Services.Protocols.SoapException":
                //    message = "SoapException";
                //    break;
                //    case "System.AggregateException":
                //    message = "AggregateException";
                //    break;
                //    default:
                //    message = ex.Message;
                //    break;
                //}

                HttpClientStatus(message);
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
                if(!response.IsSuccessStatusCode)
                    response.EnsureSuccessStatusCode();
            }
            catch(Exception ex)
            {
                string message;

                if(ex is FormatException)
                {
                    // write to a log, whatever...
                    message = "FormatException";
                }
                else if(ex is OverflowException)
                {
                    // write to a log, whatever...
                    message = "OverflowException";
                }
                else if(ex is ArgumentNullException)
                {
                    // write to a log, whatever...
                    message = "ArgumentNullException";
                }
                else if(ex is HttpRequestException)
                {
                    // write to a log, whatever...
                    message = "HttpRequestException";
                }
                else
                {
                    message = ex.Message;
                    //message = "Unknown Error";
                }

                //switch(ex.GetType().ToString())
                //{
                //    case "System.InvalidOperationException":
                //    message = "InvalidOperationException";
                //    break;
                //    case "System.NotSupportedException":
                //    message = "NotSupportedException";
                //    break;
                //    case "System.Web.Services.Protocols.SoapException":
                //    message = "SoapException";
                //    break;
                //    case "System.AggregateException":
                //    message = "AggregateException";
                //    break;
                //    default:
                //    message = ex.Message;
                //    break;
                //}

                HttpClientStatus(message);
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
                if(!response.IsSuccessStatusCode)
                    response.EnsureSuccessStatusCode();
            }
            catch(Exception ex)
            {
                string message;

                if(ex is FormatException)
                {
                    // write to a log, whatever...
                    message = "FormatException";
                }
                else if(ex is OverflowException)
                {
                    // write to a log, whatever...
                    message = "OverflowException";
                }
                else if(ex is ArgumentNullException)
                {
                    // write to a log, whatever...
                    message = "ArgumentNullException";
                }
                else if(ex is HttpRequestException)
                {
                    // write to a log, whatever...
                    message = "HttpRequestException";
                }
                else
                {
                    message = ex.Message;
                    //message = "Unknown Error";
                }

                //switch(ex.GetType().ToString())
                //{
                //    case "System.InvalidOperationException":
                //    message = "InvalidOperationException";
                //    break;
                //    case "System.NotSupportedException":
                //    message = "NotSupportedException";
                //    break;
                //    case "System.Web.Services.Protocols.SoapException":
                //    message = "SoapException";
                //    break;
                //    case "System.AggregateException":
                //    message = "AggregateException";
                //    break;
                //    default:
                //    message = ex.Message;
                //    break;
                //}

                HttpClientStatus(message);
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
                    response.EnsureSuccessStatusCode();

                var gasStationData =
                    await Task.FromResult(response.Content.ReadAsAsync<IEnumerable<GasStation>>().Result);
                return gasStationData.ToList();
            }
            catch(Exception ex)
            {
                string message;

                if(ex is FormatException)
                {
                    // write to a log, whatever...
                    message = "FormatException";
                }
                else if(ex is OverflowException)
                {
                    // write to a log, whatever...
                    message = "OverflowException";
                }
                else if(ex is ArgumentNullException)
                {
                    // write to a log, whatever...
                    message = "ArgumentNullException";
                }
                else if(ex is HttpRequestException)
                {
                    // write to a log, whatever...
                    message = "HttpRequestException";
                }
                else
                {
                    message = ex.Message;
                    //message = "Unknown Error";
                }

                //switch(ex.GetType().ToString())
                //{
                //    case "System.InvalidOperationException":
                //    message = "InvalidOperationException";
                //    break;
                //    case "System.NotSupportedException":
                //    message = "NotSupportedException";
                //    break;
                //    case "System.Web.Services.Protocols.SoapException":
                //    message = "SoapException";
                //    break;
                //    case "System.AggregateException":
                //    message = "AggregateException";
                //    break;
                //    default:
                //    message = ex.Message;
                //    break;
                //}

                HttpClientStatus(message);
                throw;
            }
        }

        #endregion

        #region Product

        public static async void SaveProductAsJsonAsync(Product c)
        {
            _client = new HttpClient(Handler, false) { BaseAddress = new Uri(serverurl) };
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var response = await Task.FromResult(_client.PostAsJsonAsync("api/Products/", c).Result);
                if(!response.IsSuccessStatusCode)
                    response.EnsureSuccessStatusCode();
            }
            catch(Exception ex)
            {
                string message;

                if(ex is FormatException)
                {
                    // write to a log, whatever...
                    message = "FormatException";
                }
                else if(ex is OverflowException)
                {
                    // write to a log, whatever...
                    message = "OverflowException";
                }
                else if(ex is ArgumentNullException)
                {
                    // write to a log, whatever...
                    message = "ArgumentNullException";
                }
                else if(ex is HttpRequestException)
                {
                    // write to a log, whatever...
                    message = "HttpRequestException";
                }
                else
                {
                    message = ex.Message;
                    //message = "Unknown Error";
                }

                //switch(ex.GetType().ToString())
                //{
                //    case "System.InvalidOperationException":
                //    message = "InvalidOperationException";
                //    break;
                //    case "System.NotSupportedException":
                //    message = "NotSupportedException";
                //    break;
                //    case "System.Web.Services.Protocols.SoapException":
                //    message = "SoapException";
                //    break;
                //    case "System.AggregateException":
                //    message = "AggregateException";
                //    break;
                //    default:
                //    message = ex.Message;
                //    break;
                //}

                HttpClientStatus(message);
                throw;
            }
        }

        public static async void DeleteProductAsync(Product c)
        {
            _client = new HttpClient(Handler, false) { BaseAddress = new Uri(serverurl) };
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var response = await Task.FromResult(_client.DeleteAsync("api/Products/" + c).Result);
                if(!response.IsSuccessStatusCode)
                    response.EnsureSuccessStatusCode();
            }
            catch(Exception ex)
            {
                string message;

                if(ex is FormatException)
                {
                    // write to a log, whatever...
                    message = "FormatException";
                }
                else if(ex is OverflowException)
                {
                    // write to a log, whatever...
                    message = "OverflowException";
                }
                else if(ex is ArgumentNullException)
                {
                    // write to a log, whatever...
                    message = "ArgumentNullException";
                }
                else if(ex is HttpRequestException)
                {
                    // write to a log, whatever...
                    message = "HttpRequestException";
                }
                else
                {
                    message = ex.Message;
                    //message = "Unknown Error";
                }

                //switch(ex.GetType().ToString())
                //{
                //    case "System.InvalidOperationException":
                //    message = "InvalidOperationException";
                //    break;
                //    case "System.NotSupportedException":
                //    message = "NotSupportedException";
                //    break;
                //    case "System.Web.Services.Protocols.SoapException":
                //    message = "SoapException";
                //    break;
                //    case "System.AggregateException":
                //    message = "AggregateException";
                //    break;
                //    default:
                //    message = ex.Message;
                //    break;
                //}

                HttpClientStatus(message);
                throw;
            }
        }

        public static async Task<List<Product>> LoadProductsFromJsonAsync()
        {
            _client = new HttpClient(Handler, false) { BaseAddress = new Uri(serverurl) };
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var response = await Task.FromResult(_client.GetAsync("api/Products/").Result);

                if(!response.IsSuccessStatusCode)
                    response.EnsureSuccessStatusCode();
                var itemData =
                    await Task.FromResult(response.Content.ReadAsAsync<IEnumerable<Product>>().Result);
                return itemData.ToList();
            }
            catch(Exception ex)
            {
                string message;

                if(ex is FormatException)
                {
                    // write to a log, whatever...
                    message = "FormatException";
                }
                else if(ex is OverflowException)
                {
                    // write to a log, whatever...
                    message = "OverflowException";
                }
                else if(ex is ArgumentNullException)
                {
                    // write to a log, whatever...
                    message = "ArgumentNullException";
                }
                else if(ex is HttpRequestException)
                {
                    // write to a log, whatever...
                    message = "HttpRequestException";
                }
                else
                {
                    message = ex.Message;
                    //message = "Unknown Error";
                }

                //switch(ex.GetType().ToString())
                //{
                //    case "System.InvalidOperationException":
                //    message = "InvalidOperationException";
                //    break;
                //    case "System.NotSupportedException":
                //    message = "NotSupportedException";
                //    break;
                //    case "System.Web.Services.Protocols.SoapException":
                //    message = "SoapException";
                //    break;
                //    case "System.AggregateException":
                //    message = "AggregateException";
                //    break;
                //    default:
                //    message = ex.Message;
                //    break;
                //}

                HttpClientStatus(message);
                throw;
            }
        }

        #endregion

        #region ProductCatagory

        public static async void SaveProductCatagoryAsJsonAsync(ProductCatagory c)
        {
            _client = new HttpClient(Handler, false) { BaseAddress = new Uri(serverurl) };
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var response = await Task.FromResult(_client.PostAsJsonAsync("api/ProductCatagories/", c).Result);
                if(!response.IsSuccessStatusCode)
                    response.EnsureSuccessStatusCode();
            }
            catch(Exception ex)
            {
                string message;

                if(ex is FormatException)
                {
                    // write to a log, whatever...
                    message = "FormatException";
                }
                else if(ex is OverflowException)
                {
                    // write to a log, whatever...
                    message = "OverflowException";
                }
                else if(ex is ArgumentNullException)
                {
                    // write to a log, whatever...
                    message = "ArgumentNullException";
                }
                else if(ex is HttpRequestException)
                {
                    // write to a log, whatever...
                    message = "HttpRequestException";
                }
                else
                {
                    message = ex.Message;
                    //message = "Unknown Error";
                }

                //switch(ex.GetType().ToString())
                //{
                //    case "System.InvalidOperationException":
                //    message = "InvalidOperationException";
                //    break;
                //    case "System.NotSupportedException":
                //    message = "NotSupportedException";
                //    break;
                //    case "System.Web.Services.Protocols.SoapException":
                //    message = "SoapException";
                //    break;
                //    case "System.AggregateException":
                //    message = "AggregateException";
                //    break;
                //    default:
                //    message = ex.Message;
                //    break;
                //}

                HttpClientStatus(message);
                throw;
            }
        }

        public static async void DeleteProductCatagoryAsync(ProductCatagory c)
        {
            _client = new HttpClient(Handler, false) { BaseAddress = new Uri(serverurl) };
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var response = await Task.FromResult(_client.DeleteAsync("api/ProductCatagories/" + c).Result);
                if(!response.IsSuccessStatusCode)
                    response.EnsureSuccessStatusCode();
            }
            catch(Exception ex)
            {
                string message;

                if(ex is FormatException)
                {
                    // write to a log, whatever...
                    message = "FormatException";
                }
                else if(ex is OverflowException)
                {
                    // write to a log, whatever...
                    message = "OverflowException";
                }
                else if(ex is ArgumentNullException)
                {
                    // write to a log, whatever...
                    message = "ArgumentNullException";
                }
                else if(ex is HttpRequestException)
                {
                    // write to a log, whatever...
                    message = "HttpRequestException";
                }
                else
                {
                    message = ex.Message;
                    //message = "Unknown Error";
                }

                //switch(ex.GetType().ToString())
                //{
                //    case "System.InvalidOperationException":
                //    message = "InvalidOperationException";
                //    break;
                //    case "System.NotSupportedException":
                //    message = "NotSupportedException";
                //    break;
                //    case "System.Web.Services.Protocols.SoapException":
                //    message = "SoapException";
                //    break;
                //    case "System.AggregateException":
                //    message = "AggregateException";
                //    break;
                //    default:
                //    message = ex.Message;
                //    break;
                //}

                HttpClientStatus(message);
                throw;
            }
        }

        public static async Task<List<ProductCatagory>> LoadProductCatagoriesFromJsonAsync()
        {
            _client = new HttpClient(Handler, false) { BaseAddress = new Uri(serverurl) };
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var response = await Task.FromResult(_client.GetAsync("api/ProductCatagories/").Result);

                if(!response.IsSuccessStatusCode)
                    response.EnsureSuccessStatusCode();
                var itemData =
                    await Task.FromResult(response.Content.ReadAsAsync<IEnumerable<ProductCatagory>>().Result);
                return itemData.ToList();
            }
            catch(Exception ex)
            {
                string message;

                if(ex is FormatException)
                {
                    // write to a log, whatever...
                    message = "FormatException";
                }
                else if(ex is OverflowException)
                {
                    // write to a log, whatever...
                    message = "OverflowException";
                }
                else if(ex is ArgumentNullException)
                {
                    // write to a log, whatever...
                    message = "ArgumentNullException";
                }
                else if(ex is HttpRequestException)
                {
                    // write to a log, whatever...
                    message = "HttpRequestException";
                }
                else
                {
                    message = ex.Message;
                    //message = "Unknown Error";
                }

                //switch(ex.GetType().ToString())
                //{
                //    case "System.InvalidOperationException":
                //    message = "InvalidOperationException";
                //    break;
                //    case "System.NotSupportedException":
                //    message = "NotSupportedException";
                //    break;
                //    case "System.Web.Services.Protocols.SoapException":
                //    message = "SoapException";
                //    break;
                //    case "System.AggregateException":
                //    message = "AggregateException";
                //    break;
                //    default:
                //    message = ex.Message;
                //    break;
                //}

                HttpClientStatus(message);
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
                if(!response.IsSuccessStatusCode)
                    response.EnsureSuccessStatusCode();
            }
            catch(Exception ex)
            {
                string message;

                if(ex is FormatException)
                {
                    // write to a log, whatever...
                    message = "FormatException";
                }
                else if(ex is OverflowException)
                {
                    // write to a log, whatever...
                    message = "OverflowException";
                }
                else if(ex is ArgumentNullException)
                {
                    // write to a log, whatever...
                    message = "ArgumentNullException";
                }
                else if(ex is HttpRequestException)
                {
                    // write to a log, whatever...
                    message = "HttpRequestException";
                }
                else
                {
                    message = ex.Message;
                    //message = "Unknown Error";
                }

                //switch(ex.GetType().ToString())
                //{
                //    case "System.InvalidOperationException":
                //    message = "InvalidOperationException";
                //    break;
                //    case "System.NotSupportedException":
                //    message = "NotSupportedException";
                //    break;
                //    case "System.Web.Services.Protocols.SoapException":
                //    message = "SoapException";
                //    break;
                //    case "System.AggregateException":
                //    message = "AggregateException";
                //    break;
                //    default:
                //    message = ex.Message;
                //    break;
                //}

                HttpClientStatus(message);
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
                if(!response.IsSuccessStatusCode)
                    response.EnsureSuccessStatusCode();
            }
            catch(Exception ex)
            {
                string message;

                if(ex is FormatException)
                {
                    // write to a log, whatever...
                    message = "FormatException";
                }
                else if(ex is OverflowException)
                {
                    // write to a log, whatever...
                    message = "OverflowException";
                }
                else if(ex is ArgumentNullException)
                {
                    // write to a log, whatever...
                    message = "ArgumentNullException";
                }
                else if(ex is HttpRequestException)
                {
                    // write to a log, whatever...
                    message = "HttpRequestException";
                }
                else
                {
                    message = ex.Message;
                    //message = "Unknown Error";
                }

                //switch(ex.GetType().ToString())
                //{
                //    case "System.InvalidOperationException":
                //    message = "InvalidOperationException";
                //    break;
                //    case "System.NotSupportedException":
                //    message = "NotSupportedException";
                //    break;
                //    case "System.Web.Services.Protocols.SoapException":
                //    message = "SoapException";
                //    break;
                //    case "System.AggregateException":
                //    message = "AggregateException";
                //    break;
                //    default:
                //    message = ex.Message;
                //    break;
                //}

                HttpClientStatus(message);
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
                    response.EnsureSuccessStatusCode();
                var orderProductsData =
                    await Task.FromResult(response.Content.ReadAsAsync<IEnumerable<OrderItem>>().Result);
                return orderProductsData.ToList();
            }
            catch(Exception ex)
            {
                string message;

                if(ex is FormatException)
                {
                    // write to a log, whatever...
                    message = "FormatException";
                }
                else if(ex is OverflowException)
                {
                    // write to a log, whatever...
                    message = "OverflowException";
                }
                else if(ex is ArgumentNullException)
                {
                    // write to a log, whatever...
                    message = "ArgumentNullException";
                }
                else if(ex is HttpRequestException)
                {
                    // write to a log, whatever...
                    message = "HttpRequestException";
                }
                else
                {
                    message = ex.Message;
                    //message = "Unknown Error";
                }

                //switch(ex.GetType().ToString())
                //{
                //    case "System.InvalidOperationException":
                //    message = "InvalidOperationException";
                //    break;
                //    case "System.NotSupportedException":
                //    message = "NotSupportedException";
                //    break;
                //    case "System.Web.Services.Protocols.SoapException":
                //    message = "SoapException";
                //    break;
                //    case "System.AggregateException":
                //    message = "AggregateException";
                //    break;
                //    default:
                //    message = ex.Message;
                //    break;
                //}

                HttpClientStatus(message);
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
                if(!response.IsSuccessStatusCode)
                    response.EnsureSuccessStatusCode();
            }
            catch(Exception ex)
            {
                string message;

                if(ex is FormatException)
                {
                    // write to a log, whatever...
                    message = "FormatException";
                }
                else if(ex is OverflowException)
                {
                    // write to a log, whatever...
                    message = "OverflowException";
                }
                else if(ex is ArgumentNullException)
                {
                    // write to a log, whatever...
                    message = "ArgumentNullException";
                }
                else if(ex is HttpRequestException)
                {
                    // write to a log, whatever...
                    message = "HttpRequestException";
                }
                else
                {
                    message = ex.Message;
                    //message = "Unknown Error";
                }

                //switch(ex.GetType().ToString())
                //{
                //    case "System.InvalidOperationException":
                //    message = "InvalidOperationException";
                //    break;
                //    case "System.NotSupportedException":
                //    message = "NotSupportedException";
                //    break;
                //    case "System.Web.Services.Protocols.SoapException":
                //    message = "SoapException";
                //    break;
                //    case "System.AggregateException":
                //    message = "AggregateException";
                //    break;
                //    default:
                //    message = ex.Message;
                //    break;
                //}

                HttpClientStatus(message);
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
                if(!response.IsSuccessStatusCode)
                    response.EnsureSuccessStatusCode();
            }
            catch(Exception ex)
            {
                string message;

                if(ex is FormatException)
                {
                    // write to a log, whatever...
                    message = "FormatException";
                }
                else if(ex is OverflowException)
                {
                    // write to a log, whatever...
                    message = "OverflowException";
                }
                else if(ex is ArgumentNullException)
                {
                    // write to a log, whatever...
                    message = "ArgumentNullException";
                }
                else if(ex is HttpRequestException)
                {
                    // write to a log, whatever...
                    message = "HttpRequestException";
                }
                else
                {
                    message = ex.Message;
                    //message = "Unknown Error";
                }

                //switch(ex.GetType().ToString())
                //{
                //    case "System.InvalidOperationException":
                //    message = "InvalidOperationException";
                //    break;
                //    case "System.NotSupportedException":
                //    message = "NotSupportedException";
                //    break;
                //    case "System.Web.Services.Protocols.SoapException":
                //    message = "SoapException";
                //    break;
                //    case "System.AggregateException":
                //    message = "AggregateException";
                //    break;
                //    default:
                //    message = ex.Message;
                //    break;
                //}

                HttpClientStatus(message);
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
                    response.EnsureSuccessStatusCode();
                var orderData =
                    await Task.FromResult(response.Content.ReadAsAsync<IEnumerable<Order>>().Result);
                return orderData.ToList();
            }
            catch(Exception ex)
            {
                string message;

                if(ex is FormatException)
                {
                    // write to a log, whatever...
                    message = "FormatException";
                }
                else if(ex is OverflowException)
                {
                    // write to a log, whatever...
                    message = "OverflowException";
                }
                else if(ex is ArgumentNullException)
                {
                    // write to a log, whatever...
                    message = "ArgumentNullException";
                }
                else if(ex is HttpRequestException)
                {
                    // write to a log, whatever...
                    message = "HttpRequestException";
                }
                else
                {
                    message = ex.Message;
                    //message = "Unknown Error";
                }

                //switch(ex.GetType().ToString())
                //{
                //    case "System.InvalidOperationException":
                //    message = "InvalidOperationException";
                //    break;
                //    case "System.NotSupportedException":
                //    message = "NotSupportedException";
                //    break;
                //    case "System.Web.Services.Protocols.SoapException":
                //    message = "SoapException";
                //    break;
                //    case "System.AggregateException":
                //    message = "AggregateException";
                //    break;
                //    default:
                //    message = ex.Message;
                //    break;
                //}

                HttpClientStatus(message);
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
                string message;

                if(ex is FormatException)
                {
                    // write to a log, whatever...
                    message = "FormatException";
                }
                else if(ex is OverflowException)
                {
                    // write to a log, whatever...
                    message = "OverflowException";
                }
                else if(ex is ArgumentNullException)
                {
                    // write to a log, whatever...
                    message = "ArgumentNullException";
                }
                else if(ex is HttpRequestException)
                {
                    // write to a log, whatever...
                    message = "HttpRequestException";
                }
                else
                {
                    message = ex.Message;
                    //message = "Unknown Error";
                }

                //switch(ex.GetType().ToString())
                //{
                //    case "System.InvalidOperationException":
                //    message = "InvalidOperationException";
                //    break;
                //    case "System.NotSupportedException":
                //    message = "NotSupportedException";
                //    break;
                //    case "System.Web.Services.Protocols.SoapException":
                //    message = "SoapException";
                //    break;
                //    case "System.AggregateException":
                //    message = "AggregateException";
                //    break;
                //    default:
                //    message = ex.Message;
                //    break;
                //}

                HttpClientStatus(message);
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
                if(!response.IsSuccessStatusCode)
                    response.EnsureSuccessStatusCode();
            }
            catch(Exception ex)
            {
                string message;

                if(ex is FormatException)
                {
                    // write to a log, whatever...
                    message = "FormatException";
                }
                else if(ex is OverflowException)
                {
                    // write to a log, whatever...
                    message = "OverflowException";
                }
                else if(ex is ArgumentNullException)
                {
                    // write to a log, whatever...
                    message = "ArgumentNullException";
                }
                else if(ex is HttpRequestException)
                {
                    // write to a log, whatever...
                    message = "HttpRequestException";
                }
                else
                {
                    message = ex.Message;
                    //message = "Unknown Error";
                }

                //switch(ex.GetType().ToString())
                //{
                //    case "System.InvalidOperationException":
                //    message = "InvalidOperationException";
                //    break;
                //    case "System.NotSupportedException":
                //    message = "NotSupportedException";
                //    break;
                //    case "System.Web.Services.Protocols.SoapException":
                //    message = "SoapException";
                //    break;
                //    case "System.AggregateException":
                //    message = "AggregateException";
                //    break;
                //    default:
                //    message = ex.Message;
                //    break;
                //}

                HttpClientStatus(message);
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
                    response.EnsureSuccessStatusCode();

                if(!response.IsSuccessStatusCode)
                    return null;
                var paymentData =
                    await Task.FromResult(response.Content.ReadAsAsync<IEnumerable<Payment>>().Result);
                return paymentData.ToList();
            }
            catch(Exception ex)
            {
                string message;

                if(ex is FormatException)
                {
                    // write to a log, whatever...
                    message = "FormatException";
                }
                else if(ex is OverflowException)
                {
                    // write to a log, whatever...
                    message = "OverflowException";
                }
                else if(ex is ArgumentNullException)
                {
                    // write to a log, whatever...
                    message = "ArgumentNullException";
                }
                else if(ex is HttpRequestException)
                {
                    // write to a log, whatever...
                    message = "HttpRequestException";
                }
                else
                {
                    message = ex.Message;
                    //message = "Unknown Error";
                }

                //switch(ex.GetType().ToString())
                //{
                //    case "System.InvalidOperationException":
                //    message = "InvalidOperationException";
                //    break;
                //    case "System.NotSupportedException":
                //    message = "NotSupportedException";
                //    break;
                //    case "System.Web.Services.Protocols.SoapException":
                //    message = "SoapException";
                //    break;
                //    case "System.AggregateException":
                //    message = "AggregateException";
                //    break;
                //    default:
                //    message = ex.Message;
                //    break;
                //}

                HttpClientStatus(message);
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
                if(!response.IsSuccessStatusCode)
                    response.EnsureSuccessStatusCode();
            }
            catch(Exception ex)
            {
                string message;

                if(ex is FormatException)
                {
                    // write to a log, whatever...
                    message = "FormatException";
                }
                else if(ex is OverflowException)
                {
                    // write to a log, whatever...
                    message = "OverflowException";
                }
                else if(ex is ArgumentNullException)
                {
                    // write to a log, whatever...
                    message = "ArgumentNullException";
                }
                else if(ex is HttpRequestException)
                {
                    // write to a log, whatever...
                    message = "HttpRequestException";
                }
                else
                {
                    message = ex.Message;
                    //message = "Unknown Error";
                }

                //switch(ex.GetType().ToString())
                //{
                //    case "System.InvalidOperationException":
                //    message = "InvalidOperationException";
                //    break;
                //    case "System.NotSupportedException":
                //    message = "NotSupportedException";
                //    break;
                //    case "System.Web.Services.Protocols.SoapException":
                //    message = "SoapException";
                //    break;
                //    case "System.AggregateException":
                //    message = "AggregateException";
                //    break;
                //    default:
                //    message = ex.Message;
                //    break;
                //}

                HttpClientStatus(message);
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
                if(!response.IsSuccessStatusCode)
                    response.EnsureSuccessStatusCode();
            }
            catch(Exception ex)
            {
                string message;

                if(ex is FormatException)
                {
                    // write to a log, whatever...
                    message = "FormatException";
                }
                else if(ex is OverflowException)
                {
                    // write to a log, whatever...
                    message = "OverflowException";
                }
                else if(ex is ArgumentNullException)
                {
                    // write to a log, whatever...
                    message = "ArgumentNullException";
                }
                else if(ex is HttpRequestException)
                {
                    // write to a log, whatever...
                    message = "HttpRequestException";
                }
                else
                {
                    message = ex.Message;
                    //message = "Unknown Error";
                }

                //switch(ex.GetType().ToString())
                //{
                //    case "System.InvalidOperationException":
                //    message = "InvalidOperationException";
                //    break;
                //    case "System.NotSupportedException":
                //    message = "NotSupportedException";
                //    break;
                //    case "System.Web.Services.Protocols.SoapException":
                //    message = "SoapException";
                //    break;
                //    case "System.AggregateException":
                //    message = "AggregateException";
                //    break;
                //    default:
                //    message = ex.Message;
                //    break;
                //}

                HttpClientStatus(message);
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
                    response.EnsureSuccessStatusCode();
                var reviewData =
                    await Task.FromResult(response.Content.ReadAsAsync<IEnumerable<Review>>().Result);
                return reviewData.ToList();
            }
            catch(Exception ex)
            {
                string message;

                if(ex is FormatException)
                {
                    // write to a log, whatever...
                    message = "FormatException";
                }
                else if(ex is OverflowException)
                {
                    // write to a log, whatever...
                    message = "OverflowException";
                }
                else if(ex is ArgumentNullException)
                {
                    // write to a log, whatever...
                    message = "ArgumentNullException";
                }
                else if(ex is HttpRequestException)
                {
                    // write to a log, whatever...
                    message = "HttpRequestException";
                }
                else
                {
                    message = ex.Message;
                    //message = "Unknown Error";
                }

                //switch(ex.GetType().ToString())
                //{
                //    case "System.InvalidOperationException":
                //    message = "InvalidOperationException";
                //    break;
                //    case "System.NotSupportedException":
                //    message = "NotSupportedException";
                //    break;
                //    case "System.Web.Services.Protocols.SoapException":
                //    message = "SoapException";
                //    break;
                //    case "System.AggregateException":
                //    message = "AggregateException";
                //    break;
                //    default:
                //    message = ex.Message;
                //    break;
                //}

                HttpClientStatus(message);
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
                if(!response.IsSuccessStatusCode)
                    response.EnsureSuccessStatusCode();
            }
            catch(Exception ex)
            {
                string message;

                if(ex is FormatException)
                {
                    // write to a log, whatever...
                    message = "FormatException";
                }
                else if(ex is OverflowException)
                {
                    // write to a log, whatever...
                    message = "OverflowException";
                }
                else if(ex is ArgumentNullException)
                {
                    // write to a log, whatever...
                    message = "ArgumentNullException";
                }
                else if(ex is HttpRequestException)
                {
                    // write to a log, whatever...
                    message = "HttpRequestException";
                }
                else
                {
                    message = ex.Message;
                    //message = "Unknown Error";
                }

                //switch(ex.GetType().ToString())
                //{
                //    case "System.InvalidOperationException":
                //    message = "InvalidOperationException";
                //    break;
                //    case "System.NotSupportedException":
                //    message = "NotSupportedException";
                //    break;
                //    case "System.Web.Services.Protocols.SoapException":
                //    message = "SoapException";
                //    break;
                //    case "System.AggregateException":
                //    message = "AggregateException";
                //    break;
                //    default:
                //    message = ex.Message;
                //    break;
                //}

                HttpClientStatus(message);
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
                if(!response.IsSuccessStatusCode)
                    response.EnsureSuccessStatusCode();
            }
            catch(Exception ex)
            {
                string message;

                if(ex is FormatException)
                {
                    // write to a log, whatever...
                    message = "FormatException";
                }
                else if(ex is OverflowException)
                {
                    // write to a log, whatever...
                    message = "OverflowException";
                }
                else if(ex is ArgumentNullException)
                {
                    // write to a log, whatever...
                    message = "ArgumentNullException";
                }
                else if(ex is HttpRequestException)
                {
                    // write to a log, whatever...
                    message = "HttpRequestException";
                }
                else
                {
                    message = ex.Message;
                    //message = "Unknown Error";
                }

                //switch(ex.GetType().ToString())
                //{
                //    case "System.InvalidOperationException":
                //    message = "InvalidOperationException";
                //    break;
                //    case "System.NotSupportedException":
                //    message = "NotSupportedException";
                //    break;
                //    case "System.Web.Services.Protocols.SoapException":
                //    message = "SoapException";
                //    break;
                //    case "System.AggregateException":
                //    message = "AggregateException";
                //    break;
                //    default:
                //    message = ex.Message;
                //    break;
                //}

                HttpClientStatus(message);
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
                    response.EnsureSuccessStatusCode();
                var receiptData =
                    await Task.FromResult(response.Content.ReadAsAsync<IEnumerable<Receipt>>().Result);
                return receiptData.ToList();
            }
            catch(Exception ex)
            {
                string message;

                if(ex is FormatException)
                {
                    // write to a log, whatever...
                    message = "FormatException";
                }
                else if(ex is OverflowException)
                {
                    // write to a log, whatever...
                    message = "OverflowException";
                }
                else if(ex is ArgumentNullException)
                {
                    // write to a log, whatever...
                    message = "ArgumentNullException";
                }
                else if(ex is HttpRequestException)
                {
                    // write to a log, whatever...
                    message = "HttpRequestException";
                }
                else
                {
                    message = ex.Message;
                    //message = "Unknown Error";
                }

                //switch(ex.GetType().ToString())
                //{
                //    case "System.InvalidOperationException":
                //    message = "InvalidOperationException";
                //    break;
                //    case "System.NotSupportedException":
                //    message = "NotSupportedException";
                //    break;
                //    case "System.Web.Services.Protocols.SoapException":
                //    message = "SoapException";
                //    break;
                //    case "System.AggregateException":
                //    message = "AggregateException";
                //    break;
                //    default:
                //    message = ex.Message;
                //    break;
                //}

                HttpClientStatus(message);
                throw;
            }
        }

        #endregion

        #region Information

        public static async void SaveInformationAsJsonAsync(Information c)
        {
            _client = new HttpClient(Handler, false) { BaseAddress = new Uri(serverurl) };
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var response = await Task.FromResult(_client.PostAsJsonAsync("api/Information/", c).Result);
                if(!response.IsSuccessStatusCode)
                    response.EnsureSuccessStatusCode();
            }
            catch(Exception ex)
            {
                string message;

                if(ex is FormatException)
                {
                    // write to a log, whatever...
                    message = "FormatException";
                }
                else if(ex is OverflowException)
                {
                    // write to a log, whatever...
                    message = "OverflowException";
                }
                else if(ex is ArgumentNullException)
                {
                    // write to a log, whatever...
                    message = "ArgumentNullException";
                }
                else if(ex is HttpRequestException)
                {
                    // write to a log, whatever...
                    message = "HttpRequestException";
                }
                else
                {
                    message = ex.Message;
                    //message = "Unknown Error";
                }

                //switch(ex.GetType().ToString())
                //{
                //    case "System.InvalidOperationException":
                //    message = "InvalidOperationException";
                //    break;
                //    case "System.NotSupportedException":
                //    message = "NotSupportedException";
                //    break;
                //    case "System.Web.Services.Protocols.SoapException":
                //    message = "SoapException";
                //    break;
                //    case "System.AggregateException":
                //    message = "AggregateException";
                //    break;
                //    default:
                //    message = ex.Message;
                //    break;
                //}

                HttpClientStatus(message);
                throw;
            }
        }

        public static async void DeleteInformationAsync(Information c)
        {
            _client = new HttpClient(Handler, false) { BaseAddress = new Uri(serverurl) };
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var response = await Task.FromResult(_client.DeleteAsync("api/Information/" + c).Result);
                if(!response.IsSuccessStatusCode)
                    response.EnsureSuccessStatusCode();
            }
            catch(Exception ex)
            {
                string message;

                if(ex is FormatException)
                {
                    // write to a log, whatever...
                    message = "FormatException";
                }
                else if(ex is OverflowException)
                {
                    // write to a log, whatever...
                    message = "OverflowException";
                }
                else if(ex is ArgumentNullException)
                {
                    // write to a log, whatever...
                    message = "ArgumentNullException";
                }
                else if(ex is HttpRequestException)
                {
                    // write to a log, whatever...
                    message = "HttpRequestException";
                }
                else
                {
                    message = ex.Message;
                    //message = "Unknown Error";
                }

                //switch(ex.GetType().ToString())
                //{
                //    case "System.InvalidOperationException":
                //    message = "InvalidOperationException";
                //    break;
                //    case "System.NotSupportedException":
                //    message = "NotSupportedException";
                //    break;
                //    case "System.Web.Services.Protocols.SoapException":
                //    message = "SoapException";
                //    break;
                //    case "System.AggregateException":
                //    message = "AggregateException";
                //    break;
                //    default:
                //    message = ex.Message;
                //    break;
                //}

                HttpClientStatus(message);
                throw;
            }
        }

        public static async Task<List<Information>> LoadInformationFromJsonAsync()
        {
            _client = new HttpClient(Handler, false) { BaseAddress = new Uri(serverurl) };
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var response = await Task.FromResult(_client.GetAsync("api/Information/").Result);

                if(!response.IsSuccessStatusCode)
                    response.EnsureSuccessStatusCode();
                var receiptData =
                    await Task.FromResult(response.Content.ReadAsAsync<IEnumerable<Information>>().Result);
                return receiptData.ToList();
            }
            catch(Exception ex)
            {
                string message;

                if(ex is FormatException)
                {
                    // write to a log, whatever...
                    message = "FormatException";
                }
                else if(ex is OverflowException)
                {
                    // write to a log, whatever...
                    message = "OverflowException";
                }
                else if(ex is ArgumentNullException)
                {
                    // write to a log, whatever...
                    message = "ArgumentNullException";
                }
                else if(ex is HttpRequestException)
                {
                    // write to a log, whatever...
                    message = "HttpRequestException";
                }
                else
                {
                    message = ex.Message;
                    //message = "Unknown Error";
                }

                //switch(ex.GetType().ToString())
                //{
                //    case "System.InvalidOperationException":
                //    message = "InvalidOperationException";
                //    break;
                //    case "System.NotSupportedException":
                //    message = "NotSupportedException";
                //    break;
                //    case "System.Web.Services.Protocols.SoapException":
                //    message = "SoapException";
                //    break;
                //    case "System.AggregateException":
                //    message = "AggregateException";
                //    break;
                //    default:
                //    message = ex.Message;
                //    break;
                //}

                HttpClientStatus(message);
                throw;
            }
        }

        #endregion

        public static async void HttpClientStatus(string message)
        {
            // Create the message dialog and set its content
            var messageDialog = new MessageDialog(message);

            messageDialog.Commands.Add(new UICommand("OK", null));

            // Set the command that will be invoked by default
            messageDialog.DefaultCommandIndex = 0;

            // Set the command to be invoked when escape is pressed
            messageDialog.CancelCommandIndex = 0;

            // Show the message dialog
            await messageDialog.ShowAsync();
        }
    }
}