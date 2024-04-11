using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TireShop.DTO.Availability;
using TireShop.Entities;
using TireShop.Exceptions;
using TireShop.Services.Interfaces;
using TireShop.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AvailabilityShop.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AvailabilityController : ControllerBase
    {
        private readonly IAvailabilityService _service;
        private readonly IMapper _mapper;

        public AvailabilityController(IAvailabilityService service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

            
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Availability))]
        [ProducesResponseType(400)]
        public ActionResult CreateAvailability([FromBody] AvailabilityCreateDto Body)
        {
            if (!ModelState.IsValid)
                throw new BadRequest($"Form Body Is Not Valid!");

            return Ok(new ResponseFormat<Availability> { Data = _service.Create(_mapper.Map<Availability>(Body)) });
        }

        [HttpGet]
        //[Authorize(Policy = Policy.ADMIN)]
        [ProducesResponseType(200, Type = typeof(ICollection<Availability>))]
        [ProducesResponseType(400)]
        public ActionResult GetAvailabilitys([FromQuery] AvailabilityFindDto Body)
        {
            if (!ModelState.IsValid)
                throw new BadRequest($"Form Body Is Not Valid!");

            return Ok(new ResponseFormat<List<Availability>>
            {
                Data = _mapper.Map<List<Availability>>(_service.Get(t => t.Id == Body.Id))
            });
        }


        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400)]
        public ActionResult GetAvailability(int id)
        {
            if (!ModelState.IsValid)
                throw new BadRequest($"Form Body Is Not Valid!");

            return Ok(new ResponseFormat<List<Availability>>
            {
                Data = _mapper.Map<List<Availability>>(_service.Get(t => t.Id == id))
            });
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400)]
        public ActionResult DeleteAvailability(int id)
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
