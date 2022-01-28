using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.DataStorage
{
  public interface IUserRepository
  {
     Task<User_Dto> GetUser(string username, string password);


    Task<ActionResult<int>> PostUser(User_Dto user);

    Task<decimal[]> InformationCollectorLoop(int UserId);

  }
}
