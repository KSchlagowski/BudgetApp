using BudgetApp.Managers;
using BudgetApp.Models;

namespace BudgetApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MenuManager menuManager = new MenuManager();

            menuManager.CreateMenuView(MenuOption.MainMenu);
        }
    }
}
