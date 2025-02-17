using Microsoft.EntityFrameworkCore;
using WhoCame.Accounts.Infrastructure;
using WhoCame.Accounts.Infrastructure.Seeding;
using WhoCame.Framework.Middlewares;
using WhoCame.Web;
using WhoCame.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddModules(builder.Configuration);

builder.Services.AddLogger(builder.Configuration);
builder.Services.AddSwagger();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var accountsSeeder = app.Services.GetRequiredService<AccountsSeeder>();

await accountsSeeder.SeedAsync();

app.UseExceptionMiddleware();

app.MapControllers();

await app.InitAndRunAsync();
