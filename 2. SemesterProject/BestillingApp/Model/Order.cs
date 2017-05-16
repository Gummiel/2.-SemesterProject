namespace BestillingApp.Model
{
    internal class Order
    {
        #region Constructor

        public Order(decimal totalPrice)
        {
            TotalPrice = totalPrice;
        }

        public Order()
        {
        }

        #endregion

        #region Properties

        public int ID { get; set; }
        public decimal TotalPrice { get; set; }

        #endregion
    }
}