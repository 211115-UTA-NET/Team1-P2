namespace WebAPI.Models
{
    public class Savings_Dto
    {
        int Id { get; set; }
        int UserPassword { get; set; }
        string? SavingsName { get; set; }
        double SavingsAmount { get; set; }
        double SavingsInterest { get; set; }
        double SavingsAddedMonthly { get; set; }
    }
}
