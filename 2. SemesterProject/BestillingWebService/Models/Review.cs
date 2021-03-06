#region References

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#endregion

namespace BestillingWebService.Models
{
    [Table("Review")]
    public class Review
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        public int Stars { get; set; }

        public int FK_GasStation { get; set; }

        public int? FK_Customer { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual GasStation GasStation { get; set; }
    }
}