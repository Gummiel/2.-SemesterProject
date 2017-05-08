namespace BestillingApp.Model
{
    internal class Item
    {
        public Item(int id, string name, string description, double price)
        {
            ID = id;
            Name = name;
            Description = description;
            Price = price;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}