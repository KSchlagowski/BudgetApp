using System;
using Xunit;
using BudgetApp.Domain.Models;
using Moq;
using BudgetApp.App.Abstract;
using BudgetApp.App.Managers;
using BudgetApp.App.Concrete;
using FluentAssertions;
using BudgetApp.App.Repositories;

namespace BudgetApp.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Arange
            Expense expense = new Expense(1, 12, "Nutrition");
            //var mock = new Mock<IExpenseRepository>();
            // mock.Setup(s => s.AddNewExpense(expense)).Returns(1);

            // var manager = new ExpenseService(mock.Object);
            var service = new ExpenseService(new ExpenseRepository());
            
            // //Act
            var returnedExpense = service.AddNewExpense(expense.Value, expense.Description);

            // //Assert    
            //Assert.Equal(expense.Id, returnedExpense);
            returnedExpense.Should().BeOfType(typeof(int));
            returnedExpense.Should().Be(expense.Id);
        }
    }
}
