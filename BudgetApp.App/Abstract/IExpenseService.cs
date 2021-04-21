using System.Collections.Generic;
using BudgetApp.Domain.Models;

namespace BudgetApp.App.Abstract
{
    public interface IExpenseService
    {
        List<Expense> expenses { get; set; }
        int AddNewExpense(decimal value, string description);
        int AddNewExpense(Expense expense);
        int RemoveExpenseById (int id);
        Expense GetExpenseById (int id);
    }
}