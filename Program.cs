using _1to1relationcodefirst.Models;
using _1to1relationcodefirst.Repository.Implimentations;
using _1to1relationcodefirst.Repository.Interfaces;
using _1to1relationcodefirst.Services.Implimentation;
using _1to1relationcodefirst.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<OnetooneDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IPeopleRepository,PeopleRepository>();
builder.Services.AddScoped<IPersonalDetailsRepository,PersonalDetailsRepository>();
builder.Services.AddScoped<IPeopleServices,PeopleServices>();
builder.Services.AddScoped<IPersonDetailsServices,PersonDetailsServices>();


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
