
using System.Diagnostics.CodeAnalysis;
using System.Data.SqlClient;
using WebAPI.Models;
using WebAPI.DataStorage;
using Microsoft.Extensions.Logging;

namespace WebAPI.Logic
{
    public class SavingsService: ISavingsRepository
  {

    private readonly string _connectionString;
    private readonly ILogger<ISavingsRepository> _logger;

      public SavingsService(string connectionString, ILogger<SavingsService> logger)
      {
        _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        _logger = logger;
      }


        static List<Savings_Dto> expenses { get; }
        static SavingsService()
        {
            expenses = new List<Savings_Dto>
            {
                //if you would like to manually add a custom item
                //new Catalog {ItemID = 18, ItemName = "SuperPrint 1000", Location = "North St.", Price = 1000, quantity = 10}
            };
        }

        //Get Individual Userinfo based on username input
        public async Task<List<Savings_Dto>> GetSavings(int userId)
        {
            List<Savings_Dto> currentItem = new();

            string sql = $"select * from Savings where UserPasswordsID={userId}"; //use userId to query for expense items

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();
            using SqlCommand command = new SqlCommand(sql, connection);
            using SqlDataReader reader = command.ExecuteReader();

    
      while (reader.Read())
            {
                //set items in table to fields in the Dto to send back on the Get command
                var item = new Savings_Dto()
                {
                  Id = (int)reader["Id"],
                  UserPassword = (int)reader["UserPasswordsID"],
                  SavingsName = reader["SavingsName"].ToString(),
                  SavingsAmount = (decimal)reader["SavingsAmount"],
                  SavingsInterest = (double)reader["SavingsInterest"],
                  SavingsAddedMonthly = (decimal)reader["SavingsAddedMonthly"]
                };
                currentItem.Add(item);
            }
            reader.Close();
            connection.Close();
            return currentItem;
        }


        //Insert Expense to Database
        public static void InputSavings(List<Savings_Dto> expense, SqlConnection connection)
        {
            string sql = $"--ENTER INSERT COMMAND--"; //expense.Id(0) for single object id input

            connection.Open();
            using SqlCommand command = new(sql, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
