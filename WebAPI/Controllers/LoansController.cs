using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WebAPI.Logic;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public LoansController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //Getting a specific customer from the database
        [HttpGet("{username}")]
        public List<Loans_Dto> GetLoans(int userId)
        {

            string connect = _configuration.GetSection("ConnectionString").GetSection("BankedDB").Value;
            using SqlConnection connection = new(connect);

            return LoanService.GetLoans(userId, connection);

        }
        //Need to create list value to add as input parameter containing all data required for expense input
        [HttpPost]
        public async void PostLoan(List<Loans_Dto> expense)
        {
            string connect = _configuration.GetSection("ConnectionString").GetSection("PrintShopDB").Value;
            await using SqlConnection connection = new(connect);
            LoanService.InputLoans(expense, connection);
        }
    }
}
