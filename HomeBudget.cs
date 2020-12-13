using System;

namespace BudgetApp
{
    public class HomeBudget
    {
        public int Id { get; set; }
        public string Month { get; set; }
        public decimal Earnings { get; set; }
        public decimal FixedExpenses { get; set; }
        public decimal VariableExpenses { get; set; }
        public decimal IrregularExpenses { get; set; }
        public decimal Balance { get; set; }
        public decimal FinalBalance { get; set; }
        
        public HomeBudget(int id, string month, decimal earnings, decimal fixedExpenses, decimal variableExpenses,
        decimal unregularExpenses, decimal balance, decimal finalBalance)
        {
            Id = id;
            Month = month;
            Earnings = earnings;
            FixedExpenses = fixedExpenses;
            VariableExpenses = variableExpenses;
            IrregularExpenses = unregularExpenses;
            Balance = balance;
            FinalBalance = finalBalance; 
        }
    }
}