#region References

using System.ComponentModel.DataAnnotations.Schema;

#endregion

namespace BestillingWebService.Models
{
    [Table("Order")]
    public class Order
    {
        public int ID { get; set; }

        public decimal TotalPrice { get; set; }
    }
}