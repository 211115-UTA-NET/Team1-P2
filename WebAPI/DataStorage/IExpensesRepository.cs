using WebAPI.Models;

namespace WebAPI.Interfaces
{
  public interface IExpensesRepository
  {
    public  Task<List<Expenses_Dto>> GetExpense(int userId);

   // public Task<List<ExpenseOptions_Dto>> GetExpenseOptions();
    public Task InputExpense(List<Expenses_Dto> expense);


  }
}
