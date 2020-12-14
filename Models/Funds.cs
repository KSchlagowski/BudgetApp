namespace BudgetApp.Fund
{
    public class Funds
    {
        public IrregularExpensesFund IrregularExpensesFund { get; set; }
        public EmergencyFund EmergencyFund { get; set; }
        public SecurityFund SecurityFund { get; set; }
        public SpecialPurposeFund SpecialPurposeFund { get; set; }

        public Funds (IrregularExpensesFund irregularExpensesFund, EmergencyFund emergencyFund, SecurityFund securityFund, SpecialPurposeFund specialPurposeFund)
        {
            IrregularExpensesFund = irregularExpensesFund;
            EmergencyFund = emergencyFund;
            SecurityFund = securityFund;
            SpecialPurposeFund = specialPurposeFund;
        }

        public Funds ()
        {
            IrregularExpensesFund = new IrregularExpensesFund();
            EmergencyFund = new EmergencyFund();
            SecurityFund = new SecurityFund();
            SpecialPurposeFund = new SpecialPurposeFund();
        }
    }
}