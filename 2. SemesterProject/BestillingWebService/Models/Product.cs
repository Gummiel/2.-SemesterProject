#region References

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#endregion

namespace BestillingWebService
{
    [Table("Product")]
    public class Product
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Brand { get; set; }

        [Required]
        [StringLength(10)]
        public string Weight { get; set; }

        [Required]
        public string Description { get; set; }

        public decimal Price { get; set; }

        public int FK_ProductCatagory { get; set; }

        public virtual ProductCatagory ProductCatagory { get; set; }
    }
}