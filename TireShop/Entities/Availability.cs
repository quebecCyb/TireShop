using System.ComponentModel.DataAnnotations;
using TireShop.Schemas.Enums;

namespace TireShop.Entities
{
    public class Availability
    {
        public int Id { get; set; }

        public int WarehouseId { get; set; }
        public Warehouse? Warehouse { get; set; }


        public int TireId { get; set; }
        public Tire? Tire { get; set; }

        public int Number { get; set; }
        public bool IsAvailable { get; set; }
    }
}
