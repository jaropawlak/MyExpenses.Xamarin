using System;
using System.Collections.Generic;
using System.Text;

namespace MyExpenses.Models
{
    public class BudgetCategory
    {
        public int CategoryId { get; set; }
        public decimal Bugdet { get; set; }
        public string Name { get; set; }

        public List<Expense> Expenses { get; set; }
    }
}
