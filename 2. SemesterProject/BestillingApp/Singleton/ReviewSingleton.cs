#region References

using System.Collections.ObjectModel;
using BestillingApp.Model;
using BestillingApp.Persistency;

#endregion

namespace BestillingApp.Singleton
{
    internal class ReviewSingleton
    {
        #region Instancefield

        private static ReviewSingleton _instance;

        #endregion

        #region Constructor

        private ReviewSingleton()
        {
        }

        #endregion

        #region Properties

        public static ReviewSingleton Instance => _instance ?? (_instance = new ReviewSingleton());

        public ObservableCollection<Review> Reviews = new ObservableCollection<Review>();

        #endregion

        #region LoadReviewAsync

        public async void LoadReviewAsync()
        {
            var reviews = await PersistencyService.LoadReviewsFromJsonAsync();
            if (reviews != null)
            {
                foreach (var rev in reviews)
                {
                    reviews.Add(rev);
                }
            }
            else
            {
                //Possibly exception
            }
        }

        #endregion

        #region Add

        public void AddReview(int id, string description, int stars)
        {
            Review newReview = new Review(id, description, stars);
            Reviews.Add(newReview);
            PersistencyService.SaveReviewAsJsonAsync(newReview);
        }

        #endregion

        #region Remove

        public void RemoveReview(Review r)
        {
            Reviews.Remove(r);
            PersistencyService.DeleteReviewAsync(r);
        }

        #endregion
    }
}