using AutoMapper;
using System.Linq.Expressions;
using TireShop.Services.Interfaces;
using TireShop.Repositories.Interfaces;
using TireShop.Entities;
using TireShop.Service;

namespace TireShop.Services
{
    public class OrderService : CrudService<Order>, IOrderService
    {
        public OrderService(IOrderRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
