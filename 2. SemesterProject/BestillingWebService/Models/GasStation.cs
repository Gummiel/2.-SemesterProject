#region References

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#endregion

namespace BestillingWebService.Models
{
    [Table("GasStation")]
    public class GasStation
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        public int Zipcode { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        public int TelNo { get; set; }
    }
}