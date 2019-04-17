using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using MyExpenses.Models;
using MyExpenses.Views;
using System.Linq;
using System.Text.RegularExpressions;
using MyExpenses.Services;
using MyExpenses.Interfaces;

namespace MyExpenses.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Expense> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        

        /// <summary>
        /// Text filled in search bar
        /// </summary>
        public string SearchText { get; set; }
        /// <summary>
        /// Search param date from
        /// </summary>
        public DateTime DateFrom { get; set; }
        /// <summary>
        /// Search param date to
        /// </summary>
        public DateTime DateTo { get; set; }
       
        public ItemsViewModel(IDataStore dataStore) : base(dataStore)
        {           
            DateFrom = DateTime.Today.AddDays(-7);
            DateTo = DateTime.Today.AddDays(1);

            Title = "History";
            Items = new ObservableCollection<Expense>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());           
        }
        
        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await _dataStore.GetExpensesAsync(true);

                Regex regex = string.IsNullOrEmpty(SearchText) ? null : new Regex(SearchText, RegexOptions.IgnoreCase);
                
                var filtered = items.Where(i => (
                    regex == null || 
                    (i.Category != null && regex.IsMatch(i.Category.Name)) || 
                    (!string.IsNullOrEmpty(i.Description) && regex.IsMatch(i.Description))
                ) && i.Date >= DateFrom && i.Date <= DateTo);
                foreach (var item in filtered)
                    Items.Add(item);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}