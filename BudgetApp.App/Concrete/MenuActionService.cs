using System.Collections.Generic;
using System.Linq;
using BudgetApp.Models;

namespace BudgetApp.App.Concrete
{
    public class MenuActionService
    {
        public List<MenuAction> menuActions;
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