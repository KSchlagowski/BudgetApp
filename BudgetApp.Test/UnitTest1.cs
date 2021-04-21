using System;
using Xunit;
using BudgetApp.Domain.Models;
using Mock;
using Moq;
using BudgetApp.App.Abstract;
using BudgetApp.App.Managers;
using BudgetApp.App.Concrete;

namespace BudgetApp.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Arange
            Expense expense = new Expense(1, 12, "Nutrition");
            var mock = new Mock<IExpenseService>();
            mock.Setup(s => s.GetExpenseById(1)).Returns(expense);

            MenuActionService actionService = new MenuActionService();
            //var manager = new ExpenseManager(actionService, mock.Object);

            // //Act
            // var returnedExpense = manager.ShowGetExpenseById(expense.Id);

            // //Assert    
            // Assert.Equal(expense, returnedExpense);
            
        }
    }
}
