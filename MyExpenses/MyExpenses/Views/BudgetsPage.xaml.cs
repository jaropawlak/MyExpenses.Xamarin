using MyExpenses.Models;
using MyExpenses.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyExpenses.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BudgetsPage : ContentPage
	{
        BudgetsViewModel viewModel;
		public BudgetsPage ()
		{
			InitializeComponent ();
            BindingContext = viewModel = new BudgetsViewModel();
		}

        private async void ContentPage_Disappearing(object sender, EventArgs e)
        {
            await viewModel.SaveChanges();
        }

        private  void Delete_Clicked(object sender, EventArgs e)
        {
            var s = (MenuItem)sender;
            viewModel.Delete(s.CommandParameter as BudgetCategory);

        }
        
    }
}