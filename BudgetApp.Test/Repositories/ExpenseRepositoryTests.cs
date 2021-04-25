using Xunit;
using FluentAssertions;
using BudgetApp.Domain.Models;
using BudgetApp.App.Repositories;
using BudgetApp.App.Abstract;

namespace BudgetApp.Test.Repositories
{
    public class ExpenseRepositoryTests
    {
        IExpenseRepository repository = new ExpenseRepository();

        [Fact]
        public void AddNewExpense_ProperExpense_True()
        {
            int id = 1;
            string description = "desc.";

            var returnedId = repository.AddNewExpense(id, description);

            returnedId.Should().Be(id);
        }

        [Fact]
        public void RemoveExpenseById_ProperId_True()
        {
            Expense expense = new Expense(1, 1, "desc.");
            repository.AddNewExpense(expense);

            var returnedId = repository.RemoveExpenseById(expense.Id);

            returnedId.Should().Be(expense.Id);
        }

        [Fact]
        public void GetExpenseById_ProperId_True()
        {
            Expense expense = new Expense(1, 1, "desc.");
            repository.AddNewExpense(expense);

            var returnedExpense = repository.GetExpenseById(expense.Id);

            returnedExpense.Should().BeOfType(typeof(Expense));
            returnedExpense.Should().NotBeNull();
            returnedExpense.Should().BeSameAs(expense);
        }
    }
}