using WebAPI.Models;

namespace WebAPI.DataStorage
{
  public interface IUserRepository
  {
     Task<User_Dto> GetUser(string username, string password);
  }
}
