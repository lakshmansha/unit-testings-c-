using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using UnitTest.API.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<UnitTestAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UnitTestAPIContext"), sql =>
    {
        sql.EnableRetryOnFailure(5);
        sql.CommandTimeout(60);
        sql.MigrationsAssembly("UnitTest.API");
    }));

// Add services to the container.

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

using (var scope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
{
    scope.ServiceProvider.GetRequiredService<UnitTestAPIContext>().Database.Migrate();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
