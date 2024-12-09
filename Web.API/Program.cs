using DataAccess.DBContext;
using Microsoft.EntityFrameworkCore;
using DataAccess.Repository.Interfaces;
using DataAccess.Repository;
using Services;
using Services.Interfaces;
using Services.Mappings;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//logger
var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File(@"C:\_TaskMates_Logs\api_log.txt", rollingInterval: RollingInterval.Day)
    .MinimumLevel.Information()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddControllers();

builder.Services.AddDbContext<TaskmatesDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("dbConnection"));
});

/***/
builder.Services.AddScoped<IDemoEmailListsDbSet,DemoEmailListsDbSet>();
builder.Services.AddScoped<IDemoEmailListService, DemoEmailListService>();
/***/

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

var app = builder.Build();

app.UseCors(options =>
{
    options.AllowAnyHeader();
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MyCors");

app.MapControllers();

app.Run();
