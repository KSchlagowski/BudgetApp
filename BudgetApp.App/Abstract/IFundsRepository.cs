using BudgetApp.Domain.Models;

namespace BudgetApp.App.Abstract
{
    public interface IFundsRepository<T>
    {
        Funds funds { get; set; }
        
        T GetIrregularExpensesFund ();
        T GetEmergencyFund ();
        T GetSecurityFund ();
        SpecialPurposeFund GetSpecialPurposeFund ();

        T EditIrregularExpensesFund (decimal income);
        T EditEmergencyFund (decimal income);
        T EditSecurityFund (decimal income);
        SpecialPurposeFund EditSpecialPurposeFund (decimal income, string description);
        SpecialPurposeFund EditSpecialPurposeFund (decimal income);
    }
}