namespace BestillingApp.Model
{
    internal class Payment
    {
        public Payment(int accountNo)
        {
            AccountNo = accountNo;
        }

        public int AccountNo { get; set; }
    }
}