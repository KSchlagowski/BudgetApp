using System.Collections.Generic;
using System.Linq;
using BudgetApp.App.Abstract;
using BudgetApp.App.Concrete;
using BudgetApp.Domain.Models;

namespace BudgetApp.App.Repositories
{
    public class HomeBudgetRepository : IHomeBudgetRepository
    { 
        public List<HomeBudget> homeBudgets { get; set; }
        private readonly IJsonService _jsonservice;
        
        public HomeBudgetRepository()
        {
            _jsonservice = new JsonService();
            homeBudgets = _jsonservice.LoadHomeBudgets();
        }

        public int AddNewHomeBudget(HomeBudget homeBudget){
            homeBudgets.Add(homeBudget);
            _jsonservice.SaveHomeBudgets(homeBudgets);

            return homeBudget.Id;
        }
        
        public bool RemoveHomeBudgetById (int id)
        {
            var homeBudget = homeBudgets.FirstOrDefault(hb => hb.Id == id);

            if (homeBudget == null)
            {
                homeBudgets.Remove(homeBudget);
                _jsonservice.SaveHomeBudgets(homeBudgets);

                return true;
            }
            
            return false;
        }
    }
}