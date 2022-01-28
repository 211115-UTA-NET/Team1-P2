using WebAPI.Models;

namespace WebAPI.DataStorage
{
  public interface ISavingsRepository
  {
    public Task<List<Savings_Dto>> GetSavings(int userId);
    public Task InputSavings(List<Savings_Dto> Savings);
  }
}
