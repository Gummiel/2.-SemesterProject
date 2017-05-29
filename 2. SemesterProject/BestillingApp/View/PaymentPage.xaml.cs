#region References

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using BestillingApp.ViewModel;

#endregion

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BestillingApp.View
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PaymentPage : Page
    {
        public PaymentPage()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var payment =
                await
                    PaymentViewModel.OrderHandler.Pay(TextBoxAccountHolder.Text, TextBoxExpireDateMonth.Text,
                        TextBoxExpireDateYear.Text, TextBoxCVCNumber.Text, TextBoxCreditCardNumber.Text);
            if (payment)
                Frame.Navigate(typeof(ReceiptPage));


            //if (TextBoxAccountHolder.Text != "" && TextBoxExpireDateMonth.Text != "" && TextBoxExpireDateYear.Text != "" && TextBoxCVCNumber.Text != "" && TextBoxCreditCardNumber.Text != "")
            //{
            //    Frame.Navigate(typeof(ReceiptPage));
            //}
            //else
            //{
            //    await new MessageDialog("DER ER FELTER SOM IKKE ER UDFYLDT").ShowAsync();

            //    Regex onlynumbers = new Regex("^[0-9]*$");
            //    Regex onlyletters = new Regex("^[a-zA-Z]*$");
            //    if (!onlyletters.IsMatch(TextBoxAccountHolder.Text))
            //    {
            //        await new MessageDialog("DER MÅ IKKE VÆRE TAL I KORTHOLDER").ShowAsync();
            //        TextBoxAccountHolder.Text = "";
            //    }
            //    if (!onlynumbers.IsMatch(TextBoxCreditCardNumber.Text))
            //    {
            //        await new MessageDialog("DER MÅ IKKE VÆRE BOGSTAVER I KORTNUMMER").ShowAsync();
            //        TextBoxCreditCardNumber.Text = "";
            //    }
            //}

            //else
            //{
            //    throw new ArgumentException("Only alphanumeric characters may be used");
            //}
        }
    }
}