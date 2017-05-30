#region References

using System.ComponentModel.DataAnnotations.Schema;

#endregion

namespace BestillingWebService.Models
{
    [Table("Receipt")]
    public class Receipt
    {
        public int ID { get; set; }

        public int FK_GasStation_ID { get; set; }

        public int FK_Customer_ID { get; set; }

        public int FK_Order_ID { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual GasStation GasStation { get; set; }

        public virtual Order Order { get; set; }
    }
}