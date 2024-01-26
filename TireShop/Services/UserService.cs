using AutoMapper;
using System.Linq.Expressions;
using TireShop.Services.Interfaces;
using TireShop.Repositories.Interfaces;
using TireShop.Entities;
using TireShop.Service;

namespace TireShop.Services
{
    public class UserService : CrudService<User>, IUserService
    {
        public UserService(IUserRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
