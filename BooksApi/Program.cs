using BooksAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<APIDbContext>(x => x.UseSqlServer(
    "Data Source = KOMPUTER; DataBase=DataBooksAPI; Persist Security Info = false;integrated security=true; trustServerCertificate=true"
    //"server=KOMPUTER;database=BooksDB;trusted_connection=true;"
    ));

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
