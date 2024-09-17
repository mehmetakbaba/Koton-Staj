using Koton.Discount.Business.Extensions;
using Koton.Discount.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure DbContext
builder.Services.AddDbContext<DapperContext>(options =>
    options.UseSqlServer(connectionString));

// Add Dapper configuration and other services
builder.Services.AddDapperConfiguration(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddAutoMapperConfiguration();
builder.Services.AddFluentValidationConfiguration();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();