namespace BudgetApp.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public string ExpenseDescription { get; set; }
        public Expense (int id, decimal value, string expenseDescription)
        {
            Id = id;
            Value = value;
            ExpenseDescription = expenseDescription;
        }

        //Maybe categories in future
    }
}