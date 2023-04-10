
using Azure.Identity;
using Azure.Storage.Blobs;
using Microsoft.EntityFrameworkCore;
using RedeSocial.Domain.Interfaces.Repository;
using RedeSocial.Domain.Interfaces.Services;
using RedeSocial.Domain.Services;
using RedeSocial.Infrastructure.Context;
using RedeSocial.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Conexão com o banco de dados
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'AppDbContextConnection' not found.");
builder.Services.AddDbContext<RedeDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IPostRepository, PostRepository>();



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.UseCors(builder =>
{
    builder.AllowAnyHeader()
           .AllowAnyOrigin()
           .AllowAnyMethod();
});


app.Run();
