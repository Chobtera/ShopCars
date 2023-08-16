using Microsoft.AspNetCore.Cors.Infrastructure;
using ShopCars.Web.Services;
using ShopCars.Web.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<ICarService, CarService>("CarsApi", c =>
{
    c.BaseAddress = new Uri(builder.Configuration["ServiceUri:CarsApi"]);
//    c.DefaultRequestHeaders.Add("Connection", "Keep-Alive");
//    c.DefaultRequestHeaders.Add("Keep-Alive", "3600");
//    c.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-CarsApi");
});

builder.Services.AddHttpClient<IBrandService, BrandService>("CarsApi",
    c => c.BaseAddress = new Uri(builder.Configuration["ServiceUri:CarsApi"])
);

builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IBrandService, BrandService>();

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
