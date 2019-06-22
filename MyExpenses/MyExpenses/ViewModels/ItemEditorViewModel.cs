using MyExpenses.Interfaces;
using MyExpenses.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyExpenses.ViewModels
{
    public class ItemEditorViewModel : BaseViewModel
    {
        public Command AddExpenseCommand { get; set; }
        public Command DeleteCommand { get; set; }
        public Command UpdateCommand { get; set; }

        public event EventHandler<string> ValidationEvent;
        public event EventHandler ExpenseWasModified;

        private Expense _item;
        public Expense Item { get => _item; set => SetProperty(ref _item, value); }

        public ObservableCollection<BudgetCategory> Categories { get; set; }
        public IList<String> PaymentTypes
        {
            get
            {
                return Enum.GetNames(typeof(PaymentType)).ToList();
            }
        }
        public int SelectedPaymentTypeIndex { get; set; }
        //date for datepicke
        public DateTime Date
        {
            get
            {
                return Item.Date.Date;
            }
            set
            {
                Item.Date = value.Add(Time);
            }
        }
        // time for timepicker
        public TimeSpan Time
        {
            get
            {
                return Item.Date.TimeOfDay;
            }
            set
            {
                Item.Date = Date.Add(value);
            }
        }

        public ItemEditorViewModel(IDataStore dataStore, Expense item = null) : base(dataStore)
        {
            AddExpenseCommand = new Command(async () =>
            {
                await ExecuteAddExpenseCommand();               
            });
            DeleteCommand = new Command(async () => await DeleteItemAsync());
            UpdateCommand = new Command(async () => await UpdateItemAsync());

            Categories = new ObservableCollection<BudgetCategory>();
            Item = item ?? new Expense();
            MessagingCenter.Subscribe<BudgetsViewModel>(this, Constants.CategoriesChanged, async (sender) =>
            {
                await UpdateCategories();

            });
            UpdateCategories().Wait();
        }

        async Task UpdateCategories()
        {
            Categories.Clear();
            foreach (var i in await _dataStore.GetBudgetCategoriesAsync())
            {
                Categories.Add(i);
            }

        }

        private void UpdateItem()
        {
            Item.PaymentType = (PaymentType)Enum.Parse(typeof(PaymentType), PaymentTypes[SelectedPaymentTypeIndex]);
        }

        async Task ExecuteAddExpenseCommand()
        {
            UpdateItem();

            if (ValidateData())
            {
                await _dataStore.AddExpenseAsync(Item);
                Device.BeginInvokeOnMainThread(() => MessagingCenter.Send(this, Constants.ExpenseChanged));
                ExpenseWasModified?.Invoke(this, EventArgs.Empty);
                Item = new Expense();
            }
        }

        private bool ValidateData()
        {
            bool status = true;
            if (Item.Amount <= 0)
            {
                ValidationEvent?.Invoke(this, nameof(Item.Amount));
                status = false;
            }

            if (string.IsNullOrWhiteSpace(Item.Description))
            {
                ValidationEvent?.Invoke(this, nameof(Item.Description));
                status = false;
            }
            return status;
        }

        private async Task DeleteItemAsync()
        {
            await _dataStore.DeleteExpenseAsync(Item.Id);
            Device.BeginInvokeOnMainThread(() => MessagingCenter.Send(this, Constants.ExpenseChanged));
            ExpenseWasModified?.Invoke(this, EventArgs.Empty);
        }
        private async Task UpdateItemAsync()
        {
            UpdateItem();

            if (ValidateData())
            {
                await _dataStore.UpdateExpenseAsync(_item);
                Device.BeginInvokeOnMainThread(() => MessagingCenter.Send(this, Constants.ExpenseChanged));
                ExpenseWasModified?.Invoke(this, EventArgs.Empty);
            }
        }

    }
}
