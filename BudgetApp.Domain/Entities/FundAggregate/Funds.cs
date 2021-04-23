namespace BudgetApp.Domain.Models
{
    public class Funds
    {
        public T IrregularExpensesFund{ get; set; }
        public T EmergencyFund { get; set; } 
        public T SecurityFund { get; set; } 
        public SpecialPurposeFund SpecialPurposeFund { get; set; } 

        public Funds (T irregularExpensesFund, T emergencyFund, T securityFund, SpecialPurposeFund specialPurposeFund)
        {
            IrregularExpensesFund = irregularExpensesFund;
            EmergencyFund = emergencyFund;
            SecurityFund = securityFund;
            SpecialPurposeFund = specialPurposeFund;
        }

        public Funds()
        {
            IrregularExpensesFund = new T();
            EmergencyFund = new T();
            SecurityFund = new T();
            SpecialPurposeFund = new SpecialPurposeFund();
        }
    }
}