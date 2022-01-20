#nullable disable
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WebAPI.Logic;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //Getting a specific customer from the database
        [HttpGet("{username}")]
        public List<User_Dto> GetUser(string user)
        {

            string connect = _configuration.GetSection("ConnectionString").GetSection("BankedDB").Value;
            using SqlConnection connection = new(connect);
            return LoginService.GetUser(user, connection);
            

        }
    }
}