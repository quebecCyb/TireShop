using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TireShop.Auth;
using TireShop.DTO.ApiAuth;
using TireShop.Entities;
using TireShop.Exceptions;
using TireShop.Schemas.Auth;
using TireShop.Service;
using TireShop.Service.Interfaces;
using TireShop.Services;
using TireShop.Services.Interfaces;
using TireShop.Utils;

namespace TireShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        readonly Authenticate _authenticate;
        readonly IApiUserService _userService;

        public AuthController(Authenticate authenticate, IApiUserService userService) 
        {
            _authenticate = authenticate;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateToken([FromBody] LoginUserDto data)
        {
            ApiUser apiUser = _userService.Login(data.Name, data.Password) ?? throw new Forbidden("Invalid Credentials"); ;

            return Ok(new ResponseFormat<string>
            {
                Data = _authenticate.CreateToken(
                    new CredentialsContainer() { Id = apiUser.Id, Name = apiUser.Name, Email = apiUser.Email, Level = apiUser.Level, Role = apiUser.Role}
                    ).CreateToken()
            });
        }

        [AllowAnonymous]
        [HttpPost("user")]
        public IActionResult CreateUser([FromBody] LoginUserDto data)
        {
            ApiUser apiUser = _userService.Create(data.Name, data.Password, "", 0) ?? throw new Forbidden("Invalid Credentials");

            return Ok(new ResponseFormat<string>
            {
                Data = _authenticate.CreateToken(
                    new CredentialsContainer() { Id = apiUser.Id, Name = apiUser.Name, Email = apiUser.Email, Level = apiUser.Level, Role = apiUser.Role }
                    ).CreateToken()
            });
        }
    }
}
