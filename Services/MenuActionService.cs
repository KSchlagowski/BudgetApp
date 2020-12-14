using System.Collections.Generic;

namespace BudgetApp
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
            List<MenuAction> result = new List<MenuAction>();
            foreach (var menuAction in menuActions)
            {
                if (menuAction.MenuName == menuName)
                {
                    result.Add(menuAction);
                }
            }

            return result;
        }
    }
}