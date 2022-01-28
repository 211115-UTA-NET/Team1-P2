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
    //  private readonly IConfiguration _configuration;
    //  public IncomeController(IConfiguration configuration)
    //        {
    //          _configuration = configuration;
    //    }

    private readonly IRepositoryBank _repository;

    public IncomeController(IRepositoryBank repository)
    {
      _repository = repository;
    }

    [HttpDelete("{ID}")]
    public async Task DeleteIncome(int ID)
    {


      await _repository.DeleteIncome(ID);

    }

    //Getting a specific customer from the database
    [HttpGet("{userId}")]
    public async Task<IEnumerable<Income_Dto>> GetIncome(int userId)
    {

      //    string connect = _configuration.GetSection("ConnectionStrings").GetSection("BankedDB").Value;
      //  using SqlConnection connection = new(connect);

      return await _repository.GetIncome(userId);

    }
    //Need to create list value to add as input parameter containing all data required for expense input
    [HttpPost]
    public async Task PostIncome(List<Income_Dto> income)
    {
      await _repository.InputIncome(income);

    }

    [HttpPut]
    public async Task PutIncome(Income_Dto income)
    {
      await _repository.PutIncome(income);

    }
  }
}
