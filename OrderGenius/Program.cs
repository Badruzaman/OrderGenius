using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using OrderGenius.Application.CustomerServices;
using OrderGenius.Application.CustomServices;
using OrderGenius.Application.OrderServices;
using OrderGenius.Application.ProductServices;
using OrderGenius.Application.SerialNumberGenerator;
using OrderGenius.Core.Entities.Identity;
using OrderGenius.Core.Interfaces;
using OrderGenius.Helpers;
using OrderGenius.Infrastracture.Data;
using OrderGenius.Infrastracture.SeedData;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Jwt configuration starts here
var jwtIssuer = builder.Configuration.GetSection("Token:Issuer").Get<string>();
var jwtKey = builder.Configuration.GetSection("Token:Key").Get<string>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
 .AddJwtBearer(options =>
 {
     options.TokenValidationParameters = new TokenValidationParameters
     {
         ValidateIssuer = true,
         ValidateAudience = true,
         ValidateLifetime = true,
         ValidateIssuerSigningKey = true,
         ValidIssuer = jwtIssuer,
         ValidAudience = jwtIssuer,
         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
     };
 });
//Jwt configuration ends here

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// database config
builder.Services.AddDbContext<MsSqlContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("OrderGeniusDbConnection")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICodeGeneratorService, CodeGenerator>();

builder.Services.AddAutoMapper(typeof(MappingProfiles));
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddIdentity<AppUser, IdentityRole>()
       .AddEntityFrameworkStores<MsSqlContext>()
       .AddDefaultTokenProviders();

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
