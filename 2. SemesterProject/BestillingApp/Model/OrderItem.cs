namespace BestillingApp.Model
{
    internal class OrderItem
    {
        public string Description { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }

        public OrderItem(string description, int amount, double price)
        {
            Description = description;
            Amount = amount;
            Price = price;
        }
    }
}