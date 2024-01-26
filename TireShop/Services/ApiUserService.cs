using AutoMapper;
using System.Security.Cryptography;
using System.Text;
using TireShop.Entities;
using TireShop.Repositories.Interfaces;
using TireShop.Services.Interfaces;

namespace TireShop.Service
{
    public class ApiUserService : CrudService<ApiUser>, IApiUserService
    {
        public ApiUserService(IApiUserRepository repository, IMapper mapper) : base(repository, mapper){}

        public string GetPasswordHash(string password)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            byte[] hash = SHA256.HashData(bytes);

            // Convert the byte array to a hexadecimal string
            StringBuilder builder = new ();
            for (int i = 0; i < hash.Length; i++)
            {
                builder.Append(hash[i].ToString("x2"));
            }

            return builder.ToString();
        }

        public bool ComparePassword(ApiUser user, string password)
        {
            return GetPasswordHash(password) == user.Password;
        }

        public ApiUser? Login(string name, string password)
        {
            var user = GetOne(user => user.Name == name);
            if (!ComparePassword(user, password))
                return null;
            return user;
        }

        public ApiUser? Create(string name, string password, string email, int level)
        {
            return Create(new ApiUser() { Name = name, Password = GetPasswordHash(password), Email = email, Level = level, Role = "" });
        }
    }
}
