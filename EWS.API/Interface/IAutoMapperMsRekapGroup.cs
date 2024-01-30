using AutoMapper;
using EWS.API.Responses;
using EWS.API.Entities;

public interface IAutoMapperMsRekapGroup
{
	IMapper GetMapper();

}
public class MappingT_MsRekapGroup : IAutoMapperMsRekapGroup
{
	private readonly IMapper _mapper;
	public MappingT_MsRekapGroup()
	{
		var config = new MapperConfiguration(cfg =>
		{
			cfg.CreateMap<T_MsRekapGroup, T_MsRekapGroupResponse>();
		});

		_mapper = config.CreateMapper();
	}

	public IMapper GetMapper()
	{
		return _mapper;
	}
}
