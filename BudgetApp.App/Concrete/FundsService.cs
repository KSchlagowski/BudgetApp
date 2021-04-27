using System;
using BudgetApp.App.Abstract;
using BudgetApp.App.Repositories;
using BudgetApp.Domain.Models;

namespace BudgetApp.App.Concrete
{
    public class FundsService : IFundsService<T>
    {
        private readonly IFundsRepository<T> _fundsRepository;
        
        public FundsService(IFundsRepository<T> fundsRepository){
            _fundsRepository = fundsRepository;
        }

        public Funds GetAllFunds()
        {
            return _fundsRepository.funds;
        }

        public T EditIrregularExpensesFund (decimal income)
        {
            return _fundsRepository.EditIrregularExpensesFund(income);
        }

        public T EditEmergencyFund (decimal income)
        {
            return _fundsRepository.EditEmergencyFund(income);
        }

        public T EditSecurityFund (decimal income)
        {
            return _fundsRepository.EditSecurityFund(income);
        }

        public SpecialPurposeFund EditSpecialPurposeFund (decimal income, string description)
        {
            if (description == null)
            {
                return _fundsRepository.EditSpecialPurposeFund(income);
            }

            return _fundsRepository.EditSpecialPurposeFund(income, description);
        }

        public T GetIrregularExpensesFund()
        {
            return _fundsRepository.GetIrregularExpensesFund();
        }

        public T GetEmergencyFund()
        {
            return _fundsRepository.GetEmergencyFund();
        }

        public T GetSecurityFund()
        {
            return _fundsRepository.GetSecurityFund();
        }

        public SpecialPurposeFund GetSpecialPurposeFund()
        {
            return _fundsRepository.GetSpecialPurposeFund();
        }
    }
}