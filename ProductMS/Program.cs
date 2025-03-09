using ProductMS.Middlewares;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

#region Dapper Config
var dbConnection = builder.Configuration.GetSection("DbConnection:SQLServerConnection").Value;
builder.Services.AddSingleton<IDapperService>(new DapperService(dbConnection));
#endregion

#region Serilog
//https://github.com/serilog/serilog-aspnetcore
builder
	.Configuration
	.AddJsonFile("serilog-config.json")
	.Build();

builder.Services.AddSerilog((services, lc) => lc
	.ReadFrom.Configuration(builder.Configuration)
	.ReadFrom.Services(services)
	.Enrich.FromLogContext()
	.WriteTo.Console());
#endregion

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IProductService, ProductService>();

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

app.UseExceptionMiddleware();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Product}/{action=Index}/{id?}");

app.Run();
