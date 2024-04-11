using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TireShop.DTO.User;
using TireShop.Entities;
using TireShop.Exceptions;
using TireShop.Services.Interfaces;
using TireShop.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserShop.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UserController(IUserService service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

            
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
        public ActionResult CreateUser([FromBody] UserCreateDto Body)
        {
            if (!ModelState.IsValid)
                throw new BadRequest($"Form Body Is Not Valid!");

            return Ok(new ResponseFormat<User> { Data = _service.Create(_mapper.Map<User>(Body)) });
        }

        [HttpGet]
        //[Authorize(Policy = Policy.ADMIN)]
        [ProducesResponseType(200, Type = typeof(ICollection<User>))]
        [ProducesResponseType(400)]
        public ActionResult GetUsers([FromQuery] UserFindDto Body)
        {
            if (!ModelState.IsValid)
                throw new BadRequest($"Form Body Is Not Valid!");

            return Ok(new ResponseFormat<List<User>>
            {
                Data = _mapper.Map<List<User>>(_service.Get(t => t.Id == Body.Id))
            });
        }


        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400)]
        public ActionResult GetUser(int id)
        {
            if (!ModelState.IsValid)
                throw new BadRequest($"Form Body Is Not Valid!");

            return Ok(new ResponseFormat<List<User>>
            {
                Data = _mapper.Map<List<User>>(_service.Get(t => t.Id == id))
            });
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400)]
        public ActionResult DeleteUser(int id)
        {
            if (!ModelState.IsValid)
                throw new BadRequest($"Form Body Is Not Valid!");
            _service.Delete(id);
            return Ok(new ResponseFormat<bool>
            {
                Data = !_service.Exists(id)
            });
        }
    }
}
