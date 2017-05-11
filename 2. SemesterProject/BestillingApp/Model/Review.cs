namespace BestillingApp.Model
{
    internal class Review
    {
        #region Constructor

        public Review(string description, int stars)
        {
            Description = description;
            Stars = stars;
        }

        public Review()
        {
        }

        #endregion

        #region Properties

        public int ID { get; set; }
        public string Description { get; set; }
        public int Stars { get; set; }

        #endregion
    }
}