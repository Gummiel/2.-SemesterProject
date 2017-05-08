namespace BestillingApp.Model
{
    internal class GasStation
    {
        public GasStation(int id, string name, string address, string city, int zipcode, string email, int telNo,
            string openHours)
        {
            ID = id;
            Name = name;
            Address = address;
            City = city;
            Zipcode = zipcode;
            Email = email;
            TelNo = telNo;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int Zipcode { get; set; }
        public string Email { get; set; }
        public int TelNo { get; set; }
    }
}