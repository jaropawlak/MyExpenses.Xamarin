using MyExpenses.Interfaces;
using MyExpenses.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyExpenses.Services
{
    public class ProgressCalculator : IProgressCalculator
    {
        private IDataStore _dataStore;

        public ProgressCalculator(IDataStore dataStore)
        {
            _dataStore = dataStore;
        }
        public async Task<List<BudgetProgress>> CalculateProgress()
        {
            var result = new List<BudgetProgress>();
            var categories = await _dataStore.GetBudgetCategoriesAsync();

            foreach (var category in categories)
            {
                var expenses = (await _dataStore.GetExpensesAsync()).Where(e => e.CategoryId == category.CategoryId && e.Date >= new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1));
                var progress = new BudgetProgress { Category = category };
                int current = expenses.Select(e => e.Amount).Aggregate(0M, (sum, i) => sum + i, a => Convert.ToInt32(a));
                int calculated = 100;
                if (progress.Category.Bugdet > 0)
                {
                    calculated = current * 100 / progress.Category.Bugdet;
                }
                if (calculated > 100)
                {
                    calculated = 100;
                }
                var remaining = 100 - calculated;
                if (calculated<=50)
                {
                    progress.Color = Xamarin.Forms.Color.Green;
                }
                else if (calculated <= 75)
                {
                    progress.Color = Xamarin.Forms.Color.Yellow;
                }
                else
                {
                    progress.Color = Xamarin.Forms.Color.Red;
                }
                progress.Progress = new GridLength(calculated, GridUnitType.Star);
                progress.Remaining = new GridLength(remaining, GridUnitType.Star);
                result.Add(progress);
            }

            return result;
        }
    }
}
