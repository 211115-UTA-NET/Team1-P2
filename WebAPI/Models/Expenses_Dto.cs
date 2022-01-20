namespace WebAPI.Models
{
    public class Expenses_Dto
    {
<<<<<<< HEAD
        public int Id { get; set; }
        public int UserPassId { get; set; }
        public int UserOptionsId { get; set; }
        public double ExpenseAmount { get; set; }
        public int ExpenseFrequency { get; set; }
        public DateTime? ExpenseEnding { get; set; }
        public int Priority { get; set; }
=======
        int Id { get; set; }
        int UserPassId { get; set; }
        int UserOptionsId { get; set; }
        double ExpenseAmount { get; set; }
        string? ExpenseFrequency { get; set; }
        DateTime? ExpenseEnding { get; set; }
>>>>>>> StefanTest
    }
}
