using AutoMapper;
using TireShop.DTO.Brand;
using TireShop.DTO.Tire;
using TireShop.DTO.Warehouse;
using TireShop.Entities;

namespace TireShop.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TireCreateDto, Tire>();
            CreateMap<BrandCreateDto, Brand>();
            CreateMap<WarehouseCreateDto, Warehouse>();
        }
    }
}
