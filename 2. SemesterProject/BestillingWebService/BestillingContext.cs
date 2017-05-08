#region References

using System.Data.Entity;

#endregion

namespace BestillingWebService
{
    public class BestillingContext : DbContext
    {
        public BestillingContext()
            : base("name=BestillingContext")
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<GasStation> GasStation { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderItem> OrderItem { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Review> Review { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .Property(e => e.Price)
                .HasPrecision(7, 2);

            modelBuilder.Entity<Order>()
                .Property(e => e.TotalPrice)
                .HasPrecision(9, 2);

            modelBuilder.Entity<OrderItem>()
                .Property(e => e.Price)
                .HasPrecision(7, 2);
        }
    }
}