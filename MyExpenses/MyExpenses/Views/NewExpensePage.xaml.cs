using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MyExpenses.Models;
using MyExpenses.ViewModels;
using MyExpenses.Services;
using MyExpenses.Interfaces;

namespace MyExpenses.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewExpensePage : ContentPage
    {
        NewExpenseViewModel viewModel;
       
      
        public NewExpensePage(NewExpenseViewModel model)
        {
            InitializeComponent();           
            BindingContext = viewModel = model;

            MessagingCenter.Subscribe<ItemEditorViewModel>(this, Constants.ExpenseChanged, async (sender) =>
            {
                await DisplayAlert("Success", "Expense was added", "Ok!");

            });

        }
       
    }
}