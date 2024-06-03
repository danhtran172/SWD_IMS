using SWD_IMS.Extensions;
using System.Text.Json;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(opts =>
{
    opts.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
});;
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
