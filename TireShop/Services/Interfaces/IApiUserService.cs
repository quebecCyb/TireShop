using TireShop.Entities;
using TireShop.Service.Interfaces;

namespace TireShop.Services.Interfaces
{
    public interface IApiUserService : ICrudService<ApiUser>
    {
        ApiUser? Create(string name, string password, string email, int level);
        string GetPasswordHash(string password);
        bool ComparePassword(ApiUser user, string password);
        ApiUser? Login(string name, string password);
    }
}
