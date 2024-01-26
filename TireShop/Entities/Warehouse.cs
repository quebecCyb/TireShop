using System.ComponentModel.DataAnnotations;
using TireShop.Schemas.Enums;

namespace TireShop.Entities
{
    public class Warehouse
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; } = string.Empty;

        [StringLength(255)]
        public string Location { get; set; } = string.Empty;

        public ICollection<Availability> Availabilities { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
