using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.DataStorage
{
  public interface IRepositoryBank
  {
    Task<User_Dto> GetUser(string username, string password);
    Task<ActionResult<int>> PostUser(User_Dto user);
    
    Task<IEnumerable<Expenses_Dto>> GetExpense(int userId);

    Task InputExpense(List<Expenses_Dto> expense);

    Task PutExpense(Expenses_Dto expense);
    
    Task<IEnumerable<ExpenseOptions_Dto>> GetExpenseOptions();

    Task<IEnumerable<Income_Dto>> GetIncome(int userId);

    Task InputIncome(List<Income_Dto> income);

    Task PutIncome(Income_Dto income);

    Task PutSavings(Savings_Dto savings);

    Task PutLoan(Loans_Dto loan);
    Task<IEnumerable<Loans_Dto>> GetLoans(int userId);
    Task PostLoan(List<Loans_Dto> loan);

    Task<IEnumerable<Savings_Dto>> GetSavings(int userId);

    Task PostSavings(List<Savings_Dto> savings);
    Task<decimal[]> GetUserReport(int UserId);
    Task DeleteExpense(int ID);

    Task DeleteSavings(int ID);

    Task DeleteIncome(int ID);
    Task DeleteLoan(int ID);
    Task<Decimal> GetUserInfo(int UserId);

    Task PutUserInfo(int UserId, Decimal SavingsGoal);

  }
}
