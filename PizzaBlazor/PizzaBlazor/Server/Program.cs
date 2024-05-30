using Domain.Repositories;
using Domain.UnitOfWork;
using Infraestructure;
using Infraestructure.Repositories;
using Infraestructure.UnitOfWork;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using PizzaBlazor.Server.Controllers;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<PizzaStoreContext>(options =>
    options.UseSqlServer(connectionString));
// Agrega el servicio OrderService
//builder.Services.AddScoped<IOrderService, OrderService>();
var app = builder.Build();
#region LLamada a los repositorios
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IPizzaRepository, PizzaRepository>();
builder.Services.AddTransient<IToppingRepository,ToppingRepository>();
builder.Services.AddTransient<IPizzaToppingRepository,PizzaToppingRepository>();
builder.Services.AddTransient<IAddressRepository, AddressRepository>();
builder.Services.AddTransient<IPizzaSpecialRepository, PizzaSpecialRepository>();
#endregion

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
