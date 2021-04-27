using System.Collections.Generic;
using BudgetApp.App.Abstract;
using BudgetApp.App.Concrete;
using BudgetApp.Domain.Models;
using System.Linq;

namespace BudgetApp.App.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        public List<Expense> expenses { get; set; }
        private readonly IJsonService _jsonService;

        public ExpenseRepository()
        {
            _jsonService = new JsonService();
            expenses = _jsonService.LoadExpenses();;
            // expenses.Add(new Expense(0,0,""));
        }

        public int AddNewExpense(decimal value, string description)
        {
            int expenseId = expenses.Count + 1;
            Expense expense = new Expense(expenseId, value, description);
            expenses.Add(expense);
            
            _jsonService.SaveExpenses(expenses);
            
            return expenseId;
        }

        public int AddNewExpense(Expense expense)
        {
            expenses.Add(expense);
            _jsonService.SaveExpenses(expenses);
            return expense.Id;
        }

        public int RemoveExpenseById (int id)
        {
            var expense = GetExpenseById(id);
            
            if (expense != null)
            {
                expenses.Remove(expense);
                _jsonService.SaveExpenses(expenses);
                return id;
            }
            
            return -1;
        }

        public Expense GetExpenseById (int id) =>
            expenses.FirstOrDefault(e => e.Id == id && id != 0);
    }
}