using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WebAPI.DataStorage;

using WebAPI.Logic;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {

    private readonly IRepositoryBank _repository;


    public ExpensesController(IRepositoryBank repository)
    {
      _repository = repository;
    }



    [Route("Options")]
    [HttpGet]
    public async Task<IEnumerable<ExpenseOptions_Dto>> GetExpenseOptions()
    {


      return await _repository.GetExpenseOptions();

    }


    //Getting a specific customer from the database
    [HttpGet("{userId}")]
    public async Task<IEnumerable<Expenses_Dto>> GetExpenses(int userId)
        {


          return await _repository.GetExpense(userId);

        }

    [HttpDelete("{ID}")]
    public async Task DeleteExpense(int ID)
    {


       await _repository.DeleteExpense(ID);

    }


    //Need to create list value to add as input parameter containing all data required for expense input
    [HttpPost]
    public async Task PostExpense(List<Expenses_Dto> expense)
    {
      await _repository.InputExpense(expense);
    }

    [HttpPut]
    public async Task PutExpense(Expenses_Dto expense)
    {
      await _repository.PutExpense(expense);
    }


  }
}
