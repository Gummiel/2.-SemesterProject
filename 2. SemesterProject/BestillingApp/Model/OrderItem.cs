namespace BestillingApp.Model
{
    internal class OrderItem
    {
        public OrderItem(string description, int amount, double price)
        {
            Description = description;
            Amount = amount;
            Price = price;
        }

        public string Description { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
    }
}