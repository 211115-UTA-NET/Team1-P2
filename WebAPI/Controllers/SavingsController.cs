using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WebAPI.DataStorage;
using WebAPI.Logic;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SavingsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        //public SavingsController(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}
      private readonly ISavingsRepository _repository;

      public SavingsController(ISavingsRepository repository)
      {
        _repository = repository;
      }


    //Getting a specific customer from the database
    [HttpGet("{userId}")]
        public async Task<List<Savings_Dto>> GetSavings(int userId)
        {


            return await _repository.GetSavings(userId);

        }
        //Need to create list value to add as input parameter containing all data required for expense input
        [HttpPost]
        public async Task PostSavings(List<Savings_Dto> savings)
        {
      //      string connect = _configuration.GetSection("ConnectionString").GetSection("PrintShopDB").Value;
      // await using SqlConnection connection = new(connect);

      await _repository.InputSavings(savings);
    }
    }
}
