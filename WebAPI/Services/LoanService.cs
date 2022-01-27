
using System.Diagnostics.CodeAnalysis;
using System.Data.SqlClient;
using WebAPI.Models;
using WebAPI.DataStorage;
using Microsoft.Extensions.Logging;

namespace WebAPI.Logic
{
  public class LoanService : ILoanRepository
  {
    private readonly string _connectionString;
    private readonly ILogger<ILoanRepository> _logger;

    public LoanService(string connectionString, ILogger<LoanService> logger)
    {
      _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
      _logger = logger;
    }

    public LoanService(string connectionString)
    {
      _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
    }


    static List<Loans_Dto> loans { get; }
    static LoanService()
    {
      loans = new List<Loans_Dto>
      {
        //if you would like to manually add a custom item
        //new Catalog {ItemID = 18, ItemName = "SuperPrint 1000", Location = "North St.", Price = 1000, quantity = 10}
      };
    }

    //Get Individual Userinfo based on username input
    public async Task<List<Loans_Dto>> GetLoans(int userId)
    {
      List<Loans_Dto> currentItem = new();
      string sql = $"select * from Loans where UserPasswordsID={userId}"; //use userId to query for expense items
      using SqlConnection connection = new(_connectionString);
      await connection.OpenAsync();



      using SqlCommand command = new SqlCommand(sql, connection);
      using SqlDataReader reader = command.ExecuteReader();
      while (reader.Read())
      {
        //set items in table to fields in the Dto to send back on the Get command
        var item = new Loans_Dto()
        {
          Id = (int)reader["Id"],
          UserPasswordId = (int)reader["UserPasswordsID"],
          LoanName = reader["LoanName"].ToString(),
          LoanAmount = (decimal)reader["LoanAmount"],
          LoanInterest = (double)reader["LoanInterest"],
          MonthlyPayments = (decimal)reader["MonthlyPayments"]
        };
        currentItem.Add(item);
      }
      reader.Close();
      await connection.CloseAsync();
      if (_logger is not null)
      {
        _logger.LogInformation("executed select statement for Income of user id {userId}", userId);
      }
      return currentItem;
    }


    //Insert Expense to Database
    public async Task InputLoans(List<Loans_Dto> loan)
    {


      if (loan.Count > 0)
      {
        string sql = $"INSERT INTO dbo.Loans (UserPasswordsID,LoanName,LoanAmount,LoanInterest,MonthlyPayments) Values "; //income.Id(0) for single object id input
        foreach (var record in loan)
        {
          sql = sql + "(" +
            record.UserPasswordId + "," +
            "'" +record.LoanName + "'," +
            record.LoanAmount + "," +
            record.LoanInterest + "," +
            record.MonthlyPayments +
            ")";
        }


        using SqlConnection connection = new(_connectionString);
        await connection.OpenAsync();
        using SqlCommand command = new(sql, connection);
        command.ExecuteNonQuery();
        await connection.CloseAsync();
      }
    }
  }
}
