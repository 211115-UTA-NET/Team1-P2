using WebAPI.Models;
using System;
using System.Collections.Generic;

namespace WebAPI.Logic
{

    public class GraphCalculations
    {

        public int CalculateTime(int N)
        {
            int timeline = N / 4; //4weeks is 1 month
            return timeline;
        }

        public decimal[] CalculateTotal(List<Expenses_Dto> Expenses, List<Income_Dto> Income, List<Loans_Dto> Loans, List<Savings_Dto> Savings)
        {
            //Array to collect data. Savings goal and Dates calculated in client. 104 Values is 2 years
            decimal[] List = new decimal[104];

            //Foreach loops to collect info, adding and subtracting from total as needed.
            //while loops to iterate through each array item
            int i = 0;
            foreach (var item in Expenses)
            {
                while(i <= 104)
                {
                    int T = CalculateTime(item.ExpenseFrequency);
                    List[i] -= item.ExpenseAmount * T;
                    i++;
                }
                i = 0;
            }


            foreach (var item in Income)
            {
                while(i <= 104)
                {
                    int T = CalculateTime(item.PaySchedule);
                    List[i] += item.IncomeAmount * T;
                    i++;
                }
                i = 0;
            }


            //Savings and Loans only opperate monthly and have interest. Stopping loans at end of items or loan zero'd out
            i = 3;
            foreach (var item in Loans)
            {
                while(i <= 104)
                {
                    while(item.LoanAmount > 0 || i >= 104)
                    {
                        decimal interest = ((item.LoanAmount * ((decimal)item.LoanInterest) / 100) - item.MonthlyPayments) / 4;

                        List[i] -= interest;

                        item.LoanAmount += interest;
                        i += 4;
                    } 
                }
                i = 0;
            }


            i = 3;
            foreach (var item in Savings)
            {
                while(i <= 104)
                {
                    decimal interest = ((item.SavingsAmount * ((decimal)item.SavingsInterest) / 100) + item.SavingsAddedMonthly) / 4;

                    List[i] += interest;

                    item.SavingsAmount += interest;
                    i += 4;
                }

            }

            return List;
            


           

        }

    }
}
