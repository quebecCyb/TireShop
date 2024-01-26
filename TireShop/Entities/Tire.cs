using System.ComponentModel.DataAnnotations;
using TireShop.Schemas.Enums;

namespace TireShop.Entities
{
    public class Tire
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; } = string.Empty;
        [StringLength(2000)]
        public string Desc { get; set; } = string.Empty;

        public int? BrandId { get; set; }
        public Brand? Brand { get; set; }
        [StringLength(255)]
        public string Model { get; set; } = "";

        public SeasonsEnum Season { get; set; }
        public int Width { get; set; } = 0;
        public int Profile { get; set; } = 0;
        public int Diameter { get; set; } = 0;

        public bool Omologation { get; set; } = false;
        public bool ExtraLoad { get; set; } = false;
        public bool RunFlat { get; set; } = false;

        [StringLength(5)]
        public string TireClass { get; set; } = string.Empty;
        [StringLength(5)]
        public string SpeedIndex { get; set; } = string.Empty;
        [StringLength(5)]
        public string WeightIndex { get; set; } = string.Empty;

        public int Price { get; set; } = 0;
        public int ComplectPrice { get; set; } = 0;

        public int Discount { get; set; } = 0;
        public int DiscountedPrice { get; set; } = 0;
        public int DiscountedComplectPrice { get; set; } = 0;

        // Filter Parametrs
        public bool IsNew { get; set; } = false;

        public ICollection<Availability>? Availabilities { get; set; }
    }
}
