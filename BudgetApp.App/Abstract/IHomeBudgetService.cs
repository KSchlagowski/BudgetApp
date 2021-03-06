using System.Collections.Generic;
using BudgetApp.Domain.Models;

namespace BudgetApp.App.Abstract
{
    public interface IHomeBudgetService
    {
        List<HomeBudget> GetAllHomeBudgets();
        int AddNewHomeBudget(HomeBudget homeBudget);
        bool RemoveHomeBudgetById (int id);
    }
}