#region References

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

#endregion

namespace BestillingWebService.Models
{
    [Table("Order")]
    public class Order
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            Receipt = new HashSet<Receipt>();
        }

        public int ID { get; set; }

        public decimal TotalPrice { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Receipt> Receipt { get; set; }
    }
}