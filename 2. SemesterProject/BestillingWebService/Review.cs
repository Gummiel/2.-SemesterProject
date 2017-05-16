namespace BestillingWebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Review")]
    public partial class Review
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        public int Stars { get; set; }
    }
}
