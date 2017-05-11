namespace BestillingApp.Model
{
    internal class Item
    {
        #region Constructor

        public Item(string name, string description, double price)
        {
            Name = name;
            Description = description;
            Price = price;
        }

        public Item()
        {
        }

        #endregion

        #region Properties

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        #endregion
    }
}