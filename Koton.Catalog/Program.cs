using Koton.Business.Services.CategoryServices;
using Koton.Business.Services.CategoryServices.Abstract;
using Koton.Core.Settings;
using Koton.DataAccess.Repositories.MongoDb.Abstract;
using Koton.DataAccess.Repositories.MongoDb.Concrete;
using Koton.Entity.Entities.Concrete;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using AutoMapper;
using Koton.Business.Mappings;
using Koton.DataAccess.Repositories.MongoDb.CategoryRepository;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection(nameof(DatabaseSettings)));


builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
    return new MongoClient(settings.ConnectionString);
});


builder.Services.AddScoped(sp =>
{
    var settings = sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
    var client = sp.GetRequiredService<IMongoClient>();
    return client.GetDatabase(settings.DatabaseName);
});


builder.Services.AddScoped<ICategoryRepository>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
    var database = sp.GetRequiredService<IMongoDatabase>();
    return new CategoryRepository(database, settings.CategoryCollectionName);
});


builder.Services.AddAutoMapper(typeof(GeneralMapper).Assembly);


builder.Services.AddScoped<ICategoryService, CategoryService>();


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
