
using System.ComponentModel.DataAnnotations;
using TireShop.Entities;
using TireShop.Schemas.Enums;

namespace TireShop.DTO.Brand
{
    public class BrandCreateDto
    {
        public string Name { get; set; } = string.Empty;
    }
}
