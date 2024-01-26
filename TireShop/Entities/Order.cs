using System.ComponentModel.DataAnnotations;
using TireShop.Schemas.Enums;

namespace TireShop.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }

        public int WarehouseId { get; set; }
        public Warehouse? Warehouse { get; set; }

        [StringLength(1000)]
        public string Cart { get; set; } = string.Empty;

        public StatusEnum Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
