namespace BestillingApp.Model
{
    internal class OrderItem
    {
        #region Constructor

        public OrderItem(string description, int amount, double price)
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

        public string Description { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }

        #endregion
    }
}