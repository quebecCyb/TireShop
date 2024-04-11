
using System.ComponentModel.DataAnnotations;
using TireShop.Entities;
using TireShop.Schemas.Enums;

namespace TireShop.DTO.Order
{
    public class OrderCreateDto
    {
        public int UserId { get; set; }

        public int WarehouseId { get; set; }

        [StringLength(1000)]
        public string Cart { get; set; } = string.Empty;

        public StatusEnum Status { get; set; } = 0;
    }
}
