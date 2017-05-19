#region References

using System;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using BestillingApp.Handler;
using BestillingApp.ViewModel;

#endregion

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BestillingApp.View
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void ButtonLogin_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var customer = LoginViewModel.LoginHandler.Login();
            if(customer != null)
            {
                //navigate to payment if credentials are correct.
                Frame.Navigate(typeof(PaymentPage));
            }
            else
            {
                await new MessageDialog("Forkert email eller kode").ShowAsync();
            }
        }
    }
}