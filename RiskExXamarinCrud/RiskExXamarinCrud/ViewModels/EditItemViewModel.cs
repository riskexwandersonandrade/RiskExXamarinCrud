using RiskExXamarinCrud.Models;
using RiskExXamarinCrud.Views;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RiskExXamarinCrud.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class EditItemViewModel : BaseViewModel
    {
        private string itemId;
        private string car;
        private string manufacturer;
        public string Id { get; set; }
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

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

        public EditItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged += (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(car) && !String.IsNullOrWhiteSpace(manufacturer);
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

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            CarItem editItem = new CarItem()
            {
                Id = ItemId,
                Car = Car,
                Manufacturer = Manufacturer
            };

            await CarDataStore.UpdateCarAsync(editItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
