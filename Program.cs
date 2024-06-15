using Microsoft.EntityFrameworkCore;
using SWD_IMS.Extensions;
using SWD_IMS.src.Application.Services;
using SWD_IMS.src.Domain.RepositoryContracts;
using SWD_IMS.src.Domain.ServiceContracts;
using SWD_IMS.src.Infrastructure.Context;
using SWD_IMS.src.Infrastructure.Repository;
using System.Text.Json;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(opts =>
{
    opts.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
});;

// Add services to the container.
// var types = AppDomain.CurrentDomain.GetAssemblies()
//     .SelectMany(s => s.GetTypes())
//     .Where(p => p.IsClass && !p.IsAbstract && p.Name.EndsWith("Repository"));

// foreach (var type in types)
// {
//     var interfaceType = type.GetInterfaces().FirstOrDefault(i => i.Name == "I" + type.Name);
//     if (interfaceType != null)
//     {
//         builder.Services.AddScoped(interfaceType, type);
//     }
// }
// var serviceTypes = AppDomain.CurrentDomain.GetAssemblies()
//     .SelectMany(s => s.GetTypes())
//     .Where(p => p.IsClass && !p.IsAbstract && p.Name.EndsWith("Service"));

// foreach (var type in serviceTypes)
// {
//     var interfaceType = type.GetInterfaces().FirstOrDefault(i => i.Name == "I" + type.Name);
//     if (interfaceType != null)
//     {
//         builder.Services.AddScoped(interfaceType, type);
//     }
// }
//Configure Repository
builder.Services.AddScoped<ITrainingProgramRepository, TrainingProgramRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
//Configure Service
builder.Services.AddScoped<ITrainingProgramService, TrainingProgramService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBCryptService, BCryptService>();
// Configue Connection String
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SwdImsContext>(options => options.UseSqlServer(connectionString).LogTo(Console.WriteLine, LogLevel.Information));

builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
// Logger
builder.Services.ConfigureLoggerService();
// Repository Wapper
builder.Services.ConfigureRepositoryWrapper();
// Service Wrapper
builder.Services.ConfigureServiceWrapper();
builder.Services.AddControllers();
// DB Connection
builder.Services.ConfigureMSSqlContext(builder.Configuration);
// AutoMapper
builder.Services.AddAutoMapper(typeof(Program));
// Response Handler
builder.Services.ConfigureReponseHandler();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
