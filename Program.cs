using Microsoft.EntityFrameworkCore;
using SWD_IMS.Extensions;
using SWD_IMS.src.Application.Services;
using SWD_IMS.src.Domain.RepositoryContracts;
using SWD_IMS.src.Domain.ServiceContracts;
using SWD_IMS.src.Infrastructure.Context;
using SWD_IMS.src.Infrastructure.Repository;
using System.Text.Json;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using SWD_IMS.src.Application.Jwt;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(opts =>
{
    opts.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
}); ;

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
builder.Services.AddScoped<IInternRepository, InternRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
//Configure Service
builder.Services.AddScoped<ITrainingProgramService, TrainingProgramService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IInternService, InternService>();
builder.Services.AddScoped<IJwtService, JwtService>();

// Configue Connection String
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SwdImsContext>(options => options.UseSqlServer(connectionString).LogTo(Console.WriteLine, LogLevel.Information));
builder.Services.AddAuthorization();
builder.Services.AddAuthentication("Bearer").AddJwtBearer();
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
builder.Services.AddSwaggerGen(c =>
{
  c.SwaggerDoc("v1", new OpenApiInfo { Title = "SWD_IMS", Version = "v1" });

  // Add a bearer token to Swagger
  c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
  {
    Description = "JWT Authorization header using the Bearer scheme",
    Type = SecuritySchemeType.Http,
    Scheme = "bearer"
  });

  // Require the bearer token for all API operations
  c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
      {
          new OpenApiSecurityScheme
          {
              Reference = new OpenApiReference
              {
                  Type = ReferenceType.SecurityScheme,
                  Id = "Bearer"
              }
          },
          new string[] {}
      }
    });
});

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
