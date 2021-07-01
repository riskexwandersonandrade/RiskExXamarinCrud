using RiskExXamarinCrud.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace RiskExXamarinCrud.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string car;
        private string manufacturer;
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged += (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(car) && !String.IsNullOrWhiteSpace(manufacturer);
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

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            CarItem newItem = new CarItem()
            {
                Id = Guid.NewGuid().ToString(),
                Car = Car,
                Manufacturer = Manufacturer
            };

            await CarDataStore.AddCarAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
