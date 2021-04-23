namespace BudgetApp.App.Abstract
{
    public interface IOperationService
    {
        int ReadNumberOperation();
        decimal ReadValueOperation();
        string ReadTextOperation();
    }
}