using MyExpenses.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyExpenses.Services
{
    public interface IDataStore
    {
        Task<bool> AddExpenseAsync(Expense item);
        Task<bool> UpdateExpenseAsync(Expense item);
        Task<bool> DeleteExpenseAsync(int id);
        Task<Expense> GetExpenseAsync(int id);
        Task<IEnumerable<Expense>> GetExpensesAsync(bool forceRefresh = false);

        Task<bool> AddBudgetCategoryAsync(BudgetCategory item);
        Task<bool> UpdateBudgetCategoryAsync(BudgetCategory item);
        Task<bool> DeleteBudgetCategoryAsync(int id);
        Task<BudgetCategory> GetBudgetCategoryAsync(int id);
        Task<IEnumerable<BudgetCategory>> GetBudgetCategoriesAsync(bool forceRefresh = false);
    }
}
