using Kroells_Bank_API2.Models;
using Microsoft.EntityFrameworkCore;

var MyAllowAnyOrigin = "_myAllowAnyOrigin";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowAnyOrigin,
                      policy =>
                      {
                          policy.AllowAnyOrigin() // Allow any origin
                                .AllowAnyHeader() // Allow any header
                                .AllowAnyMethod(); // Allow any HTTP method
                      });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<KroellsBankContext>(options =>
{
    options.UseSqlServer("Server=localhost;Database=Kroells_Bank;User=sa;Password=Kode1234!;Encrypt=False;");
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(MyAllowAnyOrigin);
app.UseAuthorization();

app.MapControllers();

app.Run();
