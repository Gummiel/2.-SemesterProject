namespace Bestillingsapp.Model
{
    internal class Review
    {
        public Review(int id, string description, int stars)
        {
            ID = id;
            Description = description;
            Stars = stars;
        }

        public int ID { get; set; }
        public string Description { get; set; }
        public int Stars { get; set; }
    }
}