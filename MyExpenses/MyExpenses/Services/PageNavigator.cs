using MyExpenses.Interfaces;
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
        public static string dbPath { get; set; }
        private IDataStore _dataStore = new DatabaseRepository(dbPath);
        private IDataStore DataStore { get => _dataStore; }        
        public AboutPage AboutPage() => new AboutPage(); 
        public NewExpensePage NewExpensePage() => new NewExpensePage(new NewExpenseViewModel(DataStore, new ProgressCalculator(DataStore))); 
        public ItemsPage ItemsPage() => new ItemsPage(new ItemsViewModel(DataStore), this);         
        public BudgetsPage BudgetsPage() => new BudgetsPage(new BudgetsViewModel(DataStore)); 
        public ItemDetailPage ItemDetailPageForExpense(Expense expense) => new ItemDetailPage(new ItemDetailViewModel(expense, DataStore)); 
        public MainPage MainPage() => new MainPage(this);
        
    }
}
