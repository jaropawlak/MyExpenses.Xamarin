using MyExpenses.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenses.Interfaces
{
    public interface IProgressCalculator
    {
        Task<List<BudgetProgress>> CalculateProgress();
    }
}
