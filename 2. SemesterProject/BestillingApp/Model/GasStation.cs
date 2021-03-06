namespace BestillingApp.Model
{
    internal class GasStation
    {
        #region Constructor

        public GasStation(string name, string address, string city, int zipcode, string email, int telNo)
        {
            Name = name;
            Address = address;
            City = city;
            Zipcode = zipcode;
            Email = email;
            TelNo = telNo;
        }

        public GasStation()
        {
        }

        #endregion

        #region Properties

        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int Zipcode { get; set; }
        public string Email { get; set; }
        public int TelNo { get; set; }

        #endregion
    }
}