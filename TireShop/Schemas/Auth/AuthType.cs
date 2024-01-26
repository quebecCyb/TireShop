
using System.Security.Claims;

namespace TireShop.Schemas.Auth
{
    public class AuthTypes
    {
        public const string Name = ClaimTypes.Name;
        public const string Email = ClaimTypes.Email;
        public const string Role = ClaimTypes.Role;
        public const string Level = "Level";
        public const string Aud = "Aud";
    }

    public struct CredentialsContainer
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Role { get; set; }
        public required int Level { get; set; }
    }
}
