﻿namespace WebAPI.Models
{
    public class User_Dto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
