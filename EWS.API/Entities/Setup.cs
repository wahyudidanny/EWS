
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

			builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection("ConnectionStrings"));
			builder.Services.Configure<FilePathAfdeling>(builder.Configuration.GetSection("filePathAfdeling"));
			builder.Services.Configure<FilePathKebun>(builder.Configuration.GetSection("filePathKebun"));
			builder.Services.AddMemoryCache();
			builder.Services.AddScoped<T_MsEwsServices>();

		}

	}
}