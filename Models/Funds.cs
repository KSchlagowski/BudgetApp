namespace BudgetApp.Models
{
    public class Funds
    {
        public decimal IrregularExpensesFundBalance { get; set; } = 0;
        public decimal EmergencyFundBalance { get; set; } = 0;
        public decimal SecurityFundBalance { get; set; } = 0;
        public decimal SpecialPurposeFundBalance { get; set; } = 0;

        
    }
}