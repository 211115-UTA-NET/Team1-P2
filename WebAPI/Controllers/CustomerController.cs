#nullable disable
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WebAPI.Logic;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public CustomersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //Getting a specific customer from the database
        [HttpGet("{username}")]
        public List<User_Dto> Get(string user)
        {

            string connect = _configuration.GetSection("ConnectionString").GetSection("PrintShopDB").Value;
            using SqlConnection connection = new(connect);
            return LoginService.GetUser(user, connection);


        }
    }
}