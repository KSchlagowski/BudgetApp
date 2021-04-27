using System;
using System.Collections.Generic;
using System.IO;
using BudgetApp.App.Abstract;
using BudgetApp.Domain.Models;
using Newtonsoft.Json;

namespace BudgetApp.App.Concrete
{
    public class JsonService : IJsonService
    {
        private bool SaveObject(Object objectToSave, string fileName)
        {
            try
            {
                File.WriteAllText(@"../BudgetApp.Domain/Jsons/Expenses.txt", JsonConvert.SerializeObject(objectToSave));
                return true;
            }
            catch(Exception e)
            {
                System.Console.WriteLine(e);
                return false;
            }
        }

        private string LoadObject(string fileName)
        {
            try
            {
                return File.ReadAllText(@"../BudgetApp.Domain/Jsons/" + fileName);
            }
            catch(Exception e)
            {
                System.Console.WriteLine(e);
                return null;
            }
        }

        public List<Expense> LoadExpenses()
        {
            try
            {
                return JsonConvert.DeserializeObject<List<Expense>>(LoadObject("Expenses.txt"));
            }
            catch(Exception e)
            {
                System.Console.WriteLine(e);
                return null;
            }
        }

        public Funds LoadFunds()
        {
            try
            {
                return JsonConvert.DeserializeObject<Funds>(LoadObject("Funds.txt"));
            }
            catch(Exception e)
            {
                System.Console.WriteLine(e);
                return null;
            }
        }

        public List<HomeBudget> LoadHomeBudgets()
        {
            try
            {
                return JsonConvert.DeserializeObject<List<HomeBudget>>(LoadObject("HomeBudgets.txt"));
            }
            catch(Exception e)
            {
                System.Console.WriteLine(e);
                return null;
            }
        }

        public bool SaveExpenses(List<Expense> expenses)
        {
            try
            {
                File.WriteAllText(@"../BudgetApp.Domain/Jsons/Expenses.txt", JsonConvert.SerializeObject(expenses));
                return true;
            }
            catch(Exception e)
            {
                System.Console.WriteLine(e);
                return false;
            }
        }

        public bool SaveFunds(Funds funds)
        {
            try
            {
                File.WriteAllText(@"../BudgetApp.Domain/Jsons/Funds.txt", JsonConvert.SerializeObject(funds));
                return true;
            }
            catch(Exception e)
            {
                System.Console.WriteLine(e);
                return false;
            }
        }

        public bool SaveHomeBudgets(List<HomeBudget> homeBudgets)
        {
            try
            {
                File.WriteAllText(@"../BudgetApp.Domain/Jsons/HomeBudgets.txt", JsonConvert.SerializeObject(homeBudgets));
                return true;
            }
            catch(Exception e)
            {
                System.Console.WriteLine(e);
                return false;
            }
        }
    }
}