using Koton.Business.Mappings;
using Koton.Business.Services.CategoryServices.Abstract;
using Koton.Business.Services.CategoryServices.Concrete;
using Koton.Business.Services.ProductDetailServices.Abstract;
using Koton.Business.Services.ProductDetailServices.Concrete;
using Koton.Business.Services.ProductImageServices.Abstract;
using Koton.Business.Services.ProductServices.Abstract;
using Koton.Business.Services.ProductServices.Concrete;
using Koton.Core.Settings;
using Koton.DataAccess.Repositories.MongoDb.CategoryRepository;
using Koton.DataAccess.Repositories.MongoDb.CategoryRepository.Abstract;
using Koton.DataAccess.Repositories.MongoDb.CategoryRepository.Concrete;
using Koton.DataAccess.Repositories.MongoDb.ProductDetailRepository.Abstract;
using Koton.DataAccess.Repositories.MongoDb.ProductDetailRepository.Concrete;
using Koton.DataAccess.Repositories.MongoDb.ProductImageRepository.Abstract;
using Koton.DataAccess.Repositories.MongoDb.ProductImageRepository.Concrete;
using Koton.DataAccess.Repositories.MongoDb.ProductRepository;
using Koton.DataAccess.Repositories.MongoDb.ProductRepository.Abstract;
using Koton.DataAccess.Repositories.MongoDb.ProductRepository.Concrete;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Koton.Business.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabaseServices(this IServiceCollection services)
        {
            services.AddSingleton<IMongoClient>(sp =>
            {
                var settings = sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
                return new MongoClient(settings.ConnectionString);
            });

            services.AddScoped(sp =>
            {
                var settings = sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
                var client = sp.GetRequiredService<IMongoClient>();
                return client.GetDatabase(settings.DatabaseName);
            });

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository>(sp =>
            {
                var settings = sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
                var database = sp.GetRequiredService<IMongoDatabase>();
                return new CategoryRepository(database, settings.CategoryCollectionName);
            });
            services.AddScoped<IProductRepository>(sp =>
            {
                var settings = sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
                var database = sp.GetRequiredService<IMongoDatabase>();
                return new ProductRepository(database, settings.ProductCollectionName);

            });
            services.AddScoped<IProductDetailRepository>(sp =>
            {
                var settings = sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
                var database = sp.GetRequiredService<IMongoDatabase>();
                return new ProductDetailRepository(database, settings.ProductDetailCollectionName);

            });
            services.AddScoped<IProductImageRepository>(sp =>
            {
                var settings = sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
                var database = sp.GetRequiredService<IMongoDatabase>();
                return new ProductImageRepository(database, settings.ProductImageCollectionName);
            });

         

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductDetailDetailService, ProductDetailService>();
            services.AddScoped<IProductImageService, IProductImageService>();

           

            return services;
        }

        public static IServiceCollection AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(GeneralMapper).Assembly);
            return services;
        }
    }
}
