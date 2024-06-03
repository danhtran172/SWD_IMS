using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SWD_IMS.Contracts;
using SWD_IMS.Entities.Contexts;
using SWD_IMS.Entities.Helpers;
using SWD_IMS.Middleware;
using SWD_IMS.Repository;
using SWD_IMS.ServiceContracts;
using SWD_IMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD_IMS.Extensions
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// Configures Cross-Origin Resource Sharing (CORS) policy for the services.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to configure.</param>
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        /// <summary>
        /// Configures IIS integration for the services.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to configure.</param>
        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }

        /// <summary>
        /// Configures the logger service for the services.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to configure.</param>
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        /// <summary>
        /// Configures the MSSQL context for the services.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to configure.</param>
        /// <param name="config">The <see cref="IConfiguration"/> containing the connection string.</param>
        public static void ConfigureMSSqlContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<SwdImsContext>(o => o.UseSqlServer(connectionString));
        }

        /// <summary>
        /// Configures the FamsContext for the services.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to configure.</param>
        //public static void ConfigureFamsContext(this IServiceCollection services)
        //{
        //    services.AddScoped<FamsContext>();
        //}

        /// <summary>
        /// Configures the repository wrapper for the services.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to configure.</param>
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

        public static void ConfigureServiceWrapper(this IServiceCollection services)
        {
            services.AddScoped<IServiceWrapper, ServiceWrapper>();
        }

        /// <summary>
        /// Configures the response handler for the services.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to configure.</param>
        public static void ConfigureReponseHandler(this IServiceCollection services)
        {
            services.AddSingleton<ResponseHandler>();
        }
    }
}
