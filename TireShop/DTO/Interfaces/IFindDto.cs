namespace TireShop.DTO.Interfaces
{
    public interface IFindDto
    {
        int? Id { get; set; }
        int? Page { get; set; }
        int? Perpage { get; set; }

        public string? Includes { get; set; }
        public string? OrderBy { get; set; }
        public string? Order { get; set; }
    }
}
