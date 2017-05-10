namespace BestillingApp.Model
{
    internal class Customer
    {
        public Customer(int id, string name, string email, string address, int telNo, int zipcode, string city)

        {
            ID = id;
            Name = name;
            Email = email;
            Address = address;
            TelNo = telNo;
            Zipcode = zipcode;
            City = city;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int TelNo { get; set; }
        public int Zipcode { get; set; }
        public string City { get; set; }
    }
}