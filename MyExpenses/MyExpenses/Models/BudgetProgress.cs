using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Xamarin.Forms;

namespace MyExpenses.Models
{
    public class BudgetProgress
    {
        public BudgetCategory Category {get;set;}
        public GridLength Progress { get; set; }
        public GridLength Remaining { get; internal set; }
        public Xamarin.Forms.Color Color { get; internal set; }
        public string Description { get; internal set; }
    }
}
