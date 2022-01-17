namespace WebAPI.Models
{
    public class Income_Dto
    {
        int Id { get; set; }
        int UserPasswordsId { get; set; }
        int IncomeOptions { get; set; }
        double IncomeAmount { get; set; }
        string? PaySchedule { get; set; }
    }
}
