using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyExpenses.Models;

namespace MyExpenses.Services
{
    public class MockDataStore : IDataStore<Expense>
    {
        List<Expense> items;

        public MockDataStore()
        {
            items = new List<Expense>();
            var mockExpenses = new List<Expense>
            {
                new Expense { Id =1, Amount = 12, Date = DateTime.Now, Description="This is an item description." },
                new Expense {Id = 2,Amount = 12, Date = DateTime.Now, Description="This is an item description." },
                new Expense {Id = 3,Amount = 12, Date = DateTime.Now, Category = new BudgetCategory { Name = "Category1" }, Description="This is an item description." },
                new Expense {Id =4,Amount = 12, Date = DateTime.Now, Category =  new BudgetCategory { Name = "Category1" }, Description="This is an item description...hird." },
                new Expense {Id =5,Amount = 12, Date = DateTime.Now, Category =  new BudgetCategory { Name = "Category1" }, Description="This is an item description." },
                new Expense {Id = 6,Amount = 12, Date = DateTime.Now, Category = new BudgetCategory { Name = "Category1" }, Description="This is an item description." },
            };

            foreach (var item in mockExpenses)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddExpenseAsync(Expense item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateExpenseAsync(Expense item)
        {
            var oldExpense = items.Where((Expense arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldExpense);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteExpenseAsync(int id)
        {
            var oldExpense = items.Where((Expense arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldExpense);

            return await Task.FromResult(true);
        }

        public async Task<Expense> GetExpenseAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Expense>> GetExpensesAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}