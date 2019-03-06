using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyExpenses.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddExpenseAsync(T item);
        Task<bool> UpdateExpenseAsync(T item);
        Task<bool> DeleteExpenseAsync(int id);
        Task<T> GetExpenseAsync(int id);
        Task<IEnumerable<T>> GetExpensesAsync(bool forceRefresh = false);
    }
}
