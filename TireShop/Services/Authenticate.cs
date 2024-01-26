using TireShop.Auth;
using TireShop.Auth.Interfaces;
using TireShop.Schemas.Auth;

namespace TireShop.Services
{
    public class Authenticate
    {
        readonly IConfiguration _config;
        public Authenticate(IConfiguration config)
        {
            _config = config;
        }

        public IToken CreateToken(CredentialsContainer credentials)
        {
            return new BearerToken(_config, credentials);
        }
    }
}
