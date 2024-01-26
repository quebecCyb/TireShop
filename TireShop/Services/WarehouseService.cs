using AutoMapper;
using System.Linq.Expressions;
using TireShop.Services.Interfaces;
using TireShop.Repositories.Interfaces;
using TireShop.Entities;
using TireShop.Service;

namespace TireShop.Services
{
    public class WarehouseService : CrudService<Warehouse>, IWarehouseService
    {
        public WarehouseService(IWarehouseRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
