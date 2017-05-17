#region References

using System.ComponentModel.DataAnnotations;

#endregion

namespace BestillingWebService
{
    public class Information
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string WhoAreWeTitle { get; set; }

        [Required]
        public string WhoAreWeSection1 { get; set; }

        [Required]
        public string WhoAreWeSection2 { get; set; }

        [Required]
        public string WhoAreWeSection3 { get; set; }

        [Required]
        [StringLength(50)]
        public string AboutUsTitle { get; set; }

        [Required]
        public string AboutUsSection1 { get; set; }

        [Required]
        public string AboutUsSection2 { get; set; }

        [Required]
        public string AboutUsSection3 { get; set; }

        [Required]
        [StringLength(50)]
        public string PaymentTitle { get; set; }

        [Required]
        public string PaymentSection1 { get; set; }

        [Required]
        public string PaymentSection2 { get; set; }

        [Required]
        public string PaymentSection3 { get; set; }

        public int FK_GasStationID { get; set; }
    }
}