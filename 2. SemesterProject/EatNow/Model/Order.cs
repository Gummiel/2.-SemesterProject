using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatNow.Model
{
    class Order
    {
        public int orderID { get; set; }
        public double totalPrice { get; set; }

        public Order(int orderId, int totalPrice)
        {
            orderID = orderId;
            this.totalPrice = totalPrice;
        }
    }
}
