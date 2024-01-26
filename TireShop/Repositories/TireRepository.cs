using TireShop.Entities;
using TireShop.Repositories.Interfaces;
using TireShop.Repository;

namespace TireShop.Repositories
{
    public class TireRepository : Repository<Tire>, ITireRepository
    {
        public TireRepository(ApplicationDbContext context) : base(context) { }
    }
}
