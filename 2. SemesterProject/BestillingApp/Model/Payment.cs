namespace BestillingApp.Model
{
    internal class Payment
    {
        public int AccountNo { get; set; }

        public Payment(int accountNo)
        {
            AccountNo = accountNo;
        } 
    }
}