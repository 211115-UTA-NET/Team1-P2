using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WebAPI.DataStorage;
using WebAPI.Logic;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {

      private readonly IRepositoryBank _repository;

      public LoansController(IRepositoryBank repository)
      {
        _repository = repository;
      }

    [HttpDelete("{ID}")]
    public async Task DeleteLoan(int ID)
    {


      await _repository.DeleteLoan(ID);

    }




    //Getting a specific customer from the database
    [HttpGet("{userId}")]
        public async Task<IEnumerable<Loans_Dto>> GetLoans(int userId)
        {

//            string connect = _configuration.GetSection("ConnectionString").GetSection("BankedDB").Value;
  //          using SqlConnection connection = new(connect);

        return  await _repository.GetLoans(userId);


        }
    //Need to create list value to add as input parameter containing all data required for expense input
    [HttpPost]
    public async Task PostLoan(List<Loans_Dto> loan)
    {
      await _repository.PostLoan(loan);

    }
  }
}
