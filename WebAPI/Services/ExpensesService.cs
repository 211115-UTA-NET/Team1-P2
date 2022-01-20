
using System.Diagnostics.CodeAnalysis;
using System.Data.SqlClient;
using WebAPI.Models;
using WebAPI.Interfaces;
using Microsoft.Extensions.Logging;

namespace WebAPI.Logic
{
    public class ExpensesService: IExpensesRepository
  {

    private readonly string _connectionString;
    private readonly ILogger<IExpensesRepository> _logger;

    public ExpensesService(string connectionString, ILogger<ExpensesService> logger)
    {
      _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
      _logger = logger;
    }
    static List<Expenses_Dto> expenses { get; }
        static ExpensesService()
        {
            expenses = new List<Expenses_Dto>
            {
                //if you would like to manually add a custom item
                //new Catalog {ItemID = 18, ItemName = "SuperPrint 1000", Location = "North St.", Price = 1000, quantity = 10}
            };
        }

        //Get Individual Userinfo based on username input
        public static List<Expenses_Dto> GetExpense(int userId, SqlConnection connection)
        {
            List<Expenses_Dto> currentItem = new();

            string sql = $"select * from Expenses where userId={{ userId }} "; //use userId to query for expense items

            connection.Open();
            using SqlCommand command = new SqlCommand(sql, connection);
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                //set items in table to fields in the Dto to send back on the Get command
                var item = new Expenses_Dto()
                {
                  Id=(int)reader["Id"],
                  UserPassId= (int)reader["UserPassId"],
                  UserOptionsId = (int)reader["UserOptionsId"],
                  ExpenseAmount = (decimal)reader["ExpenseAmount"],
                  ExpenseFrequency = (int)reader["ExpenseFrequency"],
                  ExpenseEnding=  reader["ExpenseEnding"]== DBNull.Value?null: Convert.ToDateTime(reader["ExpenseEnding"])
                  ,
                  Priority = (int)reader["Priority"]
                  
                //Id = (int)reader[0],
                //UserPassId = username,
                //Password = reader[2].ToString(),
                //FirstName = reader[3].ToString(),
    
                };
                currentItem.Add(item);
            }
            reader.Close();
            connection.Close();
            return currentItem;
        }


    public async Task<List<Expenses_Dto>> GetExpense(int userId)
    {
      List<Expenses_Dto> currentItem = new();

      string sql = $"select Expenses.*,ExpenseOptions.ID as Priority from Expenses inner join ExpenseOptions on Expenses.ExpenseOptionsID=ExpenseOptions.ID  where UserPasswordsID={ userId } "; //use userId to query for expense items
      using SqlConnection connection = new(_connectionString);
      await connection.OpenAsync();
      using SqlCommand command = new SqlCommand(sql, connection);
      using SqlDataReader reader = command.ExecuteReader();
      while (reader.Read())
      {
        //set items in table to fields in the Dto to send back on the Get command
        var item = new Expenses_Dto()
        {
          Id = (int)reader["Id"],
          UserPassId = (int)reader["UserPasswordsID"],
          UserOptionsId = (int)reader["ExpenseOptionsID"],
          ExpenseAmount = (Decimal)reader["ExpenseAmount"],
          ExpenseFrequency = (int)reader["EspenseFrequency"],
          ExpenseEnding = reader["ExpenseEnding"] == DBNull.Value ? null : Convert.ToDateTime(reader["ExpenseEnding"]),
          Priority = (int)reader["Priority"]

          //Id = (int)reader[0],
          //UserPassId = username,
          //Password = reader[2].ToString(),
          //FirstName = reader[3].ToString(),

        };
        currentItem.Add(item);
      }
      await reader.ReadAsync();      
      await connection.CloseAsync();
      _logger.LogInformation("executed select statement for Expenses of user id {player}", userId);
      return currentItem;
    }

    //Insert Expense to Database
    public static void InputExpense(List<Expenses_Dto> expense, SqlConnection connection)
        {
            string sql = $"--ENTER INSERT COMMAND--"; //expense.Id(0) for single object id input

            connection.Open();
            using SqlCommand command = new(sql, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
