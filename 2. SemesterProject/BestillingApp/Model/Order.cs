namespace BestillingApp.Model
{
    internal class Order
    {
        #region Constructor

        public Order(int totalPrice)
        {
            TotalPrice = totalPrice;
        }

        public Order()
        {
        }

        #endregion

        #region Properties

        public int ID { get; set; }
        public double TotalPrice { get; set; }

        #endregion
    }
}