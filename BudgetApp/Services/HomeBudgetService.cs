using System;
using System.Collections.Generic;

using BudgetApp.Models;

namespace BudgetApp.Services
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
            System.Console.WriteLine();

            string readedOperation = Console.ReadLine();
            int operation;
            Int32.TryParse(readedOperation, out operation);
            System.Console.WriteLine();

            return operation;
        }

        public int AddNewHomeBudgetView()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Wpisz numer miesiąca, na który tworzysz budżet.");
            string month = Console.ReadLine();
            int monthNumber;
            Int32.TryParse(month, out monthNumber);
            DateTime date = new DateTime(2020, monthNumber, 1);
            month = date.ToString("MMMM");

            System.Console.WriteLine();
            System.Console.WriteLine("Wpisz kwotę netto, którą zarobiłeś w poprzednim miesiącu,");
            System.Console.WriteLine("lub średnią twoich zarobków, jeśli jesteś freelancerem.");
            System.Console.WriteLine();
            decimal earnings;
            string readedEarnings = Console.ReadLine();
            Decimal.TryParse(readedEarnings, out earnings);
            System.Console.WriteLine();
            System.Console.WriteLine("Wpisz kwotę swoich wydatków stałych ponoszonych co miesiąc.");
            System.Console.WriteLine();
            decimal fixedExpenses;
            string readedFixedExpenses = Console.ReadLine();
            Decimal.TryParse(readedFixedExpenses, out fixedExpenses);
            
            decimal balance = earnings - fixedExpenses;
            System.Console.WriteLine();
            System.Console.WriteLine($"Twoje saldo wynosi: {balance}");
            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.WriteLine("Wpisz kwotę swoich planowanych wydatków jednorazowych.");
            System.Console.WriteLine();
            decimal variableExpenses;
            string readedVariableExpenses = Console.ReadLine();
            Decimal.TryParse(readedVariableExpenses, out variableExpenses);
            System.Console.WriteLine();
            System.Console.WriteLine("Wpisz swoją średnią kwotę wydatków nieregularnych.");
            System.Console.WriteLine("Zaleca się, aby jednorazowe roczne wydatki typu wakacje, ubezpieczenie auta, wizyty u lekarza zsumować i podzielić przez 10, aby wyliczyć bezpieczną kwotę do odkładania na (FWN).");
            System.Console.WriteLine();
            decimal irregularExpenses;
            string readedIrregularExpenses = Console.ReadLine();
            Decimal.TryParse(readedIrregularExpenses, out irregularExpenses);
            
            decimal finalBalance = balance - variableExpenses - irregularExpenses; 
            System.Console.WriteLine();
            System.Console.WriteLine($"Twoje saldo finalne wynosi: {finalBalance}");
            System.Console.WriteLine();
            System.Console.WriteLine();
            
            if (finalBalance >= 0)
            {
                System.Console.WriteLine("Brawo! Saldo jest dodatnie! Oznacza to, że twój budżet został dobrze zaplanowany!");
            }
            else
            {
                System.Console.WriteLine("Niestety saldo jest ujemne, czyli twój budżet został źle zaplanowany. Przemyśl na czym możesz zaoszczędzić.");
            }
            System.Console.WriteLine();

            return AddNewHomeBudget(monthNumber, month, earnings, fixedExpenses, variableExpenses, irregularExpenses, balance, finalBalance);
        }

        public int AddNewHomeBudget(int monthNumber, string month, decimal earnings, decimal fixedExpenses, decimal variableExpenses, decimal irregularExpenses, decimal balance, decimal finalBalance)
        {
            HomeBudget homeBudget = new HomeBudget(monthNumber, month, earnings, fixedExpenses, variableExpenses, irregularExpenses, balance, finalBalance);
            homeBudgets.Add(homeBudget);

            return monthNumber;
        }
        
        public int RemoveHomeBudgetById (int id)
        {
            foreach (var homeBudget in homeBudgets)
            {
                if (homeBudget.Id == id)
                {
                    homeBudgets.Remove(homeBudget);
                    System.Console.WriteLine();
                    System.Console.WriteLine("Budżet usunięto pomyślnie.");
                    System.Console.WriteLine();
                    return id;
                }
            }
            
            System.Console.WriteLine();
            System.Console.WriteLine("Nie można znaleźć budżetu na podany miesiąc.");
            System.Console.WriteLine();
            return -1;
        }

        public void HomeBudgetByIdView (int id)
        {
            List<HomeBudget> toShow = new List<HomeBudget>();

            bool isBudgetFound = false;
            foreach (var homeBudget in homeBudgets)
            {
                if (homeBudget.Id == id)
                {
                    toShow.Add(homeBudget);
                    isBudgetFound = true;
                }
            }

            foreach (var homeBudget in toShow)
            {
                System.Console.WriteLine();
                System.Console.WriteLine("Miesiąc: " + homeBudget.Month);
                System.Console.WriteLine("Zarobki: " + homeBudget.Earnings);
                System.Console.WriteLine("Wydatki stałe: " + homeBudget.FixedExpenses);
                System.Console.WriteLine("Wydatki jednorazowe: " + homeBudget.VariableExpenses);
                System.Console.WriteLine("Wydatki nieregularne: " + homeBudget.IrregularExpenses);
                System.Console.WriteLine("Saldo: " + homeBudget.Balance);
                System.Console.WriteLine("Saldo finalne: " + homeBudget.FinalBalance);
            }

            if (!isBudgetFound)
            {
                System.Console.WriteLine();
                System.Console.WriteLine("Budżet o podanym miesiącu nie został znaleziony.");
            }
        }

        public void AllHomeBudgetsView ()
        {
            foreach (var homeBudget in homeBudgets)
            {
                HomeBudgetByIdView(homeBudget.Id);
            }
        }

        public void HomeBudgetInstruction()
        {
            System.Console.WriteLine("Tworzenie domowego budżetu wygląda następująco:");
            System.Console.WriteLine();
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
            System.Console.WriteLine("Saldo finalne: 445");
            System.Threading.Thread.Sleep(2000);
            System.Console.WriteLine("Brawo! Twoje saldo jest dodatnie! Z resztą pieniędzy możesz zrobić co zechcesz!");
            System.Threading.Thread.Sleep(4000);
            System.Console.WriteLine();
        }
    }
}