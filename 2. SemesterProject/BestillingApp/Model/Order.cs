namespace BestillingApp.Model
{
    internal class Order
    {
        public Order(int id, int totalPrice)
        {
            ID = id;
            TotalPrice = totalPrice;
        }

        public int ID { get; set; }
        public double TotalPrice { get; set; }
    }
}