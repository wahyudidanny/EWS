using AutoMapper;
using EWS.API.Responses;
using EWS.API.Entities;

public interface IAutoMapperMsRekapKebun
{
	IMapper GetMapper();

}
public class MappingT_MsRekapKebun : IAutoMapperMsRekapKebun
{
	private readonly IMapper _mapper;
	public MappingT_MsRekapKebun()
	{
		var config = new MapperConfiguration(cfg =>
		{
			cfg.CreateMap<T_MsRekapKebun, T_MsRekapKebunResponse>();
		});

		_mapper = config.CreateMapper();
	}

	public IMapper GetMapper()
	{
		return _mapper;
	}
}
