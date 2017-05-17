#region References

using System.ComponentModel.DataAnnotations.Schema;

#endregion

namespace BestillingWebService
{
    [Table("Payment")]
    public class Payment
    {
        public int ID { get; set; }

        public int AccountNo { get; set; }
    }
}