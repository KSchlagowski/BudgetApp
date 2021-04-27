using System.Collections.Generic;
using BudgetApp.Domain.Models;

namespace BudgetApp.App.Abstract
{
    public interface IJsonService
    {
        List<Expense> LoadExpenses();
        Funds LoadFunds();
        List<HomeBudget> LoadHomeBudgets();
        bool SaveExpenses(List<Expense> expenses);
        bool SaveFunds(Funds funds);
        bool SaveHomeBudgets(List<HomeBudget> homeBudgets);
    }
}