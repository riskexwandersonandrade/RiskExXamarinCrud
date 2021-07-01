using RiskExXamarinCrud.Models;
using RiskExXamarinCrud.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RiskExXamarinCrud.Views
{
    public partial class NewItemPage : ContentPage
    {
        //public List<string> Manufactures = new List<string>() { "VW", "FIAT", "CHEVROLET" };
        public CarItem Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}