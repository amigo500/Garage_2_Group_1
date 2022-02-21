using Garage_2_Group_1;
using Garage_2_Group_1.Extensions;
using Garage_2_Group_1.Automapper;
using Garage_2_Group_1.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<GarageContext2>(options =>

    options.UseSqlServer(builder.Configuration.GetConnectionString("GarageContext2")));

builder.Services.AddSingleton(builder.Configuration.GetSection("Garage").Get<GarageConfiguration>());

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IParkingService, ParkingService>();
builder.Services.AddScoped<IReceiptService, ReceiptService>();
builder.Services.AddScoped<IVehicleTypeSelectListService, VehicleTypeSelectListService>();
builder.Services.AddScoped<IUserSelectListService, UserSelectListService>();
builder.Services.AddAutoMapper(typeof(GarageMappings));
builder.Services.AddAutoMapper(typeof(UserMappings));

var app = builder.Build();

app.SeedDataAsync().GetAwaiter().GetResult();

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
    pattern: "{controller=Users}/{action=Index}/{id?}");

app.Run();
