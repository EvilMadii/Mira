using api.mapper.maps;
using AutoMapper;

namespace api.mapper;

class MapperInit
{
    public IMapper _generateConfig()
    {
        var _mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile<UserProfile>();
        });
        return _mapperConfig.CreateMapper();
    }
}