namespace BestillingApp.Model
{
    internal class Receipt
    {
        #region Constructor

        public Receipt(string name, string email, string address, int telNo, int zipcode, string city, double totalPrice,
            string description, int amount, double price)
        {
            Name = name;
            Email = email;
            Address = address;
            TelNo = telNo;
            Zipcode = zipcode;
            City = city;
            TotalPrice = totalPrice;
            Description = description;
            Amount = amount;
            Price = price;
        }

        public Receipt()
        {
        }

        #endregion

        #region Properties

        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int TelNo { get; set; }
        public int Zipcode { get; set; }
        public string City { get; set; }
        public double TotalPrice { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }

        #endregion
    }
}