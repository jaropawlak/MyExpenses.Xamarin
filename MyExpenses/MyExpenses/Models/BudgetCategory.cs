using System;
using System.Collections.Generic;
using System.Text;

namespace MyExpenses.Models
{
    public class BudgetCategory
    {
        public int CategoryId { get; set; }
        public int Budget { get; set; }
        public string Name { get; set; }

        public List<Expense> Expenses { get; set; }
    }
}
