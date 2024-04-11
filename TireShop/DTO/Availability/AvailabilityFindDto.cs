
using System.ComponentModel.DataAnnotations;
using TireShop.DTO.Interfaces;

namespace TireShop.DTO.Availability
{
    public class AvailabilityFindDto : IFindDto
    {
        public int? Id { get; set; }
        public int? WarehouseId { get; set; }
        public int? TireId { get; set; }

        public int? Page { get; set; }
        public int? Perpage { get; set; }

        public string? Includes { get; set; }
        public string? OrderBy { get; set; }
        public string? Order { get; set; }

    }
}
