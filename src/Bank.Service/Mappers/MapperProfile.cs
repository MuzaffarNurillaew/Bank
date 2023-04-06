using AutoMapper;
using Bank.Domain.Entities;
using Bank.Service.Dtos.Users;

namespace Bank.Service.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserCreationDto, User>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
        }
    }
}
