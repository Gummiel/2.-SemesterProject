using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatNow.Model
{
    class Item
    {
        public int itemID { get; set; }
        public string name { get; set; } 
        public string description { get; set; }
        public double price { get; set; }

        public Item(int itemId, string name, string description, double price)
        {
            itemID = itemId;
            this.name = name;
            this.description = description;
            this.price = price;
        }

    }
}
