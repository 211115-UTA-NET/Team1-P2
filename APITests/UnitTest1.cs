using Xunit;
using WebAPI.Models;
using WebAPI.Logic;
using System;
using System.Collections.Generic;

namespace APITests
{
    public class UnitTest1
    {

        [Fact]
        public void workingTest()
        {
            int a = 1;

            Assert.Equal(1, a);
        }

        [Fact]
        public void TestDto_Expenses_DataCheck()
        {
            Expenses_Dto X = new();

            X.Id = 1;
            X.UserPassId = 2;
            X.UserOptionsId = 3;
            X.ExpenseAmount = 4.00m;
            X.ExpenseFrequency = 5;
            //X.ExpenseEnding =
            X.Priority = 7;

            Assert.Equal(1, X.Id);
            Assert.Equal(2, X.UserPassId);
            Assert.Equal(3, X.UserOptionsId);
            Assert.Equal(4.00m, X.ExpenseAmount);
            Assert.Equal(5, X.ExpenseFrequency);
            //Assert.Equal(DateTime.Now, X.ExpenseEnding);
            Assert.Equal(7, X.Priority);
        }

        [Fact]
        public void TestDto_Income_DataCheck()
        {
           Income_Dto X = new();

            X.Id = 1;
            X.UserPasswordsId = 2;
            X.IncomeOptions = 3;
            X.IncomeAmount = 4.00m;
            X.PaySchedule = 5;

            Assert.Equal(1, X.Id);
            Assert.Equal(2, X.UserPasswordsId);
            Assert.Equal(3, X.IncomeOptions);
            Assert.Equal(4.00m, X.IncomeAmount);
            Assert.Equal(5, X.PaySchedule);

        }

        [Fact]
        public void TestDto_Loans_DataCheck()
        {
            Loans_Dto X = new();

            X.Id = 1;
            X.UserPasswordId = 2;
            X.LoanName = "three";
            X.LoanAmount = 4.00m;
            X.LoanInterest = 5.00;
            X.MonthlyPayments = 6.00m;

            Assert.Equal(1,X.Id);
            Assert.Equal(2,X.UserPasswordId);
            Assert.Equal("three",X.LoanName);
            Assert.Equal(4.00m,X.LoanAmount);
            Assert.Equal(5.00,X.LoanInterest);
            Assert.Equal(6.00m, X.MonthlyPayments);
        }

        [Fact]
        public void TestDto_Savings_DataCheck()
        {
            Savings_Dto X = new();

            X.Id = 1;
            X.UserPassword = 2;
            X.SavingsName = "three";
            X.SavingsAmount = 4.00m;
            X.SavingsInterest = 5.00;
            X.SavingsAddedMonthly = 6.00m;

            Assert.Equal(1, X.Id);
            Assert.Equal(2, X.UserPassword);
            Assert.Equal("three", X.SavingsName);
            Assert.Equal(4.00m, X.SavingsAmount);
            Assert.Equal(5.00, X.SavingsInterest);
            Assert.Equal(6.00m, X.SavingsAddedMonthly);
        }

        [Fact]
        public void TestDto_User_DataCheck()
        {
            User_Dto X = new();

            X.Id = 1;
            X.Username = "two";
            X.Password = "three";
            X.FirstName = "four";
            X.LastName = "five";

            Assert.Equal(1, X.Id);
            Assert.Equal("two", X.Username);
            Assert.Equal("three", X.Password);
            Assert.Equal("four", X.FirstName);
            Assert.Equal("five", X.LastName);
        }

        [Fact]
        public void TestDto_WeeklySpendings_DataCheck()
        {
            WeeklySpendings_Dtos X = new(1.00m,2.00m,3.00m,4.00m);

            Assert.Equal(1.00m, X.Wk1Spendings);
            Assert.Equal(2.00m, X.Wk2Spendings);
            Assert.Equal(3.00m, X.Wk3Spendings);
            Assert.Equal(4.00m, X.Wk4Spendings);
        }

        [Fact]
        public void TestLogic_GraphCalculations_Time()
        {
            GraphCalculations G = new();
            decimal time = G.CalculateTime(20);

            Assert.Equal(5, time);
        }

        [Fact]
        public void TestLogic_GraphCalculations()
        {
            GraphCalculations G = new();

            List<Expenses_Dto> E = new();
            List<Income_Dto> I = new();
            List<Savings_Dto> S = new();
            List<Loans_Dto> L = new();

            E.Add(new Expenses_Dto(){
                ExpenseAmount = 40.00m,
                ExpenseFrequency = 4,
                ExpenseEnding = DateTime.Parse("2 18 2023")
            });
            E.Add(new Expenses_Dto(){
                ExpenseAmount = 5.00m,
                ExpenseFrequency = 4,
                ExpenseEnding = DateTime.Parse("2 18 2024")
            });

            I.Add(new Income_Dto(){
                IncomeAmount = 1000.00m,
                PaySchedule = 1
            });

            decimal[] D = G.CalculateTotal(E,I,L,S);

            Assert.Equal(205.00m, D[0]);
            Assert.Equal(410.00m, D[1]);
            Assert.Equal(820.00m, D[3]);
        }

        [Fact]
        public void TestLogic_GraphCalculations_LoansAndSavings()
        {
            GraphCalculations G = new();

            List<Expenses_Dto> E = new();
            List<Income_Dto> I = new();
            List<Savings_Dto> S = new();
            List<Loans_Dto> L = new();


            L.Add(new Loans_Dto(){
                LoanAmount = 1000.00m,
                LoanInterest = 4.0,
                MonthlyPayments = 100.00m
            });

            decimal[] D = G.CalculateTotal(E,I,L,S);

            Assert.Equal(-15.00m, D[3]);
            Assert.Equal(-14.85m, D[7]);
        }
    }
}