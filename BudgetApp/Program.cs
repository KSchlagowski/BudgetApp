using BudgetApp.Managers;
using BudgetApp.Domain.Models;

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
