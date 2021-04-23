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
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseService(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public List<Expense> GetAllExpenses() => _expenseRepository.expenses;

        public int AddNewExpense(decimal value, string description)
        {
            return _expenseRepository.AddNewExpense(value, description);
        }

        public int AddNewExpense(Expense expense)
        {
            return _expenseRepository.AddNewExpense(expense);
        }

        public Expense GetExpenseById(int id)
        {
            return _expenseRepository.GetExpenseById(id);
        }

        public int RemoveExpenseById(int id)
        {
            return _expenseRepository.RemoveExpenseById(id);
        }
    }
}