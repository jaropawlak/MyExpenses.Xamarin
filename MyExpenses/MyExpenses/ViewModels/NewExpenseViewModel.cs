using MyExpenses.Models;
using MyExpenses.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyExpenses.ViewModels
{
    public class NewExpenseViewModel : BaseViewModel
    {
        public Command AddExpenseCommand { get; set; }

        private readonly IDataStore _dataStore;

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

        public NewExpenseViewModel(IDataStore dataStore)
        {
            _dataStore = dataStore;
            Categories = new ObservableCollection<BudgetCategory>();
            Item = new Expense();
            AddExpenseCommand = new Command(async () => await ExecuteAddExpenseCommand());
            MessagingCenter.Subscribe<BudgetsViewModel>(this, "CategoriesChanged", async (sender) => await UpdateCategories());
            UpdateCategories().Wait();
        }

        private Expense _item;  
        public Expense Item { get => _item; set => SetProperty(ref _item,value); }

        async Task ExecuteAddExpenseCommand()
        {
            Item.PaymentType = (PaymentType)Enum.Parse(typeof(PaymentType), PaymentTypes[SelectedPaymentTypeIndex]);
            await _dataStore.AddExpenseAsync(Item);
            Item = new Expense();
        }
        async Task UpdateCategories()
        {
            Categories.Clear();
            foreach (var i in await _dataStore.GetBudgetCategoriesAsync())
            {
                Categories.Add(i);
            }
            
        }
    }
    

}
