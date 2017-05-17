#region References

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#endregion

namespace BestillingWebService
{
    [Table("OrderItem")]
    public class OrderItem
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        public int Amount { get; set; }

        public decimal Price { get; set; }
    }
}