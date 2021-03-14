using System;
using BudgetApp.App.Concrete;

namespace BudgetApp.App.Managers
{
    public class ExpenseManager
    {
        ExpenseService expenseService;

        public ExpenseManager()
        {
            expenseService = new ExpenseService();
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

            return expenseService.AddNewExpense(expenseValue, expenseDescription);
        }
        
        public int ExpenseByIdView (int id)
        {
            foreach (var expense in expenseService.expenses)
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
            foreach (var expense in expenseService.expenses)
            {
                if (expense.Id != 0)
                {
                    ExpenseByIdView(expense.Id);
                }
            }
        }

        public int RemoveExpenseByIdView (int id)
        {
            if (expenseService.RemoveExpenseById(id) == id)
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