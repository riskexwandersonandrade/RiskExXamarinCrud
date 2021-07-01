using RiskExXamarinCrud.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RiskExXamarinCrud.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        const string USERNAME = "Admin";
        const string PASSWORD = "123";

        LoginViewModel viewModel;

        public LoginPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new LoginViewModel();
        }

        private void LoginClicked(object sender, EventArgs e)
        {
            bool LoginOk =
                !String.IsNullOrWhiteSpace(Username.Text) &&
                !String.IsNullOrWhiteSpace(Password.Text) &&
                Username.Text.Equals(USERNAME) &&
                Password.Text.Equals(PASSWORD);

            if (LoginOk)
            {
                DisplayAlert("", "Congratulations!", "Ok");
                viewModel.OnLoginSuccess();
            }
            else
            {
                DisplayAlert("", "Username/Password invalid", "Ok");
            }
        }
    }
}