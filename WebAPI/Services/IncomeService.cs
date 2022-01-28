
using System.Diagnostics.CodeAnalysis;
using System.Data.SqlClient;
using WebAPI.Models;
using WebAPI.DataStorage;
using Microsoft.Extensions.Logging;
namespace WebAPI.Logic
{
    public class IncomeService: IIncomeRepository
  {

    private readonly string _connectionString;
    private readonly ILogger<IIncomeRepository> _logger;

    public IncomeService(string connectionString, ILogger<IncomeService> logger)
    {
      _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
      _logger = logger;
    }

    public IncomeService(string connectionString)
    {
      _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));      
    }

    static List<Income_Dto> expenses { get; }
        static IncomeService()
        {
            expenses = new List<Income_Dto>
            {
                //if you would like to manually add a custom item
                //new Catalog {ItemID = 18, ItemName = "SuperPrint 1000", Location = "North St.", Price = 1000, quantity = 10}
            };
        }

        //Get Individual Userinfo based on username input
        public async Task<List<Income_Dto>> GetIncome(int userId)
        {
            List<Income_Dto> currentItem = new();

            string sql = $"select * from Income where UserPasswordsID={userId} "; //use userId to query for expense items

      using SqlConnection connection = new(_connectionString);
      await connection.OpenAsync();

      using SqlCommand command = new SqlCommand(sql, connection);
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                //set items in table to fields in the Dto to send back on the Get command
                var item = new Income_Dto()
                {
                  Id = (int)reader["Id"],
                  UserPasswordsId = (int)reader["UserPasswordsID"],
                  IncomeOptions = (int)reader["IncomeOptionsID"],
                  IncomeAmount = (Decimal)reader["IncomeAmount"],
                  PaySchedule = (int)reader["PaySchedule"]
                };
                currentItem.Add(item);
            }
            reader.Close();
        await connection.CloseAsync();
      if (_logger is not null)
      _logger.LogInformation("executed select statement for Income of user id {userId}", userId);
      return currentItem;
        }


        //Insert Expense to Database
        public async  Task InputIncome(List<Income_Dto> income)
        {

      if (income.Count > 0)
      {

        string sql = $"INSERT INTO dbo.Income (UserPasswordsID,IncomeOptionsID,IncomeAmount,PaySchedule) Values"; //income.Id(0) for single object id input
        foreach (var record in income)
        {
          sql = sql + "(" +
            record.UserPasswordsId + "," +
            record.IncomeOptions + "," +
            record.IncomeAmount + "," +
            record.PaySchedule + 
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
