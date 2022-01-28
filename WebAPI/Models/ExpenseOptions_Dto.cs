namespace WebAPI.Models
{
    public class ExpenseOptions_Dto
    {
       public int id { get; set; }
       public string? ExpenseName { get; set; }
       public int? Priority { get; set; }

    public ExpenseOptions_Dto(int id, string? expenseName, int? priority)
    {
      this.id = id;
      ExpenseName = expenseName;
      Priority = priority;
    }
  }
}
