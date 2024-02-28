using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using EWS.Services.Models;
using EWS.Services.Interface;
using EWS.Services.Services;

namespace EWS.Services.Setup
{
    public static class Startup
    {
        public static void RegisterContext(this IServiceCollection services, IConfigurationRoot configuration)
        {

            services.Configure<ConnectionStrings>(configuration.GetSection("ConnectionStrings"));
        }

             public static void RegisterContext(this WebApplicationBuilder builder)
        {
            RegisterContext(builder.Services, builder.Configuration);
             builder.Services.AddHttpClient();
        }

               public static void RegisterService(this WebApplicationBuilder builder)
        {
             RegisterService(builder.Services, builder.Configuration);
             builder.Services.AddHttpClient();
        }

        public static void RegisterService(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);
            services.AddMemoryCache();
            services.AddTransient<IDataService, DataServices>();

        }


    }
}