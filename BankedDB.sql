CREATE TABLE [dbo].[UserPasswords](
	[ID] [int] Identity (1,1) Primary key,
	[UserName] [nvarchar](50) NULL,
	[UserPassword] [nvarchar](50) NULL,
	FirstName [nvarchar](50) NULL,
	LastName [nvarchar](50) NULL,
	unique (UserName)
) 

CREATE TABLE [dbo].[UserInfo](
	UserPasswordsID int Foreign key references UserPasswords (ID) ON DELETE CASCADE Primary key ,
	SavingsGoal Money default(0)
)
go

create Table dbo.Priorities(
[ID] [int] Identity (1,1) Primary key,
priorityName nvarchar(50) not null,
unique (priorityName)
)
CREATE TABLE [dbo].IncomeOptions(
[ID] [int] Identity (1,1) Primary key,
IncomeName nvarchar(50) ,
priorityId int Foreign key references Priorities (ID) 
)
CREATE TABLE [dbo].Income(
[ID] [int] Identity (1,1) Primary key,
UserPasswordsID int Foreign key references UserPasswords (ID) ON DELETE CASCADE,
IncomeOptionsID int Foreign key references IncomeOptions (ID) ,
IncomeAmount Money default(0),
PaySchedule int
)

CREATE TABLE [dbo].ExpenseOptions(
[ID] [int] Identity (1,1) Primary key,
ExpenseName nvarchar(50) ,
priorityId int Foreign key references Priorities (ID) 
)
CREATE TABLE [dbo].Expenses(
[ID] [int] Identity (1,1) Primary key,
UserPasswordsID int Foreign key references UserPasswords (ID) ON DELETE CASCADE,
ExpenseOptionsID int Foreign key references ExpenseOptions (ID) ,
ExpenseAmount Money default(0),
EspenseFrequency int,
ExpenseEnding datetime2,
SeverityOfNeed int
)

CREATE TABLE [dbo].Savings(
[ID] [int] Identity (1,1) Primary key,
UserPasswordsID int Foreign key references UserPasswords (ID) ON DELETE CASCADE,
SavingsName nvarchar(100) not null,
SavingsAmount Money default(0),
SavingsInterest float,
SavingsAddedMonthly Money default(0)
)

CREATE TABLE [dbo].Loans(
[ID] [int] Identity (1,1) Primary key,
UserPasswordsID int Foreign key references UserPasswords (ID) ON DELETE CASCADE,
LoanName nvarchar(100) not null,
LoanAmount Money default(0),
LoanInterest float,
MonthlyPayments Money default(0)
)


