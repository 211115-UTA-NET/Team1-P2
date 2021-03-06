using WebAPI.Logic;
using Microsoft.Extensions.Configuration;
using WebAPI.DataStorage;
using Microsoft.EntityFrameworkCore;
using WebAPI;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("BankedDB");
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BankedDBContext>(options =>
{
  // logging to console is on by default
  options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<IRepositoryBank, EfRepository>();


builder.Services.AddCors(options =>
{
  // here you put all the origins that websites making requests to this API via JS are hosted at
  options.AddDefaultPolicy(builder =>
      builder
          .WithOrigins("http://127.0.0.1:5500",
                       "https://my-example-website.azurewebsites.net", "http://localhost:4200")
          .AllowAnyMethod()
          .AllowAnyHeader()
          .AllowCredentials());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
