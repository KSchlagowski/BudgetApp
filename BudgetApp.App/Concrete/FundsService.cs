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
        public T EditIrregularExpensesFund (T irregularExpensesFund, decimal income)
        {
            return _fundsRepository.EditIrregularExpensesFund(irregularExpensesFund, income);
        }

        public T EditEmergencyFund (T emergencyFund, decimal income)
        {
            return _fundsRepository.EditEmergencyFund(emergencyFund, income);
        }

        public T EditSecurityFund (T securityFund, decimal income)
        {
            return _fundsRepository.EditSecurityFund(securityFund, income);
        }
    }
}