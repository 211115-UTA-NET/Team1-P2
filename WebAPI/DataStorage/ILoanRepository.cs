using WebAPI.Models;

namespace WebAPI.DataStorage
{
  public interface ILoanRepository
  {
    public Task<List<Loans_Dto>> GetLoans(int userId);
    public Task InputLoans(List<Loans_Dto> loan);
  }
}
