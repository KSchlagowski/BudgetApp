using System.Collections.Generic;
using BudgetApp.Domain.Models;

namespace BudgetApp.App.Abstract
{
    public interface IHomeBudgetRepository
    {
        List<HomeBudget> homeBudgets { get; set; }
        int AddNewHomeBudget(HomeBudget homeBudget);
        bool RemoveHomeBudgetById (int id);
    }
}