using System;

namespace MyExpenses.Models
{
    public class Expense
    {
        public string Id { get; set; }
        public decimal Amount { get; set; }
        public string PaymentType { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}