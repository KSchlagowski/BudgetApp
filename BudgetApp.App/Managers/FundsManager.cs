using System;
using BudgetApp.App.Abstract;
using BudgetApp.App.Concrete;
using BudgetApp.App.Repositories;
using BudgetApp.Domain.Models;

namespace BudgetApp.App.Managers
{
    public class FundsManager
    {
        private readonly IFundsService<T> _fundsService;
        private readonly MenuActionService _actionService;

        public FundsManager(MenuActionService actionService, IFundsService<T> fundsService)
        {
            _actionService = actionService;
            _fundsService = fundsService;
        }

        public int FundsMenuView()
        {
            var fundsMenu = _actionService.GetMenuActionsByMenuName("FundsMenu");
            Console.WriteLine("Fundusze.");
            for (int i = 0; i < fundsMenu.Count; i++)
            {
                Console.WriteLine($"{fundsMenu[i].Id}. {fundsMenu[i].Name}");
            }
            System.Console.WriteLine();

            string readedOperation = Console.ReadLine();
            int operation;
            Int32.TryParse(readedOperation, out operation);
            System.Console.WriteLine();

            return operation;
        }

        public void AllFundsView ()
        {
            Funds funds = _fundsService.GetAllFunds();

            System.Console.WriteLine();
            System.Console.WriteLine($"Stan funduszu wydatków nieregularnych (FWN): {funds.IrregularExpensesFund.Balance}");
            System.Console.WriteLine($"Stan funduszu awaryjnego (FA): {funds.EmergencyFund.Balance}");
            System.Console.WriteLine($"Stan funduszu bezpieczeństwa (FB): {funds.SecurityFund.Balance}");
            System.Console.WriteLine($"Cel funduszu celowego: {funds.SpecialPurposeFund.Description}");
            System.Console.WriteLine($"Stan funduszu celowego: {funds.SpecialPurposeFund.Balance}");
            System.Console.WriteLine();
        }

        public SpecialPurposeFund EditSpecialPurposeFundView (decimal income)
        {
            string description = null;

            System.Console.WriteLine();
            System.Console.WriteLine("Czy chcesz zmienić opis funduszu celowego? [Y/N]");
            System.Console.WriteLine();

            string operation = Console.ReadLine();
            System.Console.WriteLine();
            if (operation == "Y" || operation == "y" || operation == "1")
            {
                System.Console.WriteLine();
                System.Console.WriteLine("Wpisz opis swojego funduszu celowego:");
                System.Console.WriteLine();
                description = Console.ReadLine();
            }
            
            return _fundsService.EditSpecialPurposeFund(income, description);
        }

        public void FundsInstruction()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Czym są fundusze wydatków nieregularnych, awaryjny i bezpieczeństwa? Jak z nich korzystać?");
            System.Console.WriteLine();
            System.Threading.Thread.Sleep(2000);
            System.Console.WriteLine("Oprócz wydatków stałych i jednorazowych, ponoszonych w danym miesiącu, oddzielną grupę kosztów stanowią wydatki nieregularne,");
            System.Console.WriteLine("czyli takie, które ponosimy raz lub kilka razy do roku. Większość budżetów domowych zawodzi właśnie dlatego, że pomija wydatki ponoszone niesystematycznie.");
            System.Console.WriteLine();
            System.Threading.Thread.Sleep(5000);
            System.Console.WriteLine("Aby dobrze zaplanować swój budżet domowy powinieneś zsumować roczne wydatki na rzeczy takie jak:");
            System.Threading.Thread.Sleep(2000);
            System.Console.WriteLine("*Prezenty na urodziny (i koszty ich organizacji)");
            System.Threading.Thread.Sleep(1500);
            System.Console.WriteLine("*Prezenty na święta"); 
            System.Threading.Thread.Sleep(1500);
            System.Console.WriteLine("*Ubezpieczenie auta");
            System.Threading.Thread.Sleep(1500);
            System.Console.WriteLine("*Przeglądy i naprawy auta");
            System.Threading.Thread.Sleep(1500);
            System.Console.WriteLine("*Wakacyjne wyjazdy");
            System.Threading.Thread.Sleep(1500);
            System.Console.WriteLine("*Kolonie dla dzieci");
            System.Threading.Thread.Sleep(1500);
            System.Console.WriteLine("*Leczenie (lekarze i lekarstwa)");
            System.Threading.Thread.Sleep(1500);
            System.Console.WriteLine("*Ubrania");
            System.Threading.Thread.Sleep(1500);
            System.Console.WriteLine("*Szkolenia");
            System.Threading.Thread.Sleep(1500);
            System.Console.WriteLine("*Remonty i doposażanie domu");
            System.Threading.Thread.Sleep(2000);
            System.Console.WriteLine("Dla bezpieczeństwa powinieneś co miesiąc odkładać na (FWN) 1/10 rocznej sumy wydatków nieregularnych.");
            System.Threading.Thread.Sleep(5000);
            System.Console.WriteLine("Dzięki temu, zawsze będziesz miał pieniądze w gotowości.");
            System.Threading.Thread.Sleep(5000);
            System.Console.WriteLine();
            System.Console.WriteLine("Fundusz awaryjny, to fundusz z pieniędzmi na wydatki, których nie da się zaplanować.");
            System.Threading.Thread.Sleep(5000);
            System.Console.WriteLine("Pieniądze na \"czarną godzinę\" zawsze warto posiadać,");
            System.Console.WriteLine("dlatego zaleca się wpłacanie nadwyżki pozostałej po zaplanowaniu budżetu domowego właśnie na to konto.");
            System.Threading.Thread.Sleep(5000);
            System.Console.WriteLine();
            System.Console.WriteLine("Fundusz Bezpieczeństwa to najważniejszy cel finansowy, jaki powinien osiągnąć absolutnie każdy.");
            System.Threading.Thread.Sleep(5000);
            System.Console.WriteLine("Co gdy utracisz pracę lub będziesz chciał się przebranżowić?");
            System.Threading.Thread.Sleep(5000);
            System.Console.WriteLine("Pomaga w tym (FB), czyli swojego rodzaju poduszka bezpieczeństwa, która spełnia dwie podstawowe funkcje:");
            System.Threading.Thread.Sleep(5000);
            System.Console.WriteLine("1. Realnie chronić nas przed finansowymi \"wpadkami\".");
            System.Console.WriteLine();
            System.Threading.Thread.Sleep(1500);
            System.Console.WriteLine("2. Dawać realne poczucie bezpieczeństwa.");
            System.Threading.Thread.Sleep(5000);
            System.Console.WriteLine();
            System.Console.WriteLine("Właśnie po to, powinieneś trzymać na tym koncie sumę, która wystarczy ci na przeżycie +/- 6 miesięcy.");
            System.Threading.Thread.Sleep(5000);
            System.Console.WriteLine();
            System.Console.WriteLine("Ostatnim funduszem jest fundusz celowy, czyli oszczędności na zakup nowego komputera, wyjazd wakacyjny itp.");
            System.Threading.Thread.Sleep(5000);
            System.Console.WriteLine();
            System.Console.WriteLine("______________________________________________________________________________________________________________________________");
            System.Console.WriteLine("Pamiętaj, że ta aplikacja może ci pomóc w zaplanowaniu budżetu domowego oraz kontrolowania stanu swoich kont oszczędnościowych");
            System.Console.WriteLine("abyś miał lepszy wgląd na sytuację, ale to od ciebie zależy czy dobrze ją wykorzystasz.");
            System.Console.WriteLine("______________________________________________________________________________________________________________________________");
            System.Threading.Thread.Sleep(5000);
            System.Console.WriteLine();
        }
    }
}