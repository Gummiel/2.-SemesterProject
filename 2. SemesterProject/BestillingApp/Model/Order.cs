namespace BestillingApp.Model
{
    internal class Order
    {
        #region Constructor

        public Order()
        {
            TotalPrice = 0;
        }

        #endregion

        #region Properties

        public int ID { get; set; }

        public decimal TotalPrice { get; set; }

        #endregion
    }
}