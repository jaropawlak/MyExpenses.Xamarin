using MyExpenses.Models;
using MyExpenses.ViewModels;
using MyExpenses.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Internals;

namespace MyExpenses.Services
{
    public class PageNavigator
    {
        private Func<Expense, ItemDetailViewModel> _itemDetailViewModel;
        private Func<ItemDetailViewModel, ItemDetailPage> _itemDetailPage;
        [Preserve]
        public PageNavigator(Func<AboutPage> aboutPage, 
            Func<NewExpensePage> newExpensePage, 
            Func<Expense, ItemDetailViewModel> itemDetailViewModel, 
            Func<ItemDetailViewModel, ItemDetailPage> itemDetailPage, 
            Func<BudgetsPage> budgetsPage, 
            Func<ItemsPage> itemsPage)//,MenuPage menuPage)
        {
            AboutPage = aboutPage;
            NewExpensePage = newExpensePage;
            BudgetsPage = budgetsPage;
            ItemsPage = itemsPage;

            _itemDetailViewModel = itemDetailViewModel;
            _itemDetailPage = itemDetailPage;            
        }

        public Func<AboutPage> AboutPage { get; }        
        public Func<NewExpensePage> NewExpensePage { get; }
        public Func<ItemsPage> ItemsPage { get; }        
        public Func<BudgetsPage> BudgetsPage { get; }
        public ItemDetailPage ItemDetailPageForExpense(Expense expense)
        {
            return _itemDetailPage(_itemDetailViewModel(expense));
        }
    }
}
