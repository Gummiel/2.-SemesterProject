#region References

using System;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

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

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            
            if (TextBlockAccountHolder.Text == "" || TextBlockExpireDate.Text == "")
            {
                
                new MessageDialog("Forkert email eller kode");
            }
        }
    }
}