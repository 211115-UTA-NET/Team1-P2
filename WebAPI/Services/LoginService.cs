
using System.Diagnostics.CodeAnalysis;
using System.Data.SqlClient;
using WebAPI.Models;
using WebAPI.DataStorage;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Logic
{
    public class LoginService : IUserRepository
  {

    private readonly string _connectionString;
    private readonly ILogger<IUserRepository> _logger;

    public LoginService(string connectionString, ILogger<LoginService> logger)
    {
      _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
      _logger = logger;
    }
    static List<User_Dto> customers { get; }
        static LoginService()
        {
            customers = new List<User_Dto>
            {
                //if you would like to manually add a custom item
                //new Catalog {ItemID = 18, ItemName = "SuperPrint 1000", Location = "North St.", Price = 1000, quantity = 10}
            };
        }


    public async Task<ActionResult<int>> PostUser(User_Dto user)
    {

      int id=0;
      if (user is not null)
      {
        string sql = $"INSERT INTO dbo.UserPasswords " +
          $"(username,UserPassword,FirstName,LastName) OUTPUT INSERTED.Id Values "; //income.Id(0) for single object id input
          sql = sql + "(" +
              "'" + user.Username + "'," +
              "'" + user.Password + "'," +
          "'" +  user.FirstName + "'," +
          "'" + user.LastName + "'" + ") ";


        using SqlConnection connection = new(_connectionString);
        await connection.OpenAsync();
        using SqlCommand command = new(sql, connection);
        id = (int)command.ExecuteScalar();
        //command.ExecuteNonQuery();
        await connection.CloseAsync();
      }
      return id;
    }


    //Get Individual Userinfo based on username input
    public async Task<User_Dto> GetUser(string username, string password) 
        {
        User_Dto user=new();

            string sql = $"SELECT * FROM UserPasswords WHERE Username = '{username}' and UserPassword='{password}'";

      using SqlConnection connection = new(_connectionString);
      await connection.OpenAsync();
      using SqlCommand command = new SqlCommand(sql, connection);
      using SqlDataReader reader = command.ExecuteReader();


      if (reader.Read())
            {
              user.Id = (int)reader["Id"];
              user.Username = reader["username"].ToString();
              user.Password = reader["UserPassword"].ToString();
              user.FirstName = reader["FirstName"].ToString();
              user.LastName = reader["LastName"].ToString();
                //currentUser.Add(user);
            }
            reader.Close();
      await connection.CloseAsync();
      _logger.LogInformation("executed select statement for Income of user id {username}", username);
      return user;
        }
    }
}
