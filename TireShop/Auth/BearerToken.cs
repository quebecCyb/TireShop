using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using TireShop.Auth.Interfaces;
using TireShop.Schemas.Auth;
using TireShop.Schemas.AuthJwtOptions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TireShop.Auth
{
    public class BearerToken : IToken
    {
        private CredentialsContainer _credentials;
        private readonly IConfiguration _config;

        public BearerToken(IConfiguration config, CredentialsContainer credentials)
        {
            // Key = Encoding.UTF8.GetBytes(config["AppSettings:JWTAuthSecret"] ?? throw new DriveNotFoundException("JWT Auth Secret Not Found"));
            _config = config;
            _credentials = credentials;
        }

        public SecurityTokenDescriptor CreateTokenDescriptor()
        {
            return new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(AuthTypes.Name, _credentials.Name), 
                    new Claim(AuthTypes.Email, _credentials.Email), 
                    new Claim(AuthTypes.Level, _credentials.Level.ToString()), 
                    new Claim(AuthTypes.Role, _credentials.Role), 
                    // Add more claims as needed
                }),
                Expires = DateTime.UtcNow.AddDays(30), // Token expiration time
                // SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(""), SecurityAlgorithms.HmacSha256Signature)
            };
        }

        public string CreateToken()
        {

            var jwtOptions = _config
                .GetSection("JwtOptions")
                .Get<JwtOptions>();

            var keyBytes = Encoding.UTF8.GetBytes(jwtOptions?.SigningKey ?? throw new DriveNotFoundException());
            var symmetricKey = new SymmetricSecurityKey(keyBytes);

            var signingCredentials = new SigningCredentials(
                symmetricKey,
                SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(AuthTypes.Name, _credentials.Name),
                new Claim(AuthTypes.Email, _credentials.Email),
                new Claim(AuthTypes.Level, _credentials.Level.ToString()),
                new Claim(AuthTypes.Role, _credentials.Role),
                new Claim(AuthTypes.Aud, jwtOptions.Audience)
            };


            var token = new JwtSecurityToken(
                issuer: jwtOptions.Issuer,
                audience: jwtOptions.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: signingCredentials);

            var rawToken = new JwtSecurityTokenHandler().WriteToken(token);
            return rawToken;
        }
    }
}
