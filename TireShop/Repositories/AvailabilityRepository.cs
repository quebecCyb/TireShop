using TireShop.Entities;
using TireShop.Repositories.Interfaces;
using TireShop.Repository;

namespace TireShop.Repositories
{
    public class AvailabilityRepository : Repository<Availability>, IAvailabilityRepository
    {
        public AvailabilityRepository(ApplicationDbContext context) : base(context) { }
    }
}
