namespace BestillingWebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Item")]
    public partial class Item
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Brand { get; set; }

        [StringLength(10)]
        public string Weight { get; set; }

        public string Description { get; set; }

        public decimal? Price { get; set; }

        public int? ItemType { get; set; }

        public virtual ItemType ItemType1 { get; set; }
    }
}
