using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Koton.Discount.Business.Mappings;
using Koton.Discount.Business.Services.CouponServices.Abstract;
using Koton.Discount.Business.Services.CouponServices.Concrete;
using Koton.Discount.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Koton.Discount.DataAccess.Repositories.Dapper.CouponRepository.Abstract;
using Koton.Discount.DataAccess.Repositories.Dapper.CouponRepository.Concrete;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;


namespace Koton.Discount.Business.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICouponRepository, CouponRepository>();
          
            return services;
        }
        public static IServiceCollection AddDapperConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDbConnection>(sp =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                return new SqlConnection(connectionString);
            });

            return services;
        }
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICouponService, CouponService>();
            
            return services;
        }
        public static IServiceCollection AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(GeneralMapper).Assembly);
            return services;
        }
        public static IServiceCollection AddFluentValidationConfiguration(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
