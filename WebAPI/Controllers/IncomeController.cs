using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WebAPI.DataStorage;
using WebAPI.Logic;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
      //  public IncomeController(IConfiguration configuration)
//        {
  //          _configuration = configuration;
    //    }

    private readonly IIncomeRepository _repository;

    public IncomeController(IIncomeRepository repository)
    {
      _repository = repository;
    }


    //Getting a specific customer from the database
    [HttpGet("{id}")]
        public async Task<List<Income_Dto>> GetIncome(int userId)
        {

        //    string connect = _configuration.GetSection("ConnectionStrings").GetSection("BankedDB").Value;
          //  using SqlConnection connection = new(connect);

            return await _repository.GetIncome(userId);

        }
        //Need to create list value to add as input parameter containing all data required for expense input
        [HttpPost]
        public async void PostIncome(List<Income_Dto> income)
        {
            string connect = _configuration.GetSection("ConnectionStrings").GetSection("PrintShopDB").Value;
            await using SqlConnection connection = new(connect);
            IncomeService.InputIncome(income, connection);
        }
    }
}
