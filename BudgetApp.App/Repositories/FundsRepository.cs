using BudgetApp.App.Abstract;
using BudgetApp.Domain.Models;

namespace BudgetApp.App.Repositories
{
    public class FundsRepository : IFundsRepository<T>
    {
        public Funds funds { get; set; }

        public FundsRepository()
        {
            funds = new Funds();
        }

        public T EditIrregularExpensesFund (decimal income)
        {
            funds.IrregularExpensesFund.Balance += income;
            return funds.IrregularExpensesFund;
        }

        public T EditEmergencyFund (decimal income)
        {
            funds.EmergencyFund.Balance += income;
            return funds.EmergencyFund;
        }

        public T EditSecurityFund (decimal income)
        {
            funds.SecurityFund.Balance += income;
            return funds.SecurityFund;
        }

        public SpecialPurposeFund EditSpecialPurposeFund (decimal income, string description)
        {
            funds.SpecialPurposeFund.Balance += income;
            funds.SpecialPurposeFund.Description = description;
            return funds.SpecialPurposeFund;
        }

        public SpecialPurposeFund EditSpecialPurposeFund (decimal income)
        {
            funds.SpecialPurposeFund.Balance += income;
            return funds.SpecialPurposeFund;
        }

        public T GetIrregularExpensesFund()
        {
            return funds.IrregularExpensesFund;
        }

        public T GetEmergencyFund()
        {
            return funds.EmergencyFund;
        }

        public T GetSecurityFund()
        {
            return funds.SecurityFund;
        }

        public SpecialPurposeFund GetSpecialPurposeFund()
        {
            return funds.SpecialPurposeFund;
        }
    }
}