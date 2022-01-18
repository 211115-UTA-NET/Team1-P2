
using System.Diagnostics.CodeAnalysis;
using System.Data.SqlClient;
using WebAPI.Models;

namespace WebAPI.Logic
{
    public class LoginService
    {
        static List<User_Dto> customers { get; }
        static LoginService()
        {
            customers = new List<User_Dto>
            {
                //if you would like to manually add a custom item
                //new Catalog {ItemID = 18, ItemName = "SuperPrint 1000", Location = "North St.", Price = 1000, quantity = 10}
            };
        }

        //Get Individual Userinfo based on username input
        public static List<User_Dto> GetUser(string username, SqlConnection connection)
        {
            List<User_Dto> currentUser = new();

            string sql = $"SELECT * FROM ExistingCustomers WHERE Username = '{username}'";

            connection.Open();
            using SqlCommand command = new SqlCommand(sql, connection);
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var user = new User_Dto()
                {
                    Id = (int)reader[0],
                    Username = username,
                    Password = reader[2].ToString(),
                    FirstName = reader[3].ToString(),
                    LastName = reader[4].ToString(),
                };
                currentUser.Add(user);
            }
            reader.Close();
            connection.Close();
            return customers;
        }
    }
}