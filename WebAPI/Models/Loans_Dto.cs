namespace WebAPI.Models
{
    public class Loans_Dto
    {
        int Id { get; set; }
        int UserPasswordId { get; set; }
        string? LoanName { get; set; }
        double LoanAmount { get; set; }
        double LoanInterest { get; set; }
        double MonthlyPayments { get; set; }
    }
}
