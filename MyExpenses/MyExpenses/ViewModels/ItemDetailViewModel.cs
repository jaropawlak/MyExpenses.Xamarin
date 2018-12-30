using System;

using MyExpenses.Models;

namespace MyExpenses.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Expense Item { get; set; }
        public ItemDetailViewModel(Expense item = null)
        {
            Title = item?.Category;
            Item = item;
        }
    }
}
