
using System.ComponentModel.DataAnnotations;
using TireShop.DTO.Interfaces;

namespace TireShop.DTO.Tire
{
    public class TireFindDto : IFindDto
    {
        public int? Id { get; set; }
        
        public int? Page { get; set; }
        public int? Perpage { get; set; }

        public string? Includes { get; set; }
        public string? OrderBy { get; set; }
        public string? Order { get; set; }


        [StringLength(255)]
        public string Name { get; set; } = string.Empty;

        public int BrandId { get; set; }
        public string Model { get; set; } = "";

        public int Width { get; set; } = 0;
        public int Profile { get; set; } = 0;
        public int Diameter { get; set; } = 0;

        public bool Omologation { get; set; } = false;
        public bool ExtraLoad { get; set; } = false;
        public bool RunFlat { get; set; } = false;

        public string? TireClass { get; set; } = string.Empty;
        public string? SpeedIndex { get; set; } = string.Empty;
        public string? WeightIndex { get; set; } = string.Empty;

        public int Price { get; set; } = 0;
        public int ComplectPrice { get; set; } = 0;

        public int Discount { get; set; } = 0;
        public int DiscountedPrice { get; set; } = 0;
        public int DiscountedComplectPrice { get; set; } = 0;

        // Filter Parametrs
        public bool? IsNew { get; set; } = false;


    }
}
