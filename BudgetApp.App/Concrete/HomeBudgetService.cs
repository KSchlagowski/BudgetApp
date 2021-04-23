using System.Collections.Generic;
using BudgetApp.App.Abstract;
using BudgetApp.Domain.Models;

namespace BudgetApp.App.Concrete
{
    public class HomeBudgetService : IHomeBudgetService
    {
        private readonly IHomeBudgetRepository _homeBudgetRepository;
        public HomeBudgetService(IHomeBudgetRepository homeBudgetRepository)
        {
            _homeBudgetRepository = homeBudgetRepository;
        }

        public List<HomeBudget> GetAllHomeBudgets() =>
            _homeBudgetRepository.homeBudgets;

        public int AddNewHomeBudget(HomeBudget homeBudget) =>
            _homeBudgetRepository.AddNewHomeBudget(homeBudget);
        
        
        public bool RemoveHomeBudgetById (int id) =>
            _homeBudgetRepository.RemoveHomeBudgetById(id);
    }
}