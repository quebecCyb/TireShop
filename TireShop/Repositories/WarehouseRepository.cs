using TireShop.Entities;
using TireShop.Repositories.Interfaces;
using TireShop.Repository;

namespace TireShop.Repositories
{
    public class WarehouseRepository : Repository<Warehouse>, IWarehouseRepository
    {
        public WarehouseRepository(ApplicationDbContext context) : base(context) { }
    }
}
