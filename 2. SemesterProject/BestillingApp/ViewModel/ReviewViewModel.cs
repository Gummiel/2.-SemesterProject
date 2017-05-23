#region References

using System.Collections.ObjectModel;
using BestillingApp.Handler;
using BestillingApp.Model;
using BestillingApp.Singleton;

#endregion

namespace BestillingApp.ViewModel
{
    internal class ReviewViewModel
    {
        #region Constructor

        public ReviewViewModel()
        {
            OrderHandler = new OrderHandler(this, null, null, null);
            ReviewSingleton = ReviewSingleton.Instance;
            CustomerSingleton = CustomerSingleton.Instance;
            ReviewSingleton.LoadReviewAsync();
            CustomerSingleton.LoadCustomersAsync();
            OrderHandler.GetReviews();
        }

        #endregion

        #region Properties

        public OrderHandler OrderHandler { get; set; }
        public CustomerSingleton CustomerSingleton { get; set; }
        public ReviewSingleton ReviewSingleton { get; set; }
        public ObservableCollection<Review> ReviewList { get; set; }
        public ObservableCollection<Customer> CustomerList { get; set; }

        #endregion
    }
}