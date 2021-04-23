using System.Collections.Generic;
using BudgetApp.Domain.Models;

namespace BudgetApp.App.Abstract
{
    public interface IMenuActionService
    {
        List<MenuAction> menuActions { get; set; }
        void AddNewAction(int id, string name, string menuName);
        List<MenuAction> GetMenuActionsByMenuName(string menuName);
    }
}