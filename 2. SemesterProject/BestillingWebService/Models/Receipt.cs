#region References

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#endregion

namespace BestillingWebService.Models
{
    [Table("Receipt")]
    public class Receipt
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        public int? TelNo { get; set; }

        public int? Zipcode { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        public decimal? TotalPrice { get; set; }

        public string Description { get; set; }

        public int? Amount { get; set; }

        public decimal? Price { get; set; }
    }
}