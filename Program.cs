using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI_Test.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//added after
builder.Services.AddDbContext<IoxDbContext>(
    o => o.UseSqlServer());
//Mediator
//builder.Services.AddSingleton<IoxDbContext>();
builder.Services.AddMediatR(typeof(IoxDbContext).Assembly);  

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
