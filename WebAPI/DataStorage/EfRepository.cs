using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Logic;
namespace WebAPI.DataStorage
{
  public class EfRepository : IRepositoryBank
  {

    private readonly BankedDBContext _context;
    private readonly ILogger<EfRepository> _logger;

    public EfRepository(BankedDBContext context, ILogger<EfRepository> logger)
    {
      _context = context;
      _logger = logger;
    }

    public async Task<User_Dto> GetUser(string username, string password)
    {
      UserPassword? user = await _context.UserPasswords
    .Where(r => r.UserName == username && r.UserPassword1 == password)
    .FirstOrDefaultAsync();

      _logger.LogInformation("function GetUser {username}", username);

      return new User_Dto(user.Id, user.UserName, user.UserPassword1, user.FirstName, user.LastName);
      //return user;

    }

    public async Task<ActionResult<int>> PostUser(User_Dto user)
    {
      int id = 0;
      if (user is not null)
      {
        //string sql = $"select id from dbo.UserPasswords where username=" + "'" + user.Username + "'";

        UserPassword? useret = await _context.UserPasswords
      .Where(r => r.UserName == user.Username)
      .FirstOrDefaultAsync();
        if (useret == null)
        {
          var newUser = new UserPassword
          {
            UserName = user.Username,
            UserPassword1 = user.Password,
            FirstName = user.FirstName,
            LastName = user.LastName

          };
          _context.UserPasswords.Add(newUser);
          await _context.SaveChangesAsync();
          id = newUser.Id;
          _logger.LogInformation("create User function PostUser {username}", user.Username);
        }
      }
      _logger.LogInformation("User Already exists function PostUser {username}", user.Username);
      return id;
    }


    //    string sql = $"select * from Income where UserPasswordsID={userId} "; //use userId to query for expense items

    public async Task<IEnumerable<Loans_Dto>> GetLoans(int userId)
    {
      IEnumerable<Loan> Loans = await _context.Loans
        .Where(r => r.Id == userId)
        .ToListAsync();

      return Loans.Select(r =>
      {
        // here, i have a string like "rock" and i want an enum value like Logic.Move.Rock
        Loans_Dto v = new();
        v.Id = r.Id;
        v.UserPasswordId = r.UserPasswordsId;
        v.LoanName = r.LoanName;
        v.LoanAmount = r.LoanAmount;
        v.LoanInterest = r.LoanInterest;
        v.MonthlyPayments = r.MonthlyPayments;
        return v;
      });

      _logger.LogInformation("function GetLoans user id {userId}", userId);
    }

    public async Task<IEnumerable<Savings_Dto>> GetSavings(int userId)
    {
      IEnumerable<Saving> Savings = await _context.Savings
        .Where(r => r.Id == userId)
        .ToListAsync();

      return Savings.Select(r =>
      {
        // here, i have a string like "rock" and i want an enum value like Logic.Move.Rock
        Savings_Dto v = new();
        v.Id = r.Id;
        v.UserPassword = r.UserPasswordsId;
        v.SavingsName = r.SavingsName;
        v.SavingsAmount = r.SavingsAmount;
        v.SavingsInterest = r.SavingsInterest;
        v.SavingsAddedMonthly = r.SavingsAddedMonthly;
        return v;
      });

      _logger.LogInformation("function GetSavings user id {userId}", userId);
    }

    public async Task<IEnumerable<Income_Dto>> GetIncome(int userId)
    {




      return await (from ic in _context.Incomes
                    join io in _context.IncomeOptions on ic.IncomeOptionsId equals io.Id
                    where ic.UserPasswordsId == userId
                    select new Income_Dto
                    {
                      Id = ic.Id,
                      UserPasswordsId = ic.UserPasswordsId,
                      IncomeOptions = ic.IncomeOptionsId,
                      IncomeAmount = ic.IncomeAmount,
                      PaySchedule = ic.PaySchedule,
                      IncomeName = io.IncomeName,
                    }).ToListAsync();


      _logger.LogInformation("function GetIncome user id {userId}", userId);
    }

    public async Task<IEnumerable<Expenses_Dto>> GetExpense(int userId)
    {
      //      join eo in _context.ExpenseOptions on ex.ExpenseOptionsId equals eo.PriorityId


      return await (from ex in _context.Expenses
                    join eo in _context.ExpenseOptions on ex.ExpenseOptionsId equals eo.Id
                    where ex.UserPasswordsId == userId
                    select new Expenses_Dto
                    {
                      Id = ex.Id,
                      UserPassId = ex.UserPasswordsId,
                      UserOptionsId = ex.ExpenseOptionsId,
                      ExpenseAmount = ex.ExpenseAmount,
                      ExpenseFrequency = ex.EspenseFrequency,
                      ExpenseEnding = ex.ExpenseEnding,
                      Priority = ex.SeverityOfNeed,
                      ExpenseName= eo.ExpenseName
                    }).ToListAsync();

      _logger.LogInformation("function GetExpense user id {userId}", userId);
    }


    public async Task<IEnumerable<ExpenseOptions_Dto>> GetExpenseOptions()
    {
      IEnumerable<ExpenseOption> ExpenseOptions = await _context.ExpenseOptions
    .ToListAsync();

      return ExpenseOptions.Select(r =>
      {
        // here, i have a string like "rock" and i want an enum value like Logic.Move.Rock
        return new ExpenseOptions_Dto(r.Id, r.ExpenseName, r.PriorityId);
      });


      _logger.LogInformation("function GetExpenseOptions ");
    }


    public async Task PostSavings(List<Savings_Dto> savings)
    {
            var newSaving = new Saving
            {
              Id = savings[0].Id,
              UserPasswordsId = savings[0].UserPassword,
              SavingsName= savings[0].SavingsName,
              SavingsAmount= savings[0].SavingsAmount,
              SavingsInterest= savings[0].SavingsInterest,
              SavingsAddedMonthly = savings[0].SavingsAddedMonthly
            };
    _context.Savings.Add(newSaving);
      await _context.SaveChangesAsync();
      _logger.LogInformation("function PostSavings user id {userId}", savings[0].Id);
    }

  public async Task PostLoan(List<Loans_Dto> loan)
    {
      var newLoan = new Loan
      {
        Id = loan[0].Id,
        UserPasswordsId = loan[0].UserPasswordId,
        LoanName = loan[0].LoanName,
        LoanAmount = loan[0].LoanAmount,
        LoanInterest = loan[0].LoanInterest,
        MonthlyPayments = loan[0].MonthlyPayments,
        

      };
      _context.Loans.Add(newLoan);
      await _context.SaveChangesAsync();

      _logger.LogInformation("function PostLoan user id {userId}", loan[0].Id);

    }

    public async Task InputIncome(List<Income_Dto> income)
    {
      var newIncome = new Income
      {
        UserPasswordsId = income[0].UserPasswordsId,
        IncomeOptionsId = income[0].IncomeOptions,
        IncomeAmount = income[0].IncomeAmount,
        PaySchedule = income[0].PaySchedule
      };
        _context.Incomes.Add(newIncome);
        await _context.SaveChangesAsync();

      _logger.LogInformation("function InputIncome user id {userId}", newIncome.Id);
    }


    public async Task DeleteSavings(int ID)
    {

      Saving Saving = new Saving() { Id = ID };
      _context.Savings.Attach(Saving);
      _context.Savings.Remove(Saving);
      _context.SaveChanges();
      _logger.LogInformation("function DeleteSavings user id {userId}", ID);
    }

    public async Task DeleteIncome(int ID)
    {

      Income Income = new Income() { Id = ID };
  _context.Incomes.Attach(Income);
      _context.Incomes.Remove(Income);
      _context.SaveChanges();
      _logger.LogInformation("function DeleteIncome user id {userId}", ID);
    }

    public async Task DeleteLoan(int ID)
{

  Loan Loan = new Loan() { Id = ID };
  _context.Loans.Attach(Loan);
  _context.Loans.Remove(Loan);
  _context.SaveChanges();
      _logger.LogInformation("function DeleteLoan user id {userId}", ID);

    }


public async Task DeleteExpense(int ID)
    {

      Expense Expense = new Expense() { Id = ID };
      _context.Expenses.Attach(Expense);
      _context.Expenses.Remove(Expense);
      _context.SaveChanges();
      _logger.LogInformation("function DeleteExpense user id {userId}", ID);

    }


    public async Task PutExpense(List<Expenses_Dto> expense)
    {

      Expense? Expense = await _context.Expenses
      .Where(r => r.Id== expense[0].Id)
      .FirstOrDefaultAsync();

      if (Expense is not null)
      {
        Expense.UserPasswordsId = expense[0].UserPassId;
        Expense.ExpenseOptionsId = expense[0].UserOptionsId;
        Expense.ExpenseAmount = expense[0].ExpenseAmount;
        Expense.EspenseFrequency = expense[0].ExpenseFrequency;
        Expense.ExpenseEnding = expense[0].ExpenseEnding;
        Expense.SeverityOfNeed = expense[0].Priority;
        _context.Expenses.Add(Expense);
        await _context.SaveChangesAsync();
        _logger.LogInformation("function PutExpense user id {userId}", expense[0].Id);
      }
      else
      {
        _logger.LogInformation("id not exists function PutExpense user id {userId}", expense[0].Id);
      }
    }


    public async Task InputExpense(List<Expenses_Dto> expense)
  {
      var newExpense = new Expense
      {
        UserPasswordsId = expense[0].UserPassId,
        ExpenseOptionsId = expense[0].UserOptionsId,
        ExpenseAmount = expense[0].ExpenseAmount,
        EspenseFrequency = expense[0].ExpenseFrequency,
        ExpenseEnding = expense[0].ExpenseEnding,
        SeverityOfNeed = expense[0].Priority
    };
       _context.Expenses.Add(newExpense);
        await _context.SaveChangesAsync();
      _logger.LogInformation("function InputExpense user id {userId}", newExpense.Id);
    }


    public async Task<decimal[]> GetUserReport(int UserId)
    {
      //var logger = loggerFactory.CreateLogger();
      //ILogger<ExpensesService> _logger =new();
      //ExpensesService ESrv = new(_connectionString);
      IEnumerable<Expenses_Dto> LExp = await this.GetExpense(UserId);

      IEnumerable<Income_Dto> LIncome = await this.GetIncome(UserId);

      IEnumerable<Loans_Dto> LLoan = await this.GetLoans(UserId);

      IEnumerable<Savings_Dto> LSave = await this.GetSavings(UserId);

      _logger.LogInformation("function GetUserReport user id {userId}", UserId);
      return GraphCalculations.CalculateTotal(LExp, LIncome, LLoan, LSave);

    }


    public async Task<Decimal> GetUserInfo(int UserId)
    {
      UserInfo? userInfo = await _context.UserInfos
    .Where(r => r.UserPasswordsId == UserId)
    .FirstOrDefaultAsync();

      _logger.LogInformation("function GetUserInfo {UserId}", UserId);
      decimal total=0;
      if (userInfo is not null) total = (Decimal)userInfo.SavingsGoal;
      return total;
      //return user;

    }

    public async Task PutUserInfo(int Id, Decimal SavingsGoal)
    {
      //string sql = $"select id from dbo.UserPasswords where username=" + "'" + user.Username + "'";

      UserInfo? UserInfo = await _context.UserInfos
    .Where(r => r.UserPasswordsId == Id)
    .FirstOrDefaultAsync();

      if (UserInfo == null)
      {
        var newUserInfo = new UserInfo
        {
          UserPasswordsId = Id,
          SavingsGoal = SavingsGoal          
        };
        _context.UserInfos.Add(newUserInfo);
        await _context.SaveChangesAsync();
        //id = newUser.Id;
        _logger.LogInformation("create User function PutUserInfo {Id}", Id);

      }
      else
      {
        UserInfo.SavingsGoal = SavingsGoal;
        await _context.SaveChangesAsync();
        _logger.LogInformation("Update User Info function PutUserInfo {Id}", Id);
      }
    }
  }
}
