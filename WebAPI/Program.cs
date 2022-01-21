using WebAPI.Interfaces;
using WebAPI.Logic;
using Microsoft.Extensions.Configuration;
using WebAPI.DataStorage;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("BankedDB");
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IExpensesRepository>
  (sp => new ExpensesService(connectionString, sp.GetRequiredService<ILogger<ExpensesService>>()));

builder.Services.AddSingleton<IIncomeRepository>
  (sp => new IncomeService(connectionString, sp.GetRequiredService<ILogger<IncomeService>>()));


builder.Services.AddSingleton<ILoanRepository>
  (sp => new LoanService(connectionString, sp.GetRequiredService<ILogger<LoanService>>()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
