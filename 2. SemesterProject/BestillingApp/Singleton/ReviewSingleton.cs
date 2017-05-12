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
        private ObservableCollection<Review> _reviews;

        #endregion

        #region Constructor

        private ReviewSingleton()
        {
        }

        #endregion

        #region LoadReviewAsync

        public async void LoadReviewAsync()
        {
            var reviews = await PersistencyService.LoadReviewsFromJsonAsync();
            if (reviews != null)
                foreach (var rev in reviews)
                    Reviews.Add(rev);
        }

        #endregion

        #region Remove

        public void RemoveReview(Review r)
        {
            //Reviews.Remove(r);
            PersistencyService.DeleteReviewAsync(r);
            //Hvis delete og read er på samme side
            //LoadReviewAsync();
        }

        #endregion

        #region Properties

        public static ReviewSingleton Instance => _instance ?? (_instance = new ReviewSingleton());
        public ObservableCollection<Review> Reviews => _reviews ?? (_reviews = new ObservableCollection<Review>());

        #endregion

        #region Add

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
    }
}