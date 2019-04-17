using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MyExpenses.Models;
using MyExpenses.Views;
using MyExpenses.ViewModels;
using MyExpenses.Services;

namespace MyExpenses.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;
        private PageNavigator _pageNavigator;

        public ItemsPage(ItemsViewModel model, PageNavigator pageNavigator)
        {
            _pageNavigator = pageNavigator;

            InitializeComponent();

            BindingContext = viewModel = model;
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Expense;
            if (item == null)
                return;

            await Navigation.PushAsync(_pageNavigator.ItemDetailPageForExpense(item));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}