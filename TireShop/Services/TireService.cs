using AutoMapper;
using System.Linq.Expressions;
using TireShop.Services.Interfaces;
using TireShop.Repositories.Interfaces;
using TireShop.Entities;
using TireShop.Service;

namespace TireShop.Services
{
    public class TireService : CrudService<Tire>, ITireService
    {
        public TireService(ITireRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
