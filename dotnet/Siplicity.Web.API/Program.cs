using Microsoft.EntityFrameworkCore;
using Siplicity.Web.API.DataAccessLayer;
using Siplicity.Web.API.DataProvider;
using Siplicity.Web.API.Interface;
using Siplicity.Web.API.Models;
using System;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("default");

if (connectionString == "")
{
    throw new InvalidOperationException("Connection string 'default' not found.");
}


//Dependency Injection
//Insert Interface and Service file in alphabetical order
builder.Services.AddScoped<IUserService, UserService>();


builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlServer(connectionString, sqlServerOptionsAction: sqlOptions =>
        sqlOptions.EnableRetryOnFailure()));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDataProvider>(provider => new SqlDataProvider(connectionString));

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
