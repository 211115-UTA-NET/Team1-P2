namespace WebAPI.Models
{
    public class Expenses_Dto
    {
        int Id { get; set; }
        int UserPassId { get; set; }
        int UserOptionsId { get; set; }
        double ExpenseAmount { get; set; }
        string? ExpenseFrequency { get; set; }
        DateTime? ExpenseEnding { get; set; }
        int Priority { get; set; }
    }
}
