using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MyExpenses.Models;
using MyExpenses.ViewModels;

namespace MyExpenses.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();            
            BindingContext = this.viewModel = viewModel;
            viewModel.ExpenseWasModified += ViewModel_ExpenseWasModified;
        }

        private void ViewModel_ExpenseWasModified(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}