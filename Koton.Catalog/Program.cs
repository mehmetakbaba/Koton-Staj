using Koton.Business.Filters;
using Koton.Catalog.Business.Extensions;
using Koton.Core.Settings;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection(nameof(DatabaseSettings)));

builder.Services.AddDatabaseServices();
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddAutoMapperConfiguration();
builder.Services.AddFluentValidationConfiguration();
builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);
builder.Services.AddControllers(options => options.Filters.Add<FluentValidationFilter>());
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