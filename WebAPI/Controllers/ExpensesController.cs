using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WebAPI.Logic;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ExpensesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //Getting a specific customer from the database
        [HttpGet("{username}")]
        public List<Expenses_Dto> GetExpenses(int userId)
        {

            string connect = _configuration.GetSection("ConnectionString").GetSection("BankedDB").Value;
            using SqlConnection connection = new(connect);

            return ExpensesInputService.GetExpense(userId, connection);

        }
        //Need to create list value to add as input parameter containing all data required for expense input
        [HttpPost]
        public async void AddExpense(List<Expenses_Dto> expense)
        {
            string connect = _configuration.GetSection("ConnectionString").GetSection("PrintShopDB").Value;
            await using SqlConnection connection = new(connect);
            ExpensesInputService.InputExpense(expense, connection);
        }
    }
}
