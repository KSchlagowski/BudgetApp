using BudgetApp.App.Abstract;
using BudgetApp.Domain.Models;

namespace BudgetApp.App.Repositories
{
    public class FundsRepository : IFundsRepository<T>
    {
        public T EditIrregularExpensesFund (T irregularExpensesFund, decimal income)
        {
            irregularExpensesFund.Balance += income;
            return irregularExpensesFund;
        }

        public T EditEmergencyFund (T emergencyFund, decimal income)
        {
            emergencyFund.Balance += income;
            return emergencyFund;
        }

        public T EditSecurityFund (T securityFund, decimal income)
        {
            securityFund.Balance += income;
            return securityFund;
        }
    }
}