namespace BestillingApp.Model
{
    internal class Payment
    {
        #region Properties

        public int ID { get; set; }
        public int AccountNo { get; set; }

        #endregion

        #region Constructor

        public Payment(int accountNo)
        {
            AccountNo = accountNo;
        }

        public Payment()
        {
        }

        #endregion
    }
}