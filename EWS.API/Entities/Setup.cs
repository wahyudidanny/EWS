
using EWS.API.Services;
using EWS.API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EWS.API.Entities

{
	public static class Setup
	{
		public static void RegisterAutoMapper(this WebApplicationBuilder builder)
		{

			builder.Services.AddSingleton<IAutoMapperMsRekapKebun, MappingT_MsRekapKebun>();
			builder.Services.AddSingleton<IAutoMapperMsRekapGroup, MappingT_MsRekapGroup>();
			
		}

		public static void RegisterRepository(this WebApplicationBuilder builder)
		{
			builder.Services.AddScoped<T_MsEwsRepository>();

		}

		public static void RegisterService(this WebApplicationBuilder builder)
		{

			var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
			builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection("ConnectionStringsDev"));
			builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
			builder.Services.AddDbContext<EWSDbContext>(options => options.UseSqlServer(connectionString));

			builder.Services.AddMemoryCache();
			builder.Services.AddScoped<MsEwsServices>();

		}

	}
}