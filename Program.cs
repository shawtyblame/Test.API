using Test.API;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder();

string connection = "Server=(localdb)\\mssqllocaldb;Database=applicationdb;Trusted_Connection=True;";
builder.Services.AddDbContext<UserContext>(options => options.UseSqlServer(connection));

builder.Services.AddControllers();





builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var policyName = "CorsPolicy";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policyName,
        builder => {
            builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
