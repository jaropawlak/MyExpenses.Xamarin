using MyExpenses.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenses.ViewModels
{
    public class NewExpenseViewModel : BaseViewModel
    {
        public NewExpenseViewModel()
        {
            Item = new Expense();
        }
        public Expense Item { get; set; }

        //public async Task<IEnumerable<BudgetCategory>> GetCategories()
        //{
           
        //}
    }
    

}
