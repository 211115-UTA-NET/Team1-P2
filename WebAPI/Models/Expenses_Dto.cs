namespace WebAPI.Models
{
    public class Expenses_Dto
    {
        public int Id { get; set; }
        public int? UserPassId { get; set; }
        public int? UserOptionsId { get; set; }
        public Decimal ExpenseAmount { get; set; }
        public int ExpenseFrequency { get; set; }
        public Nullable<DateTime> ExpenseEnding { get; set; }
        public int? Priority { get; set; }
        public string? ExpenseName { get; set; }
  }
}
