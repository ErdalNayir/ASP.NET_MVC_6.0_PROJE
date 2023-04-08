using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using BulkyBookWeb.Repository.Abstract;
using BulkyBookWeb.Repository.Concrete;
using BulkyBookWeb.Validation;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(
    builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion("8.0.32")));

//Add Fluent Validation
builder.Services.AddSingleton<IValidator<Product>, ProductValidator>();

//Adding Repository
builder.Services.AddScoped<IRepository<Product>, ProductRepository>();

//AutoMapper
builder.Services.AddAutoMapper(System.Reflection.Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
