using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatNow.Model
{
    class Restauarant
    {
        public int restaurantID { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public int zipcode { get; set; }
        public string email { get; set; }
        public int telephoneNo { get; set; }
        public string openHours { get; set; }

        public Restauarant(int restaurantId, string name, string address, string city, int zipcode, string email, int telephoneNo, string openHours)
        {
            restaurantID = restaurantId;
            this.name = name;
            this.address = address;
            this.city = city;
            this.zipcode = zipcode;
            this.email = email;
            this.telephoneNo = telephoneNo;
            this.openHours = openHours;
        }
    }
}
