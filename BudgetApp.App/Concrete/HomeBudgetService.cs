using System;
using System.Collections.Generic;

using BudgetApp.Models;

namespace BudgetApp.App.Concrete
{
    public class HomeBudgetService
    {
        public List<HomeBudget> homeBudgets { get; set; }
        public HomeBudgetService()
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