using System;
using System.Collections.Generic;
using System.Text;

namespace MyExpenses.Models
{
    public enum MenuItemType
    {
        NewExpense,
        History,
        Budgets,        
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
