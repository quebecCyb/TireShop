
using System.ComponentModel.DataAnnotations;
using TireShop.Entities;
using TireShop.Schemas.Enums;

namespace TireShop.DTO.Availability
{
    public class AvailabilityCreateDto
    {
        public int Id { get; set; }

        public int WarehouseId { get; set; }
        public int TireId { get; set; }

        public int Number { get; set; }
        public bool IsAvailable { get; set; }
    }
}
