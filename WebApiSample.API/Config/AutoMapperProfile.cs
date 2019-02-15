using AutoMapper;
using WebapiSample.API.Services;
using WebapiSample.Data.Entities;

namespace WebapiSample.API.Config
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Location, LocationDTO>().ReverseMap();
        }
    }
}
