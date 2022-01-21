
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

            string sql = $"--ENTER INSERT COMMAND--"; //use userId to query for expense items

      using SqlConnection connection = new(_connectionString);
      await connection.OpenAsync();

      using SqlCommand command = new SqlCommand(sql, connection);
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                //set items in table to fields in the Dto to send back on the Get command
                var item = new Income_Dto()
                {
                    //Id = (int)reader[0],
                    //UserPassId = username,
                    //Password = reader[2].ToString(),
                    //FirstName = reader[3].ToString(),
                    //LastName = reader[4].ToString(),
                };
                currentItem.Add(item);
            }
            reader.Close();
            connection.Close();
            return currentItem;
        }


        //Insert Expense to Database
        public static void InputIncome(List<Income_Dto> income, SqlConnection connection)
        {
            string sql = $"--ENTER INSERT COMMAND--"; //income.Id(0) for single object id input

            connection.Open();
            using SqlCommand command = new(sql, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
