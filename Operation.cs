using System;

namespace BudgetApp
{
    public class OperationService
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

        public string ReadTextOperation()
        {
            System.Console.WriteLine();
            string operation = Console.ReadLine();
            System.Console.WriteLine();
            
            return operation;
        }
    }
}