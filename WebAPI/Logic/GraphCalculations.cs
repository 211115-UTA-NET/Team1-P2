using WebAPI.Models;
using System;
using System.Collections.Generic;

namespace WebAPI.Logic
{

    public class GraphCalculations
    {
        decimal[] List = new decimal[104];

        public decimal[] list
        {
            get { return List; }
            set { List = value; }
        }
        
        public decimal CalculateTime(int N)
        {
            decimal timeline = (decimal)N / 4.00m; //4weeks is 1 month
            return timeline;
        }

        public void addExpense(Expenses_Dto item)
        {
            var day = DateTime.Now;
            var endDate = item.ExpenseEnding;
            decimal T = CalculateTime(item.ExpenseFrequency);

            for(int i = 0; i < List.Length; i++)
            {

                if(day < endDate)
                {
                    List[i] -= (i+1) * (item.ExpenseAmount * T);
                    day.AddDays(1);
                }
            }
        }

        public void addIncome(Income_Dto item)
        {
            decimal T = CalculateTime(item.PaySchedule);

            for(int i = 0; i < List.Length; i++)
            {
                List[i] += (i+1) * (item.IncomeAmount * T);
            }
        }

        public void addLoan(Loans_Dto item)
        {
            for(int i = 3; i < List.Length; i += 4)
            {
                if(item.LoanAmount > 0)
                {
                    decimal interest = ((item.LoanAmount * ((decimal)item.LoanInterest) / 100) - item.MonthlyPayments) / 4;

                    List[i] += interest;

                    item.LoanAmount -= interest;
                } 
            }
        }

        public void addSaving(Savings_Dto item)
        {
            for(int i = 3; i < List.Length; i += 4)
            {
                decimal interest = ((item.SavingsAmount * ((decimal)item.SavingsInterest) / 100) + item.SavingsAddedMonthly) / 4;

                List[i] += interest;

                item.SavingsAmount += interest;
            }
        }

        public decimal[] CalculateTotal(IEnumerable<Expenses_Dto> Expenses, IEnumerable<Income_Dto> Income, IEnumerable<Loans_Dto> Loans, IEnumerable<Savings_Dto> Savings)
        {
            Array.Clear(List, 0, List.Length);

            for(int i = 0; i < List.Length; i++)
            {
                List[i] = 0;
            }

            foreach (var item in Expenses)
            {
                addExpense(item);
            }

            foreach (var item in Income)
            {
                addIncome(item);
            }

            foreach (var item in Loans)
            {
                addLoan(item);
            }

            foreach (var item in Savings)
            {
                addSaving(item);
            }

            for(int i = 0; i < List.Length; i++)
            {
                List[i] = Math.Round(List[i], 2);
            }

            return List;

        }

    }
}