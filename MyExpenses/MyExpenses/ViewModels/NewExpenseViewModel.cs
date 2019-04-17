using MyExpenses.Interfaces;
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
        private Expense _item;
        public Expense Item { get => _item; set => SetProperty(ref _item, value); }
        public Command AddExpenseCommand { get; set; }

       
        private readonly IProgressCalculator _progressCalculator;
       
        public ObservableCollection<BudgetCategory> Categories { get; set; }

        public ObservableCollection<BudgetProgress> Progress { get; set; }
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

        public NewExpenseViewModel(IDataStore dataStore, IProgressCalculator progressCalculator) :base (dataStore)
        {            
            _progressCalculator = progressCalculator;

            var _task = _progressCalculator.CalculateProgress();
            Categories = new ObservableCollection<BudgetCategory>();
            Item = new Expense();
            AddExpenseCommand = new Command(async () =>
            {
                await ExecuteAddExpenseCommand();
                Progress = new ObservableCollection<BudgetProgress>(await _progressCalculator.CalculateProgress());
            }
            );
            MessagingCenter.Subscribe<BudgetsViewModel>(this, "CategoriesChanged", async (sender) =>
            {
                await UpdateCategories();
                Progress = new ObservableCollection<BudgetProgress>(await _progressCalculator.CalculateProgress());
            }
            );
            UpdateCategories().Wait();
            Progress = new ObservableCollection<BudgetProgress>(_task.Result);
        }

       

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
