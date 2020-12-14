namespace BudgetApp.Models
{
    public class Funds
    {
        public Fund IrregularExpensesFund{ get; set; }
        public Fund EmergencyFund { get; set; } 
        public Fund SecurityFund { get; set; } 
        public SpecialPurposeFund SpecialPurposeFund { get; set; } 

        public Funds (Fund irregularExpensesFund, Fund emergencyFund, Fund securityFund, SpecialPurposeFund specialPurposeFund)
        {
            IrregularExpensesFund = irregularExpensesFund;
            EmergencyFund = emergencyFund;
            SecurityFund = securityFund;
            SpecialPurposeFund = specialPurposeFund;
        }

        public Funds()
        {
            IrregularExpensesFund = new Fund();
            EmergencyFund = new Fund();
            SecurityFund = new Fund();
            SpecialPurposeFund = new SpecialPurposeFund();
        }
    }
}