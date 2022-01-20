namespace WebAPI.Models
{
    public class Savings_Dto
    {
        public int Id { get; set; }
        public int UserPassword { get; set; }
        public string? SavingsName { get; set; }
        public decimal SavingsAmount { get; set; }
        public decimal SavingsInterest { get; set; }
        public decimal SavingsAddedMonthly { get; set; }
    }
}
