using BudgetApp.Domain.Models;

namespace BudgetApp.App.Abstract
{
    public interface IFundsService<T>
    {
        T EditIrregularExpensesFund (T irregularExpensesFund, decimal income);
        T EditEmergencyFund (T emergencyFund, decimal income);
        T EditSecurityFund (T securityFund, decimal income);
    }
}