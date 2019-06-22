using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MyExpenses.Models;
using MyExpenses.ViewModels;
using MyExpenses.Services;

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
            
        }
       
    }
}