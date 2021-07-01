using RiskExXamarinCrud.Models;
using RiskExXamarinCrud.Views;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RiskExXamarinCrud.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string itemId;
        private string car;
        private string manufacturer;
        public string Id { get; set; }

        //private void EditClicked(object sender, EventArgs eventArgs)
        //{
        //    OnEditItem(itemId);
        //}

        public async void OnDeleteItem()
        {
            await CarDataStore.DeleteCarAsync(itemId);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        public async void OnEditItem()
        {
            await Shell.Current.GoToAsync($"{nameof(EditItemPage)}?{nameof(EditItemViewModel.ItemId)}={itemId}");
        }

        public string Car
        {
            get => car;
            set => SetProperty(ref car, value);
        }

        public string Manufacturer
        {
            get => manufacturer;
            set => SetProperty(ref manufacturer, value);
        }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await CarDataStore.GetCarAsync(itemId);
                Id = item.Id;
                Car = item.Car;
                Manufacturer = item.Manufacturer;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        //private async void OnSaveItem(object obj)
        //{
        //    //await Shell.Current.GoToAsync(nameof(NewItemPage));
        //    DisplayAlert("save option", "save was selected", "b1", "b2");
        //}

        //private async void OnCancelItem(object obj)
        //{
        //    //await Shell.Current.GoToAsync(nameof(NewItemPage));
        //    DisplayAlert("cancel option", "cancel was selected", "b1", "b2");
        //}
    }
}
