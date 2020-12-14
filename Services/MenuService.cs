using System;
using BudgetApp.Models;

namespace BudgetApp.Services
{
    
    public class MenuService
    {
        OperationService operationService = new OperationService();
        private Funds funds { get; set; }
        private MenuActionService actionService = new MenuActionService();
        public MenuService()
        {
            funds = new Funds();
            Initialize();
        }
        public void CreateMenuView(MenuOption menuOption)
        {
            switch (menuOption)
            {
                case MenuOption.MainMenu:
                    MainMenu();
                    break;
                case MenuOption.HomeBudgetMenu:
                    HomeBudgetMenu(actionService);
                    break;
                case MenuOption.FundsMenu:
                    FundsMenu(actionService);
                    break;
                case MenuOption.ExpenseMenu:
                    ExpenseMenu(actionService);
                    break;
            }
        }
        private void Initialize()
        {
            actionService.AddNewAction(1, "Budżet domowy.", "Main");
            actionService.AddNewAction(2, "Spis wydatków.", "Main");
            actionService.AddNewAction(3, "Stan funduszy.", "Main");
            actionService.AddNewAction(4, "Wyjście", "Main");

            actionService.AddNewAction(1, "Tworzenie budżetu domowego.", "HomeBudgetMenu");
            actionService.AddNewAction(2, "Wyświetlenie konkretnego budżetu.", "HomeBudgetMenu");
            actionService.AddNewAction(3, "Wyświetlenie wszystkich budżetów.", "HomeBudgetMenu");    
            actionService.AddNewAction(4, "Usunięcie konkretnego budżetu.", "HomeBudgetMenu");
            actionService.AddNewAction(5, "Instrukcja tworzenia budżetu.", "HomeBudgetMenu");
            actionService.AddNewAction(6, "Powrót.", "HomeBudgetMenu");

            actionService.AddNewAction(1, "Edytuj stan funduszu wydatków nieregularnych (FWN).", "FundsMenu");//fixed variable irregular
            actionService.AddNewAction(2, "Edytuj stan funduszu awaryjny (FA).", "FundsMenu");
            actionService.AddNewAction(3, "Edytuj stan funduszu bezpieczeństwa (FB).", "FundsMenu");
            actionService.AddNewAction(4, "Edytuj stan funduszu celowy.", "FundsMenu");
            actionService.AddNewAction(5, "Wyświetl stan funduszy.", "FundsMenu");
            actionService.AddNewAction(6, "Instrukcja.", "FundsMenu");
            actionService.AddNewAction(7, "Wyjście", "FundsMenu");

            actionService.AddNewAction(1, "Tworzenie nowego wydatku.", "ExpenseMenu");
            actionService.AddNewAction(2, "Wyświetlenie konkretnego wydatku.", "ExpenseMenu");
            actionService.AddNewAction(3, "Wyświetlenie wszystkich wydatków.", "ExpenseMenu");    
            actionService.AddNewAction(4, "Usunięcie konkretnego wydatku.", "ExpenseMenu");
            actionService.AddNewAction(5, "Powrót.", "ExpenseMenu");
        }

        private void MainMenu()
        {
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

                var operation = operationService.ReadNumberOperation();

                switch (operation)
                {
                    case 1:
                        CreateMenuView(MenuOption.HomeBudgetMenu);
                        break;
                    case 2:
                        CreateMenuView(MenuOption.ExpenseMenu);
                        break;
                    case 3:
                        CreateMenuView(MenuOption.FundsMenu);
                        break;
                    default: 
                        isProgramActive = false;
                        break;
                }
            }
        }
        private static void HomeBudgetMenu(MenuActionService actionService)
        {
            HomeBudgetService homeBudgetService = new HomeBudgetService();

            bool isHomeBudgetMenuActive = true;
            while (isHomeBudgetMenuActive)
            {
                int operation = homeBudgetService.HomeBudgetMenuView(actionService);

                switch (operation)
                {
                    case 1:
                        var createdId = homeBudgetService.AddNewHomeBudgetView();
                        break;
                    case 2:
                        System.Console.WriteLine("Wpisz numer miesiąca, na który stworzyłeś budżet, który chcesz zobaczyć.");
                        System.Console.WriteLine();
                        int idToView;
                        string readedIdToView = Console.ReadLine();
                        Int32.TryParse(readedIdToView, out idToView);
                        homeBudgetService.HomeBudgetByIdView(idToView);
                        System.Console.WriteLine();
                        break;
                    case 3:
                        homeBudgetService.AllHomeBudgetsView();
                        break;
                    case 4:
                        System.Console.WriteLine("Wpisz numer miesiąca, na który stworzyłeś budżet, który chcesz usunąć.");
                        System.Console.WriteLine();
                        int idToRemove;
                        string readedIdToRemove = Console.ReadLine();
                        Int32.TryParse(readedIdToRemove, out idToRemove);
                        var removedId = homeBudgetService.RemoveHomeBudgetById(idToRemove);
                        break;
                    case 5:
                        homeBudgetService.HomeBudgetInstruction();
                        break;
                    default: 
                        isHomeBudgetMenuActive = false;
                        break;
                }
            }
        }

        private void FundsMenu(MenuActionService actionService)
        {
            FundsService fundsService = new FundsService();

            bool isFundsMenuActive = true;
            while (isFundsMenuActive)
            {
                int operation = fundsService.FundsMenuView(actionService);
                
                switch (operation)
                {
                    case 1:
                        System.Console.WriteLine("O ile chcesz zmienić stan tego funduszu?");
                        decimal irregularIncome;
                        string readedIrregularIncome = Console.ReadLine();
                        Decimal.TryParse(readedIrregularIncome, out irregularIncome);
                        funds.IrregularExpensesFund = fundsService.EditIrregularExpensesFund(funds.IrregularExpensesFund, irregularIncome);
                        break;
                    case 2:
                        System.Console.WriteLine("O ile chcesz zmienić stan tego funduszu?");
                        decimal emergencyIncome;
                        string readedEmergencyIncome = Console.ReadLine();
                        Decimal.TryParse(readedEmergencyIncome, out emergencyIncome);
                        funds.EmergencyFund = fundsService.EditEmergencyFund(funds.EmergencyFund, emergencyIncome);
                        break;
                    case 3:
                        System.Console.WriteLine("O ile chcesz zmienić stan tego funduszu?");
                        decimal securityIncome;
                        string readedSecurityIncome = Console.ReadLine();
                        Decimal.TryParse(readedSecurityIncome, out securityIncome);
                        funds.SecurityFund = fundsService.EditSecurityFund(funds.SecurityFund, securityIncome);
                        break;
                    case 4:
                        System.Console.WriteLine("O ile chcesz zmienić stan tego funduszu?");
                        decimal specialPurposeIncome;
                        string readedSpecialPurposeIncome = Console.ReadLine();
                        Decimal.TryParse(readedSpecialPurposeIncome, out specialPurposeIncome);
                        funds.SpecialPurposeFund = fundsService.EditSpecialPurposeFund(funds.SpecialPurposeFund, specialPurposeIncome);
                        break;
                    case 5:
                        fundsService.AllFundsView(funds.IrregularExpensesFund, funds.EmergencyFund, funds.SecurityFund, funds.SpecialPurposeFund);
                        break;
                    case 6:
                        fundsService.FundsInstruction();
                        break;
                    default:
                        isFundsMenuActive = false;
                        break;
                }
            }
        }

        private void ExpenseMenu(MenuActionService actionService)
        {
            ExpenseService expenseService = new ExpenseService();

            bool isExpenseMenuActive = true;
            while (isExpenseMenuActive)
            {
                int operation = expenseService.ExpenseMenuView(actionService);
                
                switch (operation)
                {
                    case 1:
                        var createdId = expenseService.AddNewExpenseView();
                        break;
                    case 2:
                        System.Console.WriteLine();
                        System.Console.WriteLine("Wpisz id wydatku, który chcesz zobaczyć.");
                        System.Console.WriteLine();
                        int idToView;
                        string readedIdToView = Console.ReadLine();
                        Int32.TryParse(readedIdToView, out idToView);
                        var viewedId = expenseService.ExpenseByIdView(idToView);
                        break;
                    case 3:
                        expenseService.AllExpensesView();
                        break;
                    case 4:
                        System.Console.WriteLine();
                        System.Console.WriteLine("Wpisz id wydatku, który chcesz usunąć.");
                        System.Console.WriteLine();
                        int idToRemove;
                        string readedIdToRemove = Console.ReadLine();
                        Int32.TryParse(readedIdToRemove, out idToRemove);
                        var removedId = expenseService.RemoveExpenseById(idToRemove);
                        break;
                    default:
                        isExpenseMenuActive = false;
                        break;
                }
            }
        }
    }
}