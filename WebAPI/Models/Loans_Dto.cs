namespace WebAPI.Models
{
    public class Loans_Dto
    {
        public int Id { get; set; }
        public int? UserPasswordId { get; set; }
        public string? LoanName { get; set; }
        public decimal? LoanAmount { get; set; }
        public double? LoanInterest { get; set; }
        public decimal? MonthlyPayments { get; set; }
        public Nullable<DateTime> ExpenseEnding { get; set; }
  }
}
