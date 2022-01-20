namespace WebAPI.Models
{
    public class WeeklySpendings_Dtos
    {
        public decimal Wk1Spendings { get; set; }
        public decimal Wk2Spendings { get; set; }
        public decimal Wk3Spendings { get; set; }
        public decimal Wk4Spendings { get; set; }

        public WeeklySpendings_Dtos(decimal Wk1, decimal Wk2, decimal Wk3, decimal Wk4)
        {
            this.Wk1Spendings = Wk1;
            this.Wk2Spendings = Wk2;
            this.Wk3Spendings = Wk3;
            this.Wk4Spendings = Wk4;
        }
    }
}
