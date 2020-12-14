using System;
using BudgetApp.Models;
using BudgetApp.Services;

namespace BudgetApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MenuService menuService = new MenuService();

            menuService.CreateMenuView(MenuOption.MainMenu);

            Funds funds = new Funds();
            var a = funds.SpecialPurposeFundBalance;
            var b = SpecialPurposeFund
        }
    }
}
