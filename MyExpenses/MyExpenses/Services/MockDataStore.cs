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
            var mockItems = new List<Expense>
            {
                new Expense { Id = Guid.NewGuid().ToString(), Amount = 12, Date = DateTime.Now, Description="This is an item description." },
                new Expense {Id = Guid.NewGuid().ToString(),Amount = 12, Date = DateTime.Now, Description="This is an item description." },
                new Expense {Id = Guid.NewGuid().ToString(),Amount = 12, Date = DateTime.Now, Category = "Third item", Description="This is an item description." },
                new Expense {Id = Guid.NewGuid().ToString(),Amount = 12, Date = DateTime.Now, Category = "Fourth item", Description="This is an item description...hird." },
                new Expense {Id = Guid.NewGuid().ToString(),Amount = 12, Date = DateTime.Now, Category = "Fifth item", Description="This is an item description." },
                new Expense {Id = Guid.NewGuid().ToString(),Amount = 12, Date = DateTime.Now, Category = "Sixth item", Description="This is an item description." },
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Expense item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Expense item)
        {
            var oldItem = items.Where((Expense arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Expense arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Expense> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Expense>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}