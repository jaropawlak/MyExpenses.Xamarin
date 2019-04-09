using System;


namespace MyExpenses.Models
{
    public class Expense 
    {

        public Expense()
        {
            Date = DateTime.Now;
        }
        public int Id { get; set; }    
        public decimal Amount { get; set; }
        public PaymentType PaymentType { get; set; }       
        public string Description { get; set; }

        public DateTime Date { get; set; }

        public int? CategoryId { get; set; }
        public BudgetCategory Category { get; set; }
    }
}
