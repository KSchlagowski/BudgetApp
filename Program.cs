using System;
using BudgetApp.Fund;

namespace BudgetApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MenuService menuService = new MenuService();

            menuService.CreateMenuView(MenuOption.MainMenu);
        }
    }
}
