
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
        public string? Name { get; set; }

        public int? BrandId { get; set; }
        public string? Model { get; set; }

        public int? Width { get; set; }
        public int? Profile { get; set; }
        public int? Diameter { get; set; }

        public bool? Omologation { get; set; }
        public bool? ExtraLoad { get; set; }
        public bool? RunFlat { get; set; }

        public string? TireClass { get; set; }
        public string? SpeedIndex { get; set; }
        public string? WeightIndex { get; set; }

        public int Price { get; set; }
        public int ComplectPrice { get; set; }

        public int Discount { get; set; } 
        public int DiscountedPrice { get; set; }
        public int DiscountedComplectPrice { get; set; } 

        // Filter Parametr
        public bool? IsNew { get; set; }


    }
}
