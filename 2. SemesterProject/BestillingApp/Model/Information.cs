namespace BestillingApp.Model
{
    internal class Information
    {
        #region Constructor

        public Information(string whoAreWeTitle, string whoAreWeSection1, string whoAreWeSection2,
            string whoAreWeSection3, string aboutUsTitle, string aboutUsSection1, string aboutUsSection2,
            string aboutUsSection3, string paymentTitle, string paymentSection1, string paymentSection2,
            string paymentSection3, int fkGasStationID)
        {
            WhoAreWeTitle = whoAreWeTitle;
            WhoAreWeSection1 = whoAreWeSection1;
            WhoAreWeSection2 = whoAreWeSection2;
            WhoAreWeSection3 = whoAreWeSection3;
            AboutUsTitle = aboutUsTitle;
            AboutUsSection1 = aboutUsSection1;
            AboutUsSection2 = aboutUsSection2;
            AboutUsSection3 = aboutUsSection3;
            PaymentTitle = paymentTitle;
            PaymentSection1 = paymentSection1;
            PaymentSection2 = paymentSection2;
            PaymentSection3 = paymentSection3;
            FK_GasStationID = fkGasStationID;
        }

        public Information()
        {
        }

        #endregion

        #region Properties

        public int ID { get; set; }
        public string WhoAreWeTitle { get; set; }
        public string WhoAreWeSection1 { get; set; }
        public string WhoAreWeSection2 { get; set; }
        public string WhoAreWeSection3 { get; set; }
        public string AboutUsTitle { get; set; }
        public string AboutUsSection1 { get; set; }
        public string AboutUsSection2 { get; set; }
        public string AboutUsSection3 { get; set; }
        public string PaymentTitle { get; set; }
        public string PaymentSection1 { get; set; }
        public string PaymentSection2 { get; set; }
        public string PaymentSection3 { get; set; }
        public int FK_GasStationID { get; set; }

        #endregion
    }
}