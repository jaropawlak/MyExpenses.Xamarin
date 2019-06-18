using MyExpenses.Interfaces;
using MyExpenses.Models;
using MyExpenses.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyExpenses.ViewModels
{
    public class BudgetsViewModel
    {
        private readonly IDataStore _dataStore;

        public Command AddNewItemCommand { get; set; }
        public Command SaveChangesCommand { get; set; }
        public Command DeleteCommand { get; set; }
        public ObservableCollection<BudgetCategory> BudgetCategories { get; set; }

        public BudgetsViewModel(IDataStore dataStore)
        {
            _dataStore = dataStore;
            AddNewItemCommand = new Command(async () => await AddNewItem());
            SaveChangesCommand = new Command(async () => await SaveChanges());
            DeleteCommand = new Command(async (p) => await Delete((BudgetCategory)p));
            BudgetCategories = new ObservableCollection<BudgetCategory>( ReadCategories().Result);            
        }

        public async Task SaveChanges()
        {
            await _dataStore.SaveAsync();  
            MessagingCenter.Send(this, Constants.CategoriesChanged);
        }

        internal async Task Delete(BudgetCategory budgetCategory)
        {
            await _dataStore.DeleteBudgetCategoryAsync(budgetCategory.CategoryId);
            BudgetCategories.Remove(budgetCategory);
        }
        internal  async void Update(BudgetCategory budgetCategory)
        {
            await _dataStore.UpdateBudgetCategoryAsync(budgetCategory);
        }

        private async Task<IEnumerable<BudgetCategory>> ReadCategories()
        {
            return await _dataStore.GetBudgetCategoriesAsync();
        }

        private async Task AddNewItem()
        {
            var newItem = new BudgetCategory();
            BudgetCategories.Add(newItem);
            await _dataStore.AddBudgetCategoryAsync(newItem);
        }
    }
}
