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
            //Lists to collect data. Savings goal and Dates calculated in client
            List<decimal> TotalList = new();

            //Foreach loops to collect info, adding and subtracting from total as needed.
            int i = 0;
            foreach (var item in Expenses)
            {
                int T = CalculateTime(item.ExpenseFrequency);
                TotalList[i] -= item.ExpenseAmount * T;
                i++;
            }


            i = 0;
            foreach (var item in Income)
            {
                int T = CalculateTime(item.PaySchedule);
                TotalList[i] += item.IncomeAmount * T;
                i++;
            }


            //Savings and Loans only opperate monthly and have interest. Stopping loans at end of items or loan zero'd out
            i = 3;
            int Length = TotalList.Count;
            foreach (var item in Loans)
            {
                while(Length >= 4 || item.LoanAmount > 0)
                {
                    decimal interest = ((item.LoanAmount * ((decimal)item.LoanInterest) / 100) - item.MonthlyPayments) / 4;

                    TotalList[i] -= interest;

                    item.LoanAmount += interest;
                    i += 4;
                    Length -= 4;
                } 
            }


            i = 3;
            Length = TotalList.Count;
            foreach (var item in Savings)
            {
                while (Length >= 4)
                {
                    decimal interest = ((item.SavingsAmount * ((decimal)item.SavingsInterest) / 100) + item.SavingsAddedMonthly) / 4;

                    TotalList[i] += interest;

                    item.SavingsAmount += interest;
                    i += 4;
                    Length -= 4;
                }
            }

            //convert lists to arrays
            decimal[] Total = TotalList.ToArray();

            return Total;
            


           

        }

    }
}
