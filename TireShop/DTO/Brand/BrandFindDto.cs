
using System.ComponentModel.DataAnnotations;
using TireShop.DTO.Interfaces;

namespace TireShop.DTO.Brand
{
    public class BrandFindDto : IFindDto
    {
        public int? Id { get; set; }
        public string? Name { get; set; } = string.Empty;

        public int? Page { get; set; }
        public int? Perpage { get; set; }

        public string? Includes { get; set; }
        public string? OrderBy { get; set; }
        public string? Order { get; set; }

    }
}
