using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderGenius.Core.Entities.Identity;
using OrderGenius.Infrastracture.Data;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// database config
builder.Services.AddDbContext<StoreContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("OrderGeniusDbConnection")));

// Api versioning
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
});
//

//await AppIdentityDbContextSeed.SeedUserData(UserManager<AppUser>>());
//static async Task SeedUserData(UserManager<AppUser> userManager)
//{
//    if (!userManager.Users.Any())
//    {
//        AppUser appUser = new AppUser
//        {
//            DisplayName = "Badruzzaman",
//            Email = "badru.cse@gmail.com",
//            Address = new Address
//            {
//                FirstName = "Badru",
//                LastName = "Zaman",
//                City = "Dhaka",
//                State = "Dhaka",
//                ZipCode = "1206",
//            }
//        };
//        await userManager.CreateAsync(appUser, "badru@123");
//    }
//}

// Logger configuration
var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
//

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
