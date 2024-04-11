
using System.ComponentModel.DataAnnotations;

namespace TireShop.DTO.User
{
    public class UserCreateDto
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; } = string.Empty;

        [StringLength(255)]
        public string Email { get; set; } = string.Empty;

        [StringLength(512)]
        public string Password { get; set; } = string.Empty;
    }
}
