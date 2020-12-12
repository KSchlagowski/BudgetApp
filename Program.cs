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
                System.Console.WriteLine();

                string choose = Console.ReadLine();
                int chooseResult = 0;
                Int32.TryParse(choose, out chooseResult);
                System.Console.WriteLine();

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

            actionService.AddNewAction(1, "Tworzenie budżetu domowego.", "HomeBudgetMenu");
            actionService.AddNewAction(2, "Wyświetlenie konkretnego budżetu.", "HomeBudgetMenu");
            actionService.AddNewAction(3, "Wyświetlenie wszystkich budżetów.", "HomeBudgetMenu");
            actionService.AddNewAction(4, "Instrukcja tworzenia budżetu.", "HomeBudgetMenu");
            actionService.AddNewAction(5, "Usunięcie konkretnego budżetu.", "HomeBudgetMenu");
            actionService.AddNewAction(6, "Powrót.", "HomeBudgetMenu");
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
                    case 1:
                        var id = homeBudgetService.AddNewHomeBudget();
                        break;
                    case 2:
                        System.Console.WriteLine("Wpisz numer miesiąca, na który stworzyłeś budżet, który chcesz zobaczyć.");
                        System.Console.WriteLine();
                        int idToView;
                        string readedId = Console.ReadLine();
                        Int32.TryParse(readedId, out idToView);
                        homeBudgetService.HomeBudgetByIdView(idToView);
                        System.Console.WriteLine();
                        break;
                    case 3:
                        System.Console.WriteLine("Not implemented yet.");
                        break;
                    case 4:
                        homeBudgetService.HomeBudgetInstruction();
                        break;
                    case 5:
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
