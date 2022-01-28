namespace WebAPI.Models
{
    public class Income_Dto
    {
        public int Id { get; set; }
        public int? UserPasswordsId { get; set; }
        public int? IncomeOptions { get; set; }
        public decimal IncomeAmount { get; set; }
        public int PaySchedule { get; set; }
        public string? IncomeName { get; set; }
  }
}
