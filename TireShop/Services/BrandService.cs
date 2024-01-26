using AutoMapper;
using System.Linq.Expressions;
using TireShop.Services.Interfaces;
using TireShop.Repositories.Interfaces;
using TireShop.Entities;
using TireShop.Service;

namespace TireShop.Services
{
    public class BrandService : CrudService<Brand>, IBrandService
    {
        public BrandService(IBrandRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
