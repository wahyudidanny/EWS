
namespace EWS.API.Entities
{
	public static class Setup
	{
		public static void RegisterAutoMapper(this WebApplicationBuilder builder)
		{
			builder.Services.AddSingleton<IAutoMapperMsRekapKebun, MappingT_MsRekapKebun>();
			builder.Services.AddSingleton<IAutoMapperMsRekapGroup, MappingT_MsRekapGroup>();
			
		}

	}
}