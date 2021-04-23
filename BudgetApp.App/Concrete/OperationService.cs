using System;
using BudgetApp.App.Abstract;

namespace BudgetApp
{
    public class OperationService : IOperationService
    {
        public int ReadNumberOperation()
        {
            System.Console.WriteLine();
            string readedOperation = Console.ReadLine();
            int operation = 0;
            Int32.TryParse(readedOperation, out operation);
            System.Console.WriteLine();

            return operation;
        }

        public decimal ReadValueOperation()
        {
            System.Console.WriteLine();
            string readedOperation = Console.ReadLine();
            int operation = 0;
            Int32.TryParse(readedOperation, out operation);
            System.Console.WriteLine();

            return operation;
        }

        public string ReadTextOperation()
        {
            System.Console.WriteLine();
            string operation = Console.ReadLine();
            System.Console.WriteLine();
            
            return operation;
        }
    }
}