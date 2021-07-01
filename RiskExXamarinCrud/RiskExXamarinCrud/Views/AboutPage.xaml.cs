using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RiskExXamarinCrud.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        private void EnterClicked(object sender, EventArgs eventArgs)
        {
            DisplayAlert("WELCOME 2", "XAMARIN", "b1", "b2");
        }
    }
}