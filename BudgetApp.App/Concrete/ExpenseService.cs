using System;
using System.Collections.Generic;
using BudgetApp.Models;
using BudgetApp.Services;

namespace BudgetApp.App.Concrete
{
    public class ExpenseService
    {
        List<Expense> expenses { get; set; }
        public ExpenseService()
        {
            expenses = new List<Expense>();
            expenses.Add(new Expense(0,0,""));
        }

        public int ExpenseMenuView(MenuActionService actionService)
        {
            var expenseMenu = actionService.GetMenuActionsByMenuName("ExpenseMenu");
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

        public int AddNewExpenseView()
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

            return AddNewExpense(expenseValue, expenseDescription);
        }

        public int AddNewExpense(decimal value, string description)
        {
            int expenseId = expenses[expenses.Count-1].Id + 1;
            Expense expense = new Expense(expenseId, value, description);
            expenses.Add(expense);
            return expenseId;
        }

        public int ExpenseByIdView (int id)
        {
            foreach (var expense in expenses)
            {
                if (expense.Id == id && id != 0)
                {
                    System.Console.WriteLine();
                    System.Console.WriteLine("Id: " + expense.Id);
                    System.Console.WriteLine("Wartość: " + expense.Value);
                    System.Console.WriteLine("Opis: " + expense.ExpenseDescription);
                    System.Console.WriteLine();
                    return id;
                }
            }

            System.Console.WriteLine();
            System.Console.WriteLine("Nie można wydatku o podanym id.");
            System.Console.WriteLine();
            return -1;
        }

        public void AllExpensesView()
        {
            foreach (var expense in expenses)
            {
                if (expense.Id != 0)
                {
                    ExpenseByIdView(expense.Id);
                }
            }
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

            System.Console.WriteLine();
            System.Console.WriteLine("Nie można wydatku o podanym id.");
            System.Console.WriteLine();
            return -1;
        }
    }
}