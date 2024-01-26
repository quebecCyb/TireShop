namespace TireShop.Types.Auth
{
    public interface IAuthType
    {
        public string Id { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; }
        public string Email { get; set; }
        public string AccessLevel { get; set; }
        public string Role { get; set; }
    }
}
