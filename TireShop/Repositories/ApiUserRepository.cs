using TireShop.Entities;
using TireShop.Repositories.Interfaces;
using TireShop.Repository;

namespace TireShop.Repositories
{
    public class ApiUserRepository : Repository<ApiUser>, IApiUserRepository
    {
        public ApiUserRepository(ApplicationDbContext context) : base(context) { }
    }
}
