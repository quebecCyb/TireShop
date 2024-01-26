using AutoMapper;
using TireShop.DTO.Tire;
using TireShop.Entities;

namespace TireShop.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TireCreateDto, Tire>();
        }
    }
}
