using RiskExXamarinCrud.Services;
using RiskExXamarinCrud.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RiskExXamarinCrud
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<CarDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
