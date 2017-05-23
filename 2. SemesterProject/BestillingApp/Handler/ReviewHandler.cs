#region References

using BestillingApp.ViewModel;

#endregion

namespace BestillingApp.Handler
{
    internal class ReviewHandler
    {
        public ReviewHandler(ReviewViewModel reviewViewModel)
        {
            ReviewViewModel = reviewViewModel;
        }

        public ReviewViewModel ReviewViewModel { get; set; }
    }
}