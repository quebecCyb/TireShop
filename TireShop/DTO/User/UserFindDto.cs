
using System.ComponentModel.DataAnnotations;
using TireShop.DTO.Interfaces;

namespace TireShop.DTO.User
{
    public class UserFindDto : IFindDto
    {
        public int? Id { get; set; }

        [StringLength(255)]
        public string? Name { get; set; }

        [StringLength(255)]
        public string? Email { get; set; }

        [StringLength(512)]
        public string? Password { get; set; }

        public int? Page { get; set; }
        public int? Perpage { get; set; }

        public string? Includes { get; set; }
        public string? OrderBy { get; set; }
        public string? Order { get; set; }

    }
}
