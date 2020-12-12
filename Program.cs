using System;

namespace BudgetApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            HomeBudget homeBudget = new HomeBudget();
            MenuActionService actionService = new MenuActionService();
            actionService = Initialize(actionService);

            bool isProgramActive = true;
            while (isProgramActive)
            {
                System.Console.WriteLine("Planer budżetu domowego!");
                System.Console.WriteLine("Wpisz liczbę odpowiadającą temu, co chcesz zrobić.");
                System.Console.WriteLine();

                var mainMenu = actionService.GetMenuActionsByMenuName("Main");
                for (int i = 0; i < mainMenu.Count; i++)
                {
                    Console.WriteLine($"{mainMenu[i].Id}. {mainMenu[i].Name}");
                }

                string choose = Console.ReadLine();
                int chooseResult = 0;
                Int32.TryParse(choose, out chooseResult);

                switch (chooseResult)
                {
                    case 1:
                        HomeBudgetMenu();
                        break;
                    case 2:
                        System.Console.WriteLine(2);
                        break;
                    case 3:
                        System.Console.WriteLine(3);
                        break;
                    default: 
                        isProgramActive = false;
                        break;
                }
            }
        }

        private static MenuActionService Initialize(MenuActionService actionService)
        {
            actionService.AddNewAction(1, "Budżet domowy.", "Main");
            actionService.AddNewAction(2, "Spis wydatków.", "Main");
            actionService.AddNewAction(3, "Stan kont.", "Main");
            actionService.AddNewAction(4, "Wyjście", "Main");

            actionService.AddNewAction(0, "Instrukcja.", "BudgetMainMenu");
            actionService.AddNewAction(1, "Tworzenie.", "BudgetMainMenu");
            actionService.AddNewAction(2, "Wyświetlanie.", "BudgetMainMenu");
            actionService.AddNewAction(3, "Powrót.", "BudgetMainMenu");
            return actionService;
        }

        public static void HomeBudgetMenu()
        {
            HomeBudget homeBudget = new HomeBudget();

            bool isHomeBudgetMenuActive = true;
            while (isHomeBudgetMenuActive)
            {
                System.Console.WriteLine();
                System.Console.WriteLine("Budżet domowy");
                System.Console.WriteLine("0. Instrukcja.");
                System.Console.WriteLine("1. Tworzenie.");
                System.Console.WriteLine("2. Wyświetlanie.");
                System.Console.WriteLine("q. Powrót.");
                System.Console.WriteLine();

                string choose = Console.ReadLine();
                int chooseResult = 0;
                Int32.TryParse(choose, out chooseResult);

                switch (chooseResult)
                {
                    case 0:
                        homeBudget.HomeBudgetInstruction();
                        break;
                    case 1:
                        System.Console.WriteLine(1);
                        break;
                    case 2:
                        System.Console.WriteLine(2);
                        break;
                    default: 
                        isHomeBudgetMenuActive = false;
                        break;
                }
            }
        }

        
    }
}
