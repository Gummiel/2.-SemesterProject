#region References

using System.Data.Entity;
using BestillingWebService.Models;

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
            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Receipt)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.FK_Customer_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Review)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.FK_Customer);

            modelBuilder.Entity<GasStation>()
                .HasMany(e => e.Receipt)
                .WithRequired(e => e.GasStation)
                .HasForeignKey(e => e.FK_GasStation_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GasStation>()
                .HasMany(e => e.Review)
                .WithRequired(e => e.GasStation)
                .HasForeignKey(e => e.FK_GasStation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.TotalPrice)
                .HasPrecision(9, 2);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.Receipt)
                .WithRequired(e => e.Order)
                .HasForeignKey(e => e.FK_Order_ID)
                .WillCascadeOnDelete(false);

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
        }
    }
}