using RiskExXamarinCrud.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace RiskExXamarinCrud.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemDetailViewModel();
        }

        private void DeleteClicked(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () => {
                var result = await DisplayAlert("", "Confirma?", "Sim", "Não");
                if (result) viewModel.OnDeleteItem();
            });
        }

        private void EditClicked(object sender, EventArgs e)
        {
            viewModel.OnEditItem();
        }

        //private void SaveClicked(object sender, EventArgs eventArgs)
        //{
        //    viewModel.Car = "bla bla bla";
        //    DisplayAlert("save option", "save was selected", "b1", "b2");
        //}

        //private void CancelClicked(object sender, EventArgs eventArgs)
        //{
        //    DisplayAlert("cancel option", "cancel was selected", "b1", "b2");
        //}
    }
}