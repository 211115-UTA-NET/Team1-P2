using WebAPI.Models;
using System;
using System.Collections.Generic;

namespace WebAPI.Logic
{

    public class GraphCalculations
    {

        public static decimal CalculateTime(decimal N)
        {
            decimal timeline = N /4;//4weeks is 1 month

        return timeline;
        }

        public static decimal[] CalculateTotal(IEnumerable<Expenses_Dto> Expenses, IEnumerable<Income_Dto> Income, IEnumerable<Loans_Dto> Loans, IEnumerable<Savings_Dto> Savings)
        {
            //Array to collect data. Savings goal and Dates calculated in client. 104 Values is 2 years
            decimal[] List = new decimal[105];

            //Foreach loops to collect info, adding and subtracting from total as needed.
            //while loops to iterate through each array item
            int i = 0;
            foreach (var item in Expenses)
            {
                var day = DateTime.Now;
                var endDate = item.ExpenseEnding;

                while(i <= 104 || day < endDate)
                {
                    decimal T = CalculateTime((decimal)item.ExpenseFrequency);
                    List[i] -= (decimal)item.ExpenseAmount * T;
                    i++;
                    day=day.AddDays(7);
                }
                i = 0;
            }


            foreach (var item in Income)
            {
                while(i <= 104)
                {
                    decimal T = CalculateTime((decimal)item.PaySchedule);
                    List[i] += (decimal)item.IncomeAmount * T;
                    i++;
                }
                i = 0;
            }


            //Savings and Loans only opperate monthly and have interest. Stopping loans at end of items or loan zero'd out
            i = 3;
            foreach (var item in Loans)
            {
            //    while(i <= 104)
              //  {
                    while(item.LoanAmount > 0 && i <= 104)
                    {
                        decimal interest = (((decimal)item.LoanAmount * ((decimal)item.LoanInterest) / 100) - (decimal)item.MonthlyPayments) / 4;

                        List[i] += interest;

                        item.LoanAmount -= interest;
                        i++;//i += 4;
                    } 
//                }
                i = 0;
            }


            i = 3;
            foreach (var item in Savings)
            {
                while(i <= 104)
                {
                    decimal interest = (((decimal)item.SavingsAmount * ((decimal)item.SavingsInterest) / 100) + (decimal)item.SavingsAddedMonthly) / 4;

                    List[i] += interest;

                    item.SavingsAmount += interest;
                    i++;//i += 4;
                }

            }

      for (i = 0; i < List.Length; i++)
        List[i] = Math.Round(List[i]);

            for(int i = 0; i < List.Length; i++)
            {
                List[i] = Math.Round(List[i], 2);
            }

            return List;
            


           

        }

    }
}
