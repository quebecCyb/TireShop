using TireShop.Entities;
using TireShop.Repositories.Interfaces;
using TireShop.Repository;

namespace TireShop.Repositories
{
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        public BrandRepository(ApplicationDbContext context) : base(context) { }
    }
}
