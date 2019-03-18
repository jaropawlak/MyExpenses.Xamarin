using MyExpenses.Models;
using MyExpenses.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyExpenses.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;
            Detail = new NavigationPage(DIService.Resolve<NewExpensePage>());
            MenuPages.Add((int)MenuItemType.NewExpense, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.History:
                        MenuPages.Add(id, new NavigationPage(DIService.Resolve<ItemsPage>()));
                        break;
                    case (int)MenuItemType.Budgets:
                        MenuPages.Add(id, new NavigationPage(DIService.Resolve<BudgetsPage>()));
                        break;
                    default:
                    //case (int)MenuItemType.About:
                        MenuPages.Add(id, new NavigationPage(new AboutPage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}