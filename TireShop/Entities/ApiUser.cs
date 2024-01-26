using System.ComponentModel.DataAnnotations;
using TireShop.Schemas.Enums;

namespace TireShop.Entities
{
    public class ApiUser
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; } = string.Empty;

        [StringLength(255)]
        public string Email { get; set; } = string.Empty;

        [StringLength(512)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public required string Role { get; set; }

        [Required]
        public required int Level { get; set; }
    }
}
