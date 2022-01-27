using WebAPI.Models;
using System;
using System.Collections.Generic;

namespace WebAPI.Logic
{

    public class GraphCalculations
    {

        public decimal CalculateTime(int N)
        {
            decimal timeline = (decimal)N / 4.00m; //4weeks is 1 month
            return timeline;
        }

        public decimal[] CalculateTotal(List<Expenses_Dto> Expenses, List<Income_Dto> Income, List<Loans_Dto> Loans, List<Savings_Dto> Savings)
        {
            //Array to collect data. Savings goal and Dates calculated in client. 104 Values is 2 years
            decimal[] List = new decimal[104];

            //Foreach loops to collect info, adding and subtracting from total as needed.
            //while loops to iterate through each array item
            int i;
            decimal T;

            for(i = 0; i < List.Length; i++)
            {
                List[i] = 0;
            }


            foreach (var item in Expenses)
            {
                var day = DateTime.Now;
                var endDate = item.ExpenseEnding;
                T = CalculateTime(item.ExpenseFrequency);

               for(i = 0; i < List.Length; i++)
                {

                    if(day < endDate)
                    {
                        List[i] -= (i+1) * (item.ExpenseAmount * T);
                        day.AddDays(1);
                    }
                }
            }

            foreach (var item in Income)
            {
                 T = CalculateTime(item.PaySchedule);

                for(i = 0; i < List.Length; i++)
                {
                    List[i] += (i+1) * (item.IncomeAmount * T);
                }
            }


            //Savings and Loans only opperate monthly and have interest. Stopping loans at end of items or loan zero'd out
            
            foreach (var item in Loans)
            {
                for(i = 3; i < List.Length; i += 4)
                {
                    if(item.LoanAmount > 0)
                    {
                        decimal interest = ((item.LoanAmount * ((decimal)item.LoanInterest) / 100) - item.MonthlyPayments) / 4;

                        List[i] += interest;

                        item.LoanAmount -= interest;
                    } 
                }
            }

            foreach (var item in Savings)
            {
                for(i = 3; i < List.Length; i += 4)
                {
                    decimal interest = ((item.SavingsAmount * ((decimal)item.SavingsInterest) / 100) + item.SavingsAddedMonthly) / 4;

                    List[i] += interest;

                    item.SavingsAmount += interest;
                }
            }

            return List;

        }

    }
}
