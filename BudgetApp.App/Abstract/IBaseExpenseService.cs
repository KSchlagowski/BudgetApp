using System.Collections.Generic;

namespace BudgetApp.App.Abstract
{
    public interface IBaseExpenseService<T>
    {
        List<T> Expenses { get; set; }

        List<T> GetAllExpenses();
        int GetLastId();
        T GetExpenseById(int id);
        int AddExpense(T expense);
        int UpdateExpense(T expense);
        void RemoveExpense(T expense);
    }
}