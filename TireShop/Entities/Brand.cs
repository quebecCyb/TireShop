using System.ComponentModel.DataAnnotations;
using TireShop.Schemas.Enums;

namespace TireShop.Entities
{
    public class Brand
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; } = string.Empty;

        public ICollection<Tire> Tires { get; set; }
    }
}
