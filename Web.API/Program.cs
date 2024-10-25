using DataAccess.DBContext;
using Microsoft.EntityFrameworkCore;
using DataAccess.Repository.Interfaces;
using DataAccess.Repository;
using Services;
using Services.Interfaces;
using Services.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
