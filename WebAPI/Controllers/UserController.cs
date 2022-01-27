#nullable disable
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WebAPI.DataStorage;
using WebAPI.Logic;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

    private readonly IRepositoryBank _repository;


    public UserController(IRepositoryBank repository)
    {
      _repository = repository;
    }




    //Getting a specific customer from the database
    [HttpGet("{username}/{password}")]
        public async Task<User_Dto> GetUser(string username,string password)
        {

      return await _repository.GetUser(username, password);
      //return await _repository.GetUser(username, password);

    }

    [Route("Report")]
    [HttpGet]
    public async Task<decimal[]> GetUserReport(int UserId)
    {
      return await _repository.GetUserReport(UserId);
    }


    [HttpPost]
    public async Task<ActionResult<int>> PostUser(User_Dto user)
    {
      return await _repository.PostUser(user);

    }


  }
}
