using WebAPI.Models;

namespace WebAPI.Logic
{
    public class Calculations
    {

    public BankedReport_Dto InformationCollectorLoop()
    {
      return null;
    }
      

        //public List<WeeklySpendings_Dtos> InformationCollector()
        //{
        //    List<Income_Dto> income = new();
        //    List<Loans_Dto> loans = new();
        //    List<Savings_Dto> savings = new();
        //    List<Expenses_Dto> expenses = new();
            
        //    try
        //    {
        //        //income = {Get user income info}
        //        //loans = {Get user loan info}
        //        //savings = {Get user savings info}
        //        //expenses = {Get user expenses info}
        //    }
        //    catch
        //    {
        //        Console.WriteLine("Error: Could not pull information.");
        //    }

        //    List<WeeklySpendings_Dtos> monthlyIncome = new();
        //    if (income != null)
        //        monthlyIncome = IncomeCalculator(income);

        //    List<WeeklySpendings_Dtos> monthlyLoans = new();
        //    if (loans != null)
        //        monthlyLoans = LoansCalculator(loans);

        //    List<WeeklySpendings_Dtos> monthlySavings = new();
        //    if (savings != null)
        //        monthlySavings = SavingsCalculator(savings);

        //    List<WeeklySpendings_Dtos> monthlyExpenses = new();
        //    if (expenses != null)
        //        monthlyExpenses = ExpensesCalculator(expenses);

        //    List<WeeklySpendings_Dtos> finalWeeklySpendings = new();
        //    finalWeeklySpendings = MonthlySpendingsCalculator(monthlyIncome, monthlyLoans, monthlySavings, monthlyExpenses);

        //    return finalWeeklySpendings;
        //}

        //private List<WeeklySpendings_Dtos> IncomeCalculator(List<Income_Dto> income)
        //{
        //    List<WeeklySpendings_Dtos> monthlyIncome = new();

        //    foreach (var record in income)
        //    {
        //        if (record.PaySchedule == 1)
        //        {
        //            decimal incomeAmount = record.IncomeAmount;
        //            monthlyIncome.Add(new(incomeAmount, incomeAmount, incomeAmount, incomeAmount));
        //        }
        //        else if (record.PaySchedule == 2)
        //        {
        //            decimal incomeAmount = record.IncomeAmount;
        //            monthlyIncome.Add(new(0, incomeAmount, 0, incomeAmount));
        //        }
        //    }

        //    return monthlyIncome;
        //}

        //private List<WeeklySpendings_Dtos> LoansCalculator(List<Loans_Dto> loans)
        //{
        //    List<WeeklySpendings_Dtos> monthlyLoans = new();

        //    foreach (var record in loans)
        //    {
        //        //Final loan amount after interest added and monthly payment payed | Implement later
        //        //decimal loanIncrease = record.LoanAmount * record.LoanInterest;
        //        //decimal loanAmount = record.LoanAmount + loanIncrease;
        //        //decimal finalAmount = loanAmount - record.MonthlyPayments;

        //        decimal monthlyPayment = record.MonthlyPayments;

        //        monthlyLoans.Add(new(monthlyPayment, 0, 0, 0));
        //    }

        //    return monthlyLoans;
        //}

        //private List<WeeklySpendings_Dtos> SavingsCalculator(List<Savings_Dto> savings)
        //{
        //    List<WeeklySpendings_Dtos> monthlySavings = new();

        //    foreach (var record in savings)
        //    {
        //        //Final savings amount after interest added and monthly addition | Implement later
        //        //decimal savingsIncrease = record.SavingsAmount * record.SavingsInterest;
        //        //decimal savingsAmount = record.SavingsAmount + savingsIncrease;
        //        //decimal finalAmount = savingsAmount + record.SavingsAddedMonthly;

        //        decimal monthlyAddition = record.SavingsAddedMonthly;

        //        monthlySavings.Add(new(monthlyAddition, 0, 0, 0));
        //    }

        //    return monthlySavings;
        //}

        //private List<WeeklySpendings_Dtos> ExpensesCalculator(List<Expenses_Dto> expenses)
        //{
        //    List<WeeklySpendings_Dtos> monthlyExpenses = new();

        //    foreach (var record in expenses)
        //    {
        //        if (record.ExpenseFrequency == 1)
        //        {
        //            decimal expenseAmount = record.ExpenseAmount;
        //            monthlyExpenses.Add(new(expenseAmount, 0, 0, 0));
        //        }
        //        else if (record.ExpenseFrequency == 2)
        //        {
        //            decimal expenseAmount = record.ExpenseAmount;
        //            monthlyExpenses.Add(new(expenseAmount, expenseAmount, 0, 0));
        //        }
        //        else if (record.ExpenseFrequency == 3)
        //        {
        //            decimal expenseAmount = record.ExpenseAmount;
        //            monthlyExpenses.Add(new(expenseAmount, expenseAmount, expenseAmount, 0));
        //        }
        //        else if (record.ExpenseFrequency == 4)
        //        {
        //            decimal expenseAmount = record.ExpenseAmount;
        //            monthlyExpenses.Add(new(expenseAmount, expenseAmount, expenseAmount, expenseAmount));
        //        }
        //        else
        //        {
        //            decimal expenseTotal = record.ExpenseAmount * record.ExpenseFrequency;
        //            decimal expenseWeekly = expenseTotal / 4;
        //            monthlyExpenses.Add(new(expenseWeekly, expenseWeekly, expenseWeekly, expenseWeekly));
        //        }
        //    }
        //    return monthlyExpenses;
        //}

        private List<WeeklySpendings_Dtos> MonthlySpendingsCalculator(List<WeeklySpendings_Dtos> income, List<WeeklySpendings_Dtos> loans, List<WeeklySpendings_Dtos> savings, List<WeeklySpendings_Dtos> expenses)
        {
            List<WeeklySpendings_Dtos> monthlyExpenses = new();

            //List<decimal> incomeSum = CategoryCalculator(income);
            List<decimal> loansSum = CategoryCalculator(loans);
            List<decimal> savingsSum = CategoryCalculator(savings);
            List<decimal> expensesSum = CategoryCalculator(expenses);

            decimal wk1Total = (loansSum[0] + savingsSum[0] + expensesSum[0]); // - incomeSum[0];
            decimal wk2Total = (loansSum[1] + savingsSum[1] + expensesSum[1]) + wk1Total; // - incomeSum[1];
            decimal wk3Total = (loansSum[2] + savingsSum[2] + expensesSum[2]) + wk2Total; // - incomeSum[2];
            decimal wk4Total = (loansSum[3] + savingsSum[3] + expensesSum[3]) + wk3Total; // - incomeSum[3];

            monthlyExpenses.Add(new(wk1Total, wk2Total, wk3Total, wk4Total));

            return monthlyExpenses;
        }

        private List<decimal> CategoryCalculator(List<WeeklySpendings_Dtos> category)
        {
            List<decimal> monthlyTotals = new();

            foreach (var record in category)
            {
                monthlyTotals[0] = record.Wk1Spendings;
                monthlyTotals[1] = record.Wk2Spendings;
                monthlyTotals[2] = record.Wk3Spendings;
                monthlyTotals[3] = record.Wk4Spendings;
            }
            return monthlyTotals;
        }
    }
}
