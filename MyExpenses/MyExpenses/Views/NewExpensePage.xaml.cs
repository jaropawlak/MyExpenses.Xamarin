using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MyExpenses.Models;
using MyExpenses.ViewModels;

namespace MyExpenses.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewExpensePage : ContentPage
    {
        NewExpenseViewModel viewModel;
       
      
        public NewExpensePage()
        {
            InitializeComponent();           
            BindingContext = viewModel = new NewExpenseViewModel();
        }
       
    }
}