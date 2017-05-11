namespace BestillingApp.Model
{
    internal class ItemType
    {
        #region Properties

        public int ID { get; set; }
        public string Name { get; set; }

        #endregion

        #region Constructor

        public ItemType()
        {
        }

        public ItemType(string name)
        {
            Name = name;
        }

        #endregion
    }
}