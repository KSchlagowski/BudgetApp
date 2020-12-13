using System;

namespace BudgetApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MenuActionService actionService = new MenuActionService();

            IrregularExpensesFund irregularExpensesFund = new IrregularExpensesFund();
            EmergencyFund emergencyFund = new EmergencyFund();
            SecurityFund securityFund = new SecurityFund();
            SpecialPurposeFund specialPurposeFund = new SpecialPurposeFund();
            
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
                        FundsMenu(actionService, irregularExpensesFund, emergencyFund, securityFund, specialPurposeFund);
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
                        var idViewed = homeBudgetService.AddNewHomeBudget();
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
                        var idRemoved = homeBudgetService.RemoveHomeBudgetById(idToRemove);
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

        public static void FundsMenu(MenuActionService actionService, IrregularExpensesFund irregularExpensesFund, EmergencyFund emergencyFund, SecurityFund securityFund, SpecialPurposeFund specialPurposeFund)
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
                        irregularExpensesFund = fundsService.EditIrregularExpensesFund(irregularExpensesFund, irregularIncome);
                        break;
                    case 2:
                        System.Console.WriteLine("O ile chcesz zmienić stan tego funduszu?");
                        decimal emergencyIncome;
                        string readedEmergencyIncome = Console.ReadLine();
                        Decimal.TryParse(readedEmergencyIncome, out emergencyIncome);
                        emergencyFund = fundsService.EditEmergencyFund(emergencyFund, emergencyIncome);
                        break;
                    case 3:
                        System.Console.WriteLine("O ile chcesz zmienić stan tego funduszu?");
                        decimal securityIncome;
                        string readedSecurityIncome = Console.ReadLine();
                        Decimal.TryParse(readedSecurityIncome, out securityIncome);
                        securityFund = fundsService.EditSecurityFund(securityFund, securityIncome);
                        break;
                    case 4:
                        System.Console.WriteLine("O ile chcesz zmienić stan tego funduszu?");
                        decimal specialPurposeIncome;
                        string readedSpecialPurposeIncome = Console.ReadLine();
                        Decimal.TryParse(readedSpecialPurposeIncome, out specialPurposeIncome);
                        specialPurposeFund = fundsService.EditSpecialPurposeFund(specialPurposeFund, specialPurposeIncome);
                        break;
                    case 5:
                        fundsService.AllFundsView(irregularExpensesFund, emergencyFund, securityFund, specialPurposeFund);
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
    }
}
