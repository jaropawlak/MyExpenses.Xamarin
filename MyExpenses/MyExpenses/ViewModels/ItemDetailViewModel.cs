using System;
using System.Threading.Tasks;
using MyExpenses.Interfaces;
using MyExpenses.Models;
using Xamarin.Forms;

namespace MyExpenses.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        private Expense _item;
        public Expense Item { get => _item; set => SetProperty(ref _item, value); }
        public Command DeleteCommand { get; set; }
        public Command UpdateCommand { get; set; }
        public ItemDetailViewModel(Expense item, IDataStore dataStore):base(dataStore)
        {
            Title = item?.Category?.Name;
            Item = item;

            DeleteCommand = new Command(async () => await DeleteItemAsync() );
            UpdateCommand = new Command(async () => await UpdateItemAsync());
        }

        private async Task DeleteItemAsync()
        {
            await _dataStore.DeleteExpenseAsync(Item.Id);
        }
        private async Task UpdateItemAsync()
        {
            await _dataStore.UpdateExpenseAsync(_item);
        }
    }
}
