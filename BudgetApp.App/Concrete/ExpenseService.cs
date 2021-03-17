using System;
using System.Collections.Generic;
using BudgetApp.App.Abstract;
using BudgetApp.Domain.Models;
using System.Linq;

namespace BudgetApp.App.Concrete
{
    public class ExpenseService : IExpenseService
    {
        public List<Expense> expenses { get; set; }

        public ExpenseService()
        {
            expenses = new List<Expense>();
            expenses.Add(new Expense(0,0,""));
        }

        public int AddNewExpense(decimal value, string description)
        {
            int expenseId = expenses[expenses.Count-1].Id + 1;
            Expense expense = new Expense(expenseId, value, description);
            expenses.Add(expense);
            return expenseId;
        }

        public int AddNewExpense(Expense expense)
        {
            expenses.Add(expense);
            return expense.Id;
        }

        public int RemoveExpenseById (int id)
        {
            foreach (var expense in expenses)
            {
                if (expense.Id == id && id != 0)
                {
                    expenses.Remove(expense);
                    return id;
                }
            }

            return -1;
        }

        public Expense GetExpenseById (int id)
        {
            foreach (var expense in expenses)
            {
                if (expense.Id == id && id != 0)
                {
                    return expense;
                }
            }

            return null;
        }
    }
}