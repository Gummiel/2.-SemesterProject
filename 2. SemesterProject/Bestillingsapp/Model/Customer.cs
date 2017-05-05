using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatNow
{
    class Customer
    {
        public int customerID { get; set; }

        public string name { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public int telephoneNo { get; set; }
        public int zipcode { get; set; }
        public string city { get; set; }

        public Customer(int customerId, string name, string email, string address, int telephoneNo, int zipcode, string city)
        {
            customerID = customerId;
            this.name = name;
            this.email = email;
            this.address = address;
            this.telephoneNo = telephoneNo;
            this.zipcode = zipcode;
            this.city = city;
        }

    }
}
