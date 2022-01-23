using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WebAPI.Interfaces;
using WebAPI.Logic;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        //public ExpensesController(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        private readonly IExpensesRepository _repository;

        public ExpensesController(IExpensesRepository repository)
            {
              _repository = repository;
            }

    [Route("Options")]
    [HttpGet]
    public async Task<List<ExpenseOptions_Dto>> GetExpenseOptions()
    {

      //            string connect = _configuration.GetSection("ConnectionStrings").GetSection("BankedDB").Value;
      //            using SqlConnection connection = new(connect);

      return await _repository.GetExpenseOptions();
      //  return ExpensesService.GetExpense(userId, connection);

    }


    //Getting a specific customer from the database
    //[HttpGet("{username}")] Delete by Shaul
    [HttpGet("{userId}")]
    public async Task<List<Expenses_Dto>> GetExpenses(int userId)
        {

      //            string connect = _configuration.GetSection("ConnectionStrings").GetSection("BankedDB").Value;
      //            using SqlConnection connection = new(connect);

          return await _repository.GetExpense(userId);
        //  return ExpensesService.GetExpense(userId, connection);

        }


    

    //Need to create list value to add as input parameter containing all data required for expense input
        [HttpPost]
        public async Task PostExpense(List<Expenses_Dto> expense)
        {
      //string connect = _configuration.GetSection("ConnectionStrings").GetSection("PrintShopDB").Value;
      //await using SqlConnection connection = new(connect);
      await _repository.InputExpense(expense);
        }
    }
}
