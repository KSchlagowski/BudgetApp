using System;
using BudgetApp.App.Abstract;
using BudgetApp.App.Concrete;
using BudgetApp.App.Managers;
using BudgetApp.App.Repositories;
using BudgetApp.Domain.Models;

namespace BudgetApp.Managers
{
    public class MenuManager
    {
        private IOperationService operationService;
        private MenuActionService actionService;
        public MenuManager()
        {
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
            HomeBudgetRepository homeBudgetRepository = new HomeBudgetRepository();
            HomeBudgetService homeBudgetService = new HomeBudgetService(homeBudgetRepository);
            HomeBudgetManager homeBudgetManager = new HomeBudgetManager(homeBudgetService);

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

        private void ExpenseMenu(MenuActionService actionService)
        {
            ExpenseRepository expenseRepository = new ExpenseRepository();
            ExpenseService expenseService = new ExpenseService(expenseRepository);
            ExpenseManager expenseManager = new ExpenseManager(actionService, expenseService);

            bool isExpenseMenuActive = true;
            while (isExpenseMenuActive)
            {
                int operation = expenseManager.ShowExpenseMenu();
                
                switch (operation)
                {
                    case 1:
                        var createdId = expenseManager.ShowAddNewExpense();
                        break;
                    case 2:
                        System.Console.WriteLine();
                        System.Console.WriteLine("Wpisz id wydatku, który chcesz zobaczyć.");
                        System.Console.WriteLine();
                        int idToView;
                        string readedIdToView = Console.ReadLine();
                        Int32.TryParse(readedIdToView, out idToView);
                        expenseManager.ShowGetExpenseById(idToView);
                        break;
                    case 3:
                        expenseManager.ShowAllExpenses();
                        break;
                    case 4:
                        System.Console.WriteLine();
                        System.Console.WriteLine("Wpisz id wydatku, który chcesz usunąć.");
                        System.Console.WriteLine();
                        int idToRemove;
                        string readedIdToRemove = Console.ReadLine();
                        Int32.TryParse(readedIdToRemove, out idToRemove);
                        var removedId = expenseManager.ShowRemoveExpenseById(idToRemove);
                        break;
                    default:
                        isExpenseMenuActive = false;
                        break;
                }
            }
        }

        private void FundsMenu(MenuActionService actionService)
        {
            IFundsRepository<T> fundsRepository = new FundsRepository();
            IFundsService<T> fundsService = new FundsService(fundsRepository);
            FundsManager fundsManager = new FundsManager(actionService, fundsService);

            bool isFundsMenuActive = true;
            while (isFundsMenuActive)
            {
                int operation = fundsManager.FundsMenuView();
                
                switch (operation)
                {
                    case 1:
                        System.Console.WriteLine("O ile chcesz zmienić stan tego funduszu?");
                        System.Console.WriteLine();
                        decimal irregularIncome = operationService.ReadValueOperation();
                        fundsService.EditIrregularExpensesFund(irregularIncome);
                        break;
                    case 2:
                        System.Console.WriteLine("O ile chcesz zmienić stan tego funduszu?");
                        System.Console.WriteLine();
                        decimal emergencyIncome = operationService.ReadValueOperation();
                        fundsService.EditEmergencyFund(emergencyIncome);
                        break;
                    case 3:
                        System.Console.WriteLine("O ile chcesz zmienić stan tego funduszu?");
                        System.Console.WriteLine();
                        decimal securityIncome = operationService.ReadValueOperation();
                        fundsService.EditSecurityFund(securityIncome);
                        break;
                    case 4:
                        System.Console.WriteLine("O ile chcesz zmienić stan tego funduszu?");
                        System.Console.WriteLine();
                        decimal specialPurposeIncome = operationService.ReadValueOperation();
                        fundsManager.EditSpecialPurposeFundView(specialPurposeIncome);
                        break;
                    case 5:
                        fundsManager.AllFundsView();
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
    }
}