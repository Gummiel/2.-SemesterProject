namespace BestillingApp.Model
{
    internal class Customer
    {
        #region Constructor

        public Customer(string name, string email, string password, string address, int telNo, int zipcode, string city)
        {
            Name = name;
            Email = email;
            Password = password;
            Address = address;
            TelNo = telNo;
            Zipcode = zipcode;
            City = city;
        }

        public Customer()
        {
        }

        #endregion

        #region Properties

        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public int TelNo { get; set; }
        public int Zipcode { get; set; }
        public string City { get; set; }

        #endregion
    }
}