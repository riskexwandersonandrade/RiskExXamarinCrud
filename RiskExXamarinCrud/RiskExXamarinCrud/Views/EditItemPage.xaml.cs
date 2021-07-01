using RiskExXamarinCrud.Models;
using RiskExXamarinCrud.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RiskExXamarinCrud.Views
{
    public partial class EditItemPage : ContentPage
    {
        public CarItem Item { get; set; }

        public EditItemPage()
        {
            InitializeComponent();
            BindingContext = new EditItemViewModel();
        }
    }
}