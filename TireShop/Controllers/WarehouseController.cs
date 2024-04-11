using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TireShop.DTO.Warehouse;
using TireShop.Entities;
using TireShop.Exceptions;
using TireShop.Services.Interfaces;
using TireShop.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WarehouseShop.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseService _service;
        private readonly IMapper _mapper;

        public WarehouseController(IWarehouseService service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

            
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Warehouse))]
        [ProducesResponseType(400)]
        public ActionResult CreateWarehouse([FromBody] WarehouseCreateDto Body)
        {
            if (!ModelState.IsValid)
                throw new BadRequest($"Form Body Is Not Valid!");

            return Ok(new ResponseFormat<Warehouse> { Data = _service.Create(_mapper.Map<Warehouse>(Body)) });
        }

        [HttpGet]
        //[Authorize(Policy = Policy.ADMIN)]
        [ProducesResponseType(200, Type = typeof(ICollection<Warehouse>))]
        [ProducesResponseType(400)]
        public ActionResult GetWarehouses([FromQuery] WarehouseFindDto Body)
        {
            if (!ModelState.IsValid)
                throw new BadRequest($"Form Body Is Not Valid!");

            return Ok(new ResponseFormat<IEnumerable<Warehouse>>
            {
                Data = _service.Get(t => (Body.Id == null || t.Id == Body.Id))
            });
        }


        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400)]
        public ActionResult GetWarehouse(int id)
        {
            if (!ModelState.IsValid)
                throw new BadRequest($"Form Body Is Not Valid!");

            return Ok(new ResponseFormat<List<Warehouse>>
            {
                Data = _mapper.Map<List<Warehouse>>(_service.Get(t => t.Id == id))
            });
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400)]
        public ActionResult DeleteWarehouse(int id)
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
