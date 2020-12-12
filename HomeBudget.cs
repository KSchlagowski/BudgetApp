using System;

namespace BudgetApp
{
    public class HomeBudget
    {
        public string Month { get; set; }
        public decimal Earnings { get; set; }
        public decimal FixedExpenses { get; set; }
        public decimal VariableExpenses { get; set; }
        public decimal UnregularExpenses { get; set; }
        public decimal Balance { get; set; }
        public decimal FinalBalance { get; set; }
        
        public HomeBudget(string month, decimal earnings, decimal fixedExpenses, decimal variableExpenses,
        decimal unregularExpenses, decimal balance, decimal finalBalance)
        {
            Month = month;
            Earnings = earnings;
            FixedExpenses = fixedExpenses;
            VariableExpenses = variableExpenses;
            UnregularExpenses = unregularExpenses;
            Balance = balance;
            FinalBalance = finalBalance; 
        }
    }
}