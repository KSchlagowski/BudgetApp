using System;

namespace BudgetApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            HomeBudgetService homeBudgetService = new HomeBudgetService();
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
                        HomeBudgetMenu(actionService);
                        break;
                    case 2:
                        System.Console.WriteLine("Not implemented yet.");
                        break;
                    case 3:
                        System.Console.WriteLine("Not implemented yet.");
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

            actionService.AddNewAction(0, "Instrukcja.", "HomeBudgetMenu");
            actionService.AddNewAction(1, "Tworzenie.", "HomeBudgetMenu");
            actionService.AddNewAction(2, "Wyświetlenie konkretnego budżetu.", "HomeBudgetMenu");
            actionService.AddNewAction(3, "Wyświetlenie wszystkich budżetów.", "HomeBudgetMenu");
            actionService.AddNewAction(4, "Powrót.", "HomeBudgetMenu");
            return actionService;
        }

        public static void HomeBudgetMenu(MenuActionService actionService)
        {
            HomeBudgetService homeBudgetService = new HomeBudgetService();

            bool isHomeBudgetMenuActive = true;
            while (isHomeBudgetMenuActive)
            {
                int operation = homeBudgetService.HomeBudgetMenuView(actionService);

                switch (operation)
                {
                    case 0:
                        homeBudgetService.HomeBudgetInstruction();
                        break;
                    case 1:
                        var id = homeBudgetService.AddNewHomeBudget();
                        break;
                    case 2:
                        System.Console.WriteLine("Not implemented yet.");
                        break;
                    case 3:
                        System.Console.WriteLine("Not implemented yet.");
                        break;
                    default: 
                        isHomeBudgetMenuActive = false;
                        break;
                }
            }
        }

        
    }
}
