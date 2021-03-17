using System.Collections.Generic;
using System.Linq;
using BudgetApp.App.Abstract;
using BudgetApp.Domain.Common;

namespace BudgetApp.App.Common
{
    public class BaseExpenseService<T> : IBaseExpenseService<T> where T : BaseEntity
    {
        public List<T> Expenses { get; set; }

        public BaseExpenseService()
        {
            Expenses = new List<T>();
        }

        public int AddExpense(T expense)
        {
            Expenses.Add(expense);
            return expense.Id;
        }

        public List<T> GetAllExpenses()
        {
            return Expenses;
        }

        public T GetExpenseById(int id)
        {
            var entity = Expenses.FirstOrDefault(p => p.Id == id);
            return entity;
        }

        public int GetLastId()
        {
            int lastId;
            if (Expenses.Any())
            {
                lastId = Expenses.OrderBy(p => p.Id).LastOrDefault().Id;
            }
            else
            {
                lastId = 0;
            }

            return lastId;
        }

        public void RemoveExpense(T expense)
        {
            Expenses.Remove(expense);
        }

        public int UpdateExpense(T expense)
        {
            var entity = Expenses.FirstOrDefault(p => p.Id == expense.Id);
            if (entity != null)
            {
                entity = expense;
            }
            
            return entity.Id;
        }
    }
}