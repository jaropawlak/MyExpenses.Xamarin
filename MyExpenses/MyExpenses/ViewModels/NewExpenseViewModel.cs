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
    public class NewExpenseViewModel : BaseViewModel
    {
        public Command AddExpenseCommand { get; set; }

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

        public NewExpenseViewModel()
        {
            Categories = new ObservableCollection<BudgetCategory>();
            Item = new Expense();
            AddExpenseCommand = new Command(async () => await ExecuteAddExpenseCommand());
            MessagingCenter.Subscribe<DatabaseRepository>(this, "CategoriesChanged", async (sender) => await UpdateCategories());
            UpdateCategories().Wait();
        }

        ~NewExpenseViewModel()
        {
            MessagingCenter.Unsubscribe<DatabaseRepository>(this, "CategoriesChanged");
        }
        public Expense Item { get; set; }

        async Task ExecuteAddExpenseCommand()
        {
            Item.PaymentType = (PaymentType)Enum.Parse(typeof(PaymentType), PaymentTypes[SelectedPaymentTypeIndex]);
            await App.Repository.AddExpenseAsync(Item);
            Item = new Expense();
        }
        async Task UpdateCategories()
        {
            Categories.Clear();
            foreach (var i in await App.Repository.GetCategoriesAsync())
            {
                Categories.Add(i);
            }
            
        }
    }
    

}
