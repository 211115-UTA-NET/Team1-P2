using WebAPI.Models;

namespace WebAPI.DataStorage
{
  public interface ISavingsRepository
  {
    public Task<List<Savings_Dto>> GetSavings(int userId);
  }
}
