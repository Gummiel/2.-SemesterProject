namespace BestillingApp.Model
{
    internal class Item
    {
        #region Constructor

        public Item(string name, string description, decimal price)
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
        public decimal Price { get; set; }

        #endregion
    }
}