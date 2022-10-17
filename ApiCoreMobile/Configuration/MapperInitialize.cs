using ApiCoreMobile.Data;
using ApiCoreMobile.Models;
using AutoMapper;

namespace ApiCoreMobile.Configuration
{
    public class MapperInitialize : Profile
    {
        public MapperInitialize()
        {
            CreateMap<Category,CategoryDto>().ReverseMap();
            CreateMap<Category,CreateCategoryDto>().ReverseMap();
            CreateMap<Mobiles,MobileDto>().ReverseMap();
            CreateMap<Mobiles,CreateMobileDto>().ReverseMap();
            CreateMap<ApiUser, UserDto>().ReverseMap();
        }
    }
}
