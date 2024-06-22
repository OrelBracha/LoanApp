using loanAPI.Repositories;
using loanAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton<IClientRepository, ClientRepository>();
builder.Services.AddTransient<IInterestCalculationStrategyFactory, DefaultInterestCalculationStrategyFactory>();
builder.Services.AddTransient<ILoanService, LoanService>();

var app = builder.Build();

app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

