using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatNow.Model
{
    class OrderItem
    {
        public string description { get; set; }
        public int amount { get; set; }
        public double price { get; set; }

        public OrderItem(string description, int amount, double price)
        {
            this.description = description;
            this.amount = amount;
            this.price = price;
        }
    }
}
