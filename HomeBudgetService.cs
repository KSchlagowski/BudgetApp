using System;
using System.Collections.Generic;

namespace BudgetApp
{
    public class HomeBudgetService
    {
        public List<HomeBudget> homeBudgets { get; set; }
        public HomeBudgetService()
        {
            homeBudgets = new List<HomeBudget>();
        }

        public int HomeBudgetMenuView(MenuActionService actionService)
        {
            var homeBudgetMenu = actionService.GetMenuActionsByMenuName("HomeBudgetMenu");
            Console.WriteLine("Budżet domowy.");
            for (int i = 0; i < homeBudgetMenu.Count; i++)
            {
                Console.WriteLine($"{homeBudgetMenu[i].Id}. {homeBudgetMenu[i].Name}");
            }

            string readedOperation = Console.ReadLine();
            int operation;
            Int32.TryParse(readedOperation, out operation);

            return operation;
        }

        public int AddNewHomeBudget()
        {
            System.Console.WriteLine("Wpisz numer miesiąca, na który tworzysz budżet.");
            string month = Console.ReadLine();
            int monthNumber;
            Int32.TryParse(month, out monthNumber);
            DateTime date = new DateTime(2020, monthNumber, 1);
            month = date.ToString("MMMM");

            System.Console.WriteLine("Wpisz kwotę netto, którą zarobiłeś w poprzednim miesiącu,");
            System.Console.WriteLine("lub średnią twoich zarobków, jeśli jesteś freelancerem.");
            decimal earnings;
            string readedEarnings = Console.ReadLine();
            Decimal.TryParse(readedEarnings, out earnings);
            System.Console.WriteLine("Wpisz kwotę swoich wydatków stałych ponoszonych co miesiąc.");
            decimal fixedExpenses;
            string readedFixedExpenses = Console.ReadLine();
            Decimal.TryParse(readedFixedExpenses, out fixedExpenses);
            
            decimal balance = earnings - fixedExpenses;
            System.Console.WriteLine($"Twoje saldo wynosi: {balance}");
            System.Console.WriteLine("Wpisz kwotę swoich planowanych wydatków jednorazowych.");
            decimal variableExpenses;
            string readedVariableExpenses = Console.ReadLine();
            Decimal.TryParse(readedVariableExpenses, out variableExpenses);
            System.Console.WriteLine("Wpisz swoją kwotę wydatków nieregularnych.");
            decimal unregularExpenses;
            string readedUnregularExpenses = Console.ReadLine();
            Decimal.TryParse(readedUnregularExpenses, out unregularExpenses);
            
            decimal finalBalance = balance - variableExpenses - unregularExpenses; 
            System.Console.WriteLine($"Twoje saldo finalne wynosi: {finalBalance}");
            
            if (finalBalance >= 0)
            {
                System.Console.WriteLine("Brawo! Saldo jest dodatnie! Oznacza to, że twój budżet został dobrze zaplanowany!");
            }
            else
            {
                System.Console.WriteLine("Niestety saldo jest ujemne, czyli twój budżet został źle zaplanowany. Przemyśl na czym możesz zaoszczędzić.");
            }
            
            HomeBudget homeBudget = new HomeBudget(month, earnings, fixedExpenses, variableExpenses, unregularExpenses, balance, finalBalance);
            homeBudgets.Add(homeBudget);

            return monthNumber;
        }

        public void HomeBudgetInstruction()
        {
            System.Console.WriteLine("Tworzenie domowego budżetu wygląda następująco:");
            System.Threading.Thread.Sleep(2000);
            System.Console.WriteLine("Wpisz numer miesiąca, na który tworzysz budżet.");
            System.Console.WriteLine();
            System.Threading.Thread.Sleep(2000);
            System.Console.WriteLine("12");
            System.Threading.Thread.Sleep(2000);
            System.Console.WriteLine();
            System.Console.WriteLine("Wpisz kwotę netto, którą zarobiłeś w poprzednim miesiącu,");
            System.Console.WriteLine("lub średnią twoich zarobków, jeśli jesteś freelancerem.");
            System.Console.WriteLine();
            System.Threading.Thread.Sleep(2000);
            System.Console.WriteLine("6000");
            System.Threading.Thread.Sleep(2000);
            System.Console.WriteLine();
            System.Console.WriteLine("Wpisz kwotę swoich wydatków stałych ponoszonych co miesiąc, czyli:");
            System.Threading.Thread.Sleep(1000);
            System.Console.WriteLine("*czynsz i opłaty mieszkaniowe");
            System.Threading.Thread.Sleep(1000);
            System.Console.WriteLine("*jedzenie");
            System.Threading.Thread.Sleep(1000);
            System.Console.WriteLine("*transport (auto, bilety)");
            System.Threading.Thread.Sleep(1000);
            System.Console.WriteLine("*raty kredytów");
            System.Threading.Thread.Sleep(1000);
            System.Console.WriteLine("*rozrywka");
            System.Threading.Thread.Sleep(1000);
            System.Console.WriteLine("*ubezpieczenia");
            System.Threading.Thread.Sleep(1000);
            System.Console.WriteLine("*regularne oszczędzanie");
            System.Console.WriteLine();
            System.Threading.Thread.Sleep(2000);
            System.Console.WriteLine("4250");
            System.Threading.Thread.Sleep(2000);
            System.Console.WriteLine();
            System.Console.WriteLine("Saldo: 1780");
            System.Threading.Thread.Sleep(2000);
            System.Console.WriteLine();
            System.Console.WriteLine("Dodając przewidywane wydatki jednorazowe (np. podręczniki szkolne) oraz wydatki nieregularne,");
            System.Console.WriteLine();
            System.Threading.Thread.Sleep(2000);
            System.Console.WriteLine("1335");
            System.Threading.Thread.Sleep(2000);
            System.Console.WriteLine();
            System.Console.WriteLine("saldo finalne: 445");
            System.Threading.Thread.Sleep(2000);
            System.Console.WriteLine("Brawo! Twoje saldo jest dodatnie! Z resztą pieniędzy możesz zrobić co zechcesz!");
            System.Threading.Thread.Sleep(2000);
            System.Console.WriteLine();
        }
    }
}