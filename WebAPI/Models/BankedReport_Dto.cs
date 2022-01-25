namespace WebAPI.Models
{
  public class BankedReport_Dto
  {    
      public int[]? Total { get; set; }
      public DateTime[]? DateTotal { get; set; }
      public Decimal SavingsGoal { get; set; }

      public Boolean SavingsGoalSucceed { get; set; }      
    //1 -week 2- month
  }
}
