namespace BestillingApp.Model
{
    internal class OrderItem
    {
        #region Constructor

        public OrderItem(string description, int amount, decimal price)
        {
            Description = description;
            Amount = amount;
            Price = price;
        }

        public OrderItem()
        {
        }

        #endregion

        #region Properties

        public int ID { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }

        #endregion
    }
}