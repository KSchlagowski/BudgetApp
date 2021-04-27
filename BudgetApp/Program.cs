using BudgetApp.Managers;
using BudgetApp.Domain.Models;
using BudgetApp.App.Managers;
using BudgetApp.App.Repositories;

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
