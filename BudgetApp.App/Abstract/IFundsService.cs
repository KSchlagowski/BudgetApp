using BudgetApp.Domain.Models;

namespace BudgetApp.App.Abstract
{
    public interface IFundsService<T>
    {
        Funds GetAllFunds();

        T GetIrregularExpensesFund ();
        T GetEmergencyFund ();
        T GetSecurityFund ();
        SpecialPurposeFund GetSpecialPurposeFund ();

        T EditIrregularExpensesFund (decimal income);
        T EditEmergencyFund (decimal income);
        T EditSecurityFund (decimal income);
        SpecialPurposeFund EditSpecialPurposeFund (decimal income, string description);
    }
}