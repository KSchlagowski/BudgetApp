using System.Collections.Generic;
using System.Linq;
using BudgetApp.App.Abstract;
using BudgetApp.Domain.Models;

namespace BudgetApp.App.Concrete
{
    public class MenuActionService : IMenuActionService
    {
        public List<MenuAction> menuActions { get; set; }
        public MenuActionService()
        {
            menuActions = new List<MenuAction>();
        }

        public void AddNewAction(int id, string name, string menuName)
        {
            MenuAction menuAction = new MenuAction(id, name) {MenuName = menuName};
            menuActions.Add(menuAction);
        }

        public List<MenuAction> GetMenuActionsByMenuName(string menuName)
        {
            return menuActions.Where(a => a.MenuName == menuName).ToList();
        }
    }
}