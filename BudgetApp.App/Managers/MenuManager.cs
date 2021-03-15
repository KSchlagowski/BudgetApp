using System;
using BudgetApp.App.Concrete;
using BudgetApp.App.Managers;
using BudgetApp.Domain.Models;

namespace BudgetApp.Managers
{
    public class MenuManager
    {
        OperationService operationService;
        private Funds funds { get; set; }
        private MenuActionService actionService;
        public MenuManager()
        {
            funds = new Funds();
            operationService = new OperationService();
            actionService = new MenuActionService();
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
                default:
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
        private void HomeBudgetMenu(MenuActionService actionService)
        {
            HomeBudgetManager homeBudgetManager = new HomeBudgetManager();

            bool isHomeBudgetMenuActive = true;
            while (isHomeBudgetMenuActive)
            {
                int operation = homeBudgetManager.HomeBudgetMenuView(actionService);

                switch (operation)
                {
                    case 1:
                        var createdId = homeBudgetManager.AddNewHomeBudgetView();
                        break;
                    case 2:
                        System.Console.WriteLine("Wpisz numer miesiąca, na który stworzyłeś budżet, który chcesz zobaczyć.");
                        int idToView = operationService.ReadNumberOperation();
                        homeBudgetManager.HomeBudgetByIdView(idToView);
                        System.Console.WriteLine();
                        break;
                    case 3:
                        homeBudgetManager.AllHomeBudgetsView();
                        break;
                    case 4:
                        System.Console.WriteLine("Wpisz numer miesiąca, na który stworzyłeś budżet, który chcesz usunąć.");
                        System.Console.WriteLine();
                        int idToRemove = operationService.ReadNumberOperation();
                        var removedId = homeBudgetManager.RemoveHomeBudgetByIdView(idToRemove);
                        break;
                    case 5:
                        homeBudgetManager.HomeBudgetInstruction();
                        break;
                    default: 
                        isHomeBudgetMenuActive = false;
                        break;
                }
            }
        }

        private void FundsMenu(MenuActionService actionService)
        {
            FundsManager fundsManager = new FundsManager();

            bool isFundsMenuActive = true;
            while (isFundsMenuActive)
            {
                int operation = fundsManager.FundsMenuView(actionService);
                
                switch (operation)
                {
                    case 1:
                        System.Console.WriteLine("O ile chcesz zmienić stan tego funduszu?");
                        System.Console.WriteLine();
                        decimal irregularIncome = operationService.ReadValueOperation();
                        funds.IrregularExpensesFund = fundsManager.EditIrregularExpensesFundView(funds.IrregularExpensesFund, irregularIncome);
                        break;
                    case 2:
                        System.Console.WriteLine("O ile chcesz zmienić stan tego funduszu?");
                        System.Console.WriteLine();
                        decimal emergencyIncome = operationService.ReadValueOperation();
                        funds.EmergencyFund = fundsManager.EditEmergencyFundView(funds.EmergencyFund, emergencyIncome);
                        break;
                    case 3:
                        System.Console.WriteLine("O ile chcesz zmienić stan tego funduszu?");
                        System.Console.WriteLine();
                        decimal securityIncome = operationService.ReadValueOperation();
                        funds.SecurityFund = fundsManager.EditSecurityFundView(funds.SecurityFund, securityIncome);
                        break;
                    case 4:
                        System.Console.WriteLine("O ile chcesz zmienić stan tego funduszu?");
                        System.Console.WriteLine();
                        decimal specialPurposeIncome = operationService.ReadValueOperation();
                        funds.SpecialPurposeFund = fundsManager.EditSpecialPurposeFundView(funds.SpecialPurposeFund, specialPurposeIncome);
                        break;
                    case 5:
                        fundsManager.AllFundsView(funds);
                        break;
                    case 6:
                        fundsManager.FundsInstruction();
                        break;
                    default:
                        isFundsMenuActive = false;
                        break;
                }
            }
        }

        private void ExpenseMenu(MenuActionService actionService)
        {
            ExpenseManager expenseManager = new ExpenseManager();

            bool isExpenseMenuActive = true;
            while (isExpenseMenuActive)
            {
                int operation = expenseManager.ExpenseMenuView(actionService);
                
                switch (operation)
                {
                    case 1:
                        var createdId = expenseManager.AddNewExpenseView();
                        break;
                    case 2:
                        System.Console.WriteLine();
                        System.Console.WriteLine("Wpisz id wydatku, który chcesz zobaczyć.");
                        System.Console.WriteLine();
                        int idToView;
                        string readedIdToView = Console.ReadLine();
                        Int32.TryParse(readedIdToView, out idToView);
                        var viewedId = expenseManager.GetExpenseByIdView(idToView);
                        break;
                    case 3:
                        expenseManager.AllExpensesView();
                        break;
                    case 4:
                        System.Console.WriteLine();
                        System.Console.WriteLine("Wpisz id wydatku, który chcesz usunąć.");
                        System.Console.WriteLine();
                        int idToRemove;
                        string readedIdToRemove = Console.ReadLine();
                        Int32.TryParse(readedIdToRemove, out idToRemove);
                        var removedId = expenseManager.RemoveExpenseByIdView(idToRemove);
                        break;
                    default:
                        isExpenseMenuActive = false;
                        break;
                }
            }
        }
    }
}