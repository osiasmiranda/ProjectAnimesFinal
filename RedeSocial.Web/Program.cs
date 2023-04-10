using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RedeSocial.Domain.Entities;
using RedeSocial.Domain.Interfaces.Repository;
using RedeSocial.Domain.Interfaces.Services;
using RedeSocial.Domain.Services;
using RedeSocial.Infrastructure.Context;
using RedeSocial.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("RedeDbContextConnection") ?? throw new InvalidOperationException("Connection string 'RedeDbContextConnection' not found.");
builder.Services.AddDbContext<RedeDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ProfileEntity>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<RedeDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<BlobStorageUpload>();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
//app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.UseCors();

app.Run();
