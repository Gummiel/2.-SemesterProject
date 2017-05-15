namespace BestillingWebService
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BestillingContext : DbContext
    {
        public BestillingContext()
            : base("name=BestillingContext")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<GasStation> GasStation { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<ItemType> ItemType { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderItem> OrderItem { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Receipt> Receipt { get; set; }
        public virtual DbSet<Review> Review { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .Property(e => e.Price)
                .HasPrecision(7, 2);

            modelBuilder.Entity<ItemType>()
                .HasMany(e => e.Item)
                .WithOptional(e => e.ItemType1)
                .HasForeignKey(e => e.ItemType);

            modelBuilder.Entity<Order>()
                .Property(e => e.TotalPrice)
                .HasPrecision(9, 2);

            modelBuilder.Entity<OrderItem>()
                .Property(e => e.Price)
                .HasPrecision(7, 2);

            modelBuilder.Entity<Receipt>()
                .Property(e => e.TotalPrice)
                .HasPrecision(9, 2);

            modelBuilder.Entity<Receipt>()
                .Property(e => e.Price)
                .HasPrecision(7, 2);
        }
    }
}
