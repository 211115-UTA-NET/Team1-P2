namespace WebAPI.Models
{
    public class WeeklySpendings_Dtos
    {
        public double Wk1Spendings { get; set; }
        public double Wk2Spendings { get; set; }
        public double Wk3Spendings { get; set; }
        public double Wk4Spendings { get; set; }

        public WeeklySpendings_Dtos(double Wk1, double Wk2, double Wk3, double Wk4)
        {
            this.Wk1Spendings = Wk1;
            this.Wk2Spendings = Wk2;
            this.Wk3Spendings = Wk3;
            this.Wk4Spendings = Wk4;
        }
    }
}
