using MyExpenses.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyExpenses.ViewModels
{
    class BudgetsViewModel
    {
        public Command AddNewItemCommand { get; set; }
        public Command SaveChangesCommand { get; set; }
        public ObservableCollection<BudgetCategory> BudgetCategories { get; set; }

        public BudgetsViewModel()
        {
            AddNewItemCommand = new Command(async () => await AddNewItem());
            SaveChangesCommand = new Command(async () => await SaveChanges());
            BudgetCategories = new ObservableCollection<BudgetCategory>( ReadCategories().Result);            
        }

        public async Task SaveChanges()
        {
            await App.Repository.SaveChangesAsync();
            MessagingCenter.Send<DatabaseRepository>(App.Repository, "CategoriesChanged");
        }

        internal async Task Delete(BudgetCategory budgetCategory)
        {
            await App.Repository.DeleteCategoryAsync(budgetCategory.CategoryId);
            BudgetCategories.Remove(budgetCategory);
        }
        internal void Update(BudgetCategory budgetCategory)
        {
            App.Repository.UpdateCategory(budgetCategory);
        }

        private async Task<IList<BudgetCategory>> ReadCategories()
        {
            return await App.Repository.GetCategoriesAsync();
        }

        private async Task AddNewItem()
        {
            var newItem = new BudgetCategory();
            BudgetCategories.Add(newItem);
            await App.Repository.AddCategoryAsync(newItem);
        }
    }
}
