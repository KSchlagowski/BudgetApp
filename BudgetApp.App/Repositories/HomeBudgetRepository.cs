using System.Collections.Generic;
using BudgetApp.App.Abstract;
using BudgetApp.Domain.Models;

namespace BudgetApp.App.Repositories
{
    public class HomeBudgetRepository : IHomeBudgetRepository
    {
        public List<HomeBudget> homeBudgets { get; set; }
        public HomeBudgetRepository()
        {
            homeBudgets = new List<HomeBudget>();
        }

        public int AddNewHomeBudget(HomeBudget homeBudget){
            homeBudgets.Add(homeBudget);

            return homeBudget.Id;
        }
        
        public bool RemoveHomeBudgetById (int id)
        {
            foreach (var homeBudget in homeBudgets)
            {
                if (homeBudget.Id == id)
                {
                    homeBudgets.Remove(homeBudget);

                    return true;
                }
            }

            return false;
        }
    }
}