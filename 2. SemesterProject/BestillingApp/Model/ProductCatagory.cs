namespace BestillingApp.Model
{
    internal class ProductCatagory
    {
        #region Properties

        public int ID { get; set; }
        public string Name { get; set; }

        #endregion

        #region Constructor

        public ProductCatagory()
        {
        }

        public ProductCatagory(string name)
        {
            Name = name;
        }

        #endregion
    }
}