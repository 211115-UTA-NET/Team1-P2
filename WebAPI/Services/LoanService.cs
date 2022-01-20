
using System.Diagnostics.CodeAnalysis;
using System.Data.SqlClient;
using WebAPI.Models;

namespace WebAPI.Logic
{
    public class LoanService
    {
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
        public static List<Loans_Dto> GetLoans(int userId, SqlConnection connection)
        {
            List<Loans_Dto> currentItem = new();

            string sql = $"--ENTER GET COMMAND--"; //use userId to query for expense items

            connection.Open();
            using SqlCommand command = new SqlCommand(sql, connection);
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                //set items in table to fields in the Dto to send back on the Get command
                var item = new Loans_Dto()
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
        public static void InputLoans(List<Loans_Dto> expense, SqlConnection connection)
        {
            string sql = $"--ENTER INSERT COMMAND--"; //expense.Id(0) for single object id input

            connection.Open();
            using SqlCommand command = new(sql, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
