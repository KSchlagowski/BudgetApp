using System;
using System.Collections.Generic;
using System.Linq;
using BudgetApp.App.Abstract;
using BudgetApp.App.Concrete;
using BudgetApp.App.Repositories;
using BudgetApp.Domain.Models;

namespace BudgetApp.App.Managers
{
    public class ExpenseManager
    {
        private readonly IExpenseService _expenseService;
        private readonly IMenuActionService _actionService;

        public ExpenseManager(IMenuActionService actionService, IExpenseService expenseService)
        {
            _actionService = actionService;
            _expenseService = expenseService;
        }
        
        public int ShowExpenseMenu()
        {
            var expenseMenu = _actionService.GetMenuActionsByMenuName("ExpenseMenu");
            Console.WriteLine("Wydatki.");
            
            for (int i = 0; i < expenseMenu.Count; i++)
            {
                Console.WriteLine($"{expenseMenu[i].Id}. {expenseMenu[i].Name}");
            }
            System.Console.WriteLine();

            string readedOperation = Console.ReadLine();
            int operation;
            Int32.TryParse(readedOperation, out operation);
            System.Console.WriteLine();

            return operation;
        }

        public int ShowAddNewExpense()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Podaj wartość wydatku:");
            System.Console.WriteLine();
            decimal expenseValue;
            string readedExpenseValue = Console.ReadLine();
            Decimal.TryParse(readedExpenseValue, out expenseValue);

            System.Console.WriteLine();
            System.Console.WriteLine("Podaj opis wydatku:");
            System.Console.WriteLine();
            string expenseDescription = Console.ReadLine();
            System.Console.WriteLine();

            return _expenseService.AddNewExpense(expenseValue, expenseDescription);
        }
        
        public void ShowGetExpenseById (int id)
        {
            Expense expense = _expenseService.GetExpenseById(id);

            if (expense != null)
            {
                System.Console.WriteLine();
                System.Console.WriteLine("Id: " + expense.Id);
                System.Console.WriteLine("Wartość: " + expense.Value);
                System.Console.WriteLine("Opis: " + expense.Description);
                System.Console.WriteLine();
            }
            else
            {
                System.Console.WriteLine();
                System.Console.WriteLine("Nie ma wydatku o podanym id.");
                System.Console.WriteLine();
            }
        }

        public void ShowAllExpenses() => 
            _expenseService.GetAllExpenses().Where(e => e.Id != 0).ToList().ForEach(e => ShowGetExpenseById(e.Id));

        public int ShowRemoveExpenseById (int id)
        {
            if (_expenseService.RemoveExpenseById(id) == id)
            {
                return id;
            }
            else
            {
                System.Console.WriteLine();
                System.Console.WriteLine("Nie można wydatku o podanym id.");
                System.Console.WriteLine();
                return -1;
            }
        }
    }
}