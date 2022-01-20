using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WebAPI.Logic;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SavingsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public SavingsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //Getting a specific customer from the database
        [HttpGet("{username}")]
        public List<Savings_Dto> GetSavings(int userId)
        {

            string connect = _configuration.GetSection("ConnectionString").GetSection("BankedDB").Value;
            using SqlConnection connection = new(connect);

            return SavingsService.GetSavings(userId, connection);

        }
        //Need to create list value to add as input parameter containing all data required for expense input
        [HttpPost]
        public async void PostSavings(List<Savings_Dto> savings)
        {
            string connect = _configuration.GetSection("ConnectionString").GetSection("PrintShopDB").Value;
            await using SqlConnection connection = new(connect);
            SavingsService.InputSavings(savings, connection);
        }
    }
}
