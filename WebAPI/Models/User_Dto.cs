namespace WebAPI.Models
{
    public class User_Dto
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    public User_Dto()
    { }
      public User_Dto(int id, string? username, string? password, string? firstName, string? lastName)
      {
        Id = id;
        Username = username;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
      }
  }
}
