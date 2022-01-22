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
        private readonly IConfiguration _configuration;

        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
          _repository = repository;
        }

    //Getting a specific customer from the database
    [HttpGet("{username}/{password}")]
        public async Task<User_Dto> GetUser(string username,string password)
        {

      //string connect = _configuration.GetSection("ConnectionString").GetSection("BankedDB").Value;
      //using SqlConnection connection = new(connect);
            return await _repository.GetUser(username, password);

    }
    }
}
