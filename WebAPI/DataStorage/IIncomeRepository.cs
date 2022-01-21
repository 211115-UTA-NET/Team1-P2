using WebAPI.Models;

namespace WebAPI.DataStorage
{
  public interface IIncomeRepository
  {
    public Task<List<Income_Dto>> GetIncome(int userId);
  }
}
