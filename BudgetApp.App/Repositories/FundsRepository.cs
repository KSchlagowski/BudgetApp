using BudgetApp.App.Abstract;
using BudgetApp.App.Concrete;
using BudgetApp.Domain.Models;

namespace BudgetApp.App.Repositories
{
    public class FundsRepository : IFundsRepository<T>
    {
        public Funds funds { get; set; }

        private readonly IJsonService _jsonService;

        public FundsRepository()
        {
            _jsonService = new JsonService();
            funds = _jsonService.LoadFunds();
        }

        public T EditIrregularExpensesFund (decimal income)
        {
            funds.IrregularExpensesFund.Balance += income;
            _jsonService.SaveFunds(funds);
            return funds.IrregularExpensesFund;
        }

        public T EditEmergencyFund (decimal income)
        {
            funds.EmergencyFund.Balance += income;
            _jsonService.SaveFunds(funds);
            return funds.EmergencyFund;
        }

        public T EditSecurityFund (decimal income)
        {
            funds.SecurityFund.Balance += income;
            _jsonService.SaveFunds(funds);
            return funds.SecurityFund;
        }

        public SpecialPurposeFund EditSpecialPurposeFund (decimal income, string description)
        {
            funds.SpecialPurposeFund.Balance += income;
            funds.SpecialPurposeFund.Description = description;
            _jsonService.SaveFunds(funds);
            return funds.SpecialPurposeFund;
        }

        public SpecialPurposeFund EditSpecialPurposeFund (decimal income)
        {
            funds.SpecialPurposeFund.Balance += income;
            _jsonService.SaveFunds(funds);
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