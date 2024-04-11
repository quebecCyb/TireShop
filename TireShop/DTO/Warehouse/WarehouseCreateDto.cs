
using System.ComponentModel.DataAnnotations;

namespace TireShop.DTO.Warehouse
{
    public class WarehouseCreateDto
    {
        [StringLength(255)]
        public string Name { get; set; } = string.Empty;

        [StringLength(255)]
        public string Location { get; set; } = string.Empty;
    }
}
