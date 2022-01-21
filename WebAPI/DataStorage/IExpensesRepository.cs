using WebAPI.Models;

namespace WebAPI.Interfaces
{
  public interface IExpensesRepository
  {
    public  Task<List<Expenses_Dto>> GetExpense(int userId);

    public Task InputExpense(List<Expenses_Dto> expense);
  }
}
