namespace BestillingApp.Model
{
    internal class Payment
    {
        #region Properties

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