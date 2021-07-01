using RiskExXamarinCrud.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace RiskExXamarinCrud.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        //public Command LoginCommand { get; }

        public LoginViewModel()
        {
            //LoginCommand = new Command(OnLoginSuccess);
        }

        public async void OnLoginSuccess()
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            //await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
            await Shell.Current.GoToAsync($"//{nameof(ItemsPage)}");
        }
    }
}
