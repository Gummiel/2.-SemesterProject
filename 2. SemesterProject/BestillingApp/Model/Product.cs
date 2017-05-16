namespace BestillingApp.Model
{
    internal class Product
    {
        #region Constructor

        public Product(string name, string brand, string weight, string description, decimal price,
            int fkProductCatagory)
        {
            Name = name;
            Brand = brand;
            Weight = weight;
            Description = description;
            Price = price;
            FK_ProductCatagory = fkProductCatagory;
        }

        public Product()
        {
        }

        #endregion

        #region Properties

        public int ID { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Weight { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int FK_ProductCatagory { get; set; }

        #endregion
    }
}