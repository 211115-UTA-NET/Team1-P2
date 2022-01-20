namespace WebAPI.Models
{
    public class Loans_Dto
    {
        public int Id { get; set; }
        public int UserPasswordId { get; set; }
        public string? LoanName { get; set; }
        public double LoanAmount { get; set; }
        public double LoanInterest { get; set; }
        public double MonthlyPayments { get; set; }
    }
}
