using Loan.Data;
using Loan.Data.EntityModel;
using Loan.DomainModel;
using Loan.DomainModel.Impl;
using Loan.Logic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IRepository<ClientEntity, Guid>, JsonRepository<ClientEntity, Guid>>();
builder.Services.AddScoped<ILoanCalculationStrategy, LoanCalculationStrategy>();
builder.Services.AddScoped<ILoanProcessor, LoanProcessor>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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