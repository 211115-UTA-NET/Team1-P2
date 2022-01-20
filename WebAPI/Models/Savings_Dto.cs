namespace WebAPI.Models
{
    public class Savings_Dto
    {
        public int Id { get; set; }
        public int UserPassword { get; set; }
        public string? SavingsName { get; set; }
        public double SavingsAmount { get; set; }
        public double SavingsInterest { get; set; }
        public double SavingsAddedMonthly { get; set; }
    }
}
