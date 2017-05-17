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
            Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<GasStation> GasStation { get; set; }
        public virtual DbSet<Information> Information { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderItem> OrderItem { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductCatagory> ProductCatagory { get; set; }
        public virtual DbSet<Receipt> Receipt { get; set; }
        public virtual DbSet<Review> Review { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .Property(e => e.TotalPrice)
                .HasPrecision(9, 2);

            modelBuilder.Entity<OrderItem>()
                .Property(e => e.Price)
                .HasPrecision(7, 2);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(7, 2);

            modelBuilder.Entity<ProductCatagory>()
                .HasMany(e => e.Product)
                .WithRequired(e => e.ProductCatagory)
                .HasForeignKey(e => e.FK_ProductCatagory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Receipt>()
                .Property(e => e.TotalPrice)
                .HasPrecision(9, 2);

            modelBuilder.Entity<Receipt>()
                .Property(e => e.Price)
                .HasPrecision(7, 2);
        }
    }
}