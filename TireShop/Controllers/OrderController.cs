using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TireShop.DTO.Order;
using TireShop.Entities;
using TireShop.Exceptions;
using TireShop.Services.Interfaces;
using TireShop.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderShop.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;
        private readonly IMapper _mapper;

        public OrderController(IOrderService service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

            
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Order))]
        [ProducesResponseType(400)]
        public ActionResult CreateOrder([FromBody] OrderCreateDto Body)
        {
            if (!ModelState.IsValid)
                throw new BadRequest($"Form Body Is Not Valid!");

            return Ok(new ResponseFormat<Order> { Data = _service.Create(_mapper.Map<Order>(Body)) });
        }

        [HttpGet]
        //[Authorize(Policy = Policy.ADMIN)]
        [ProducesResponseType(200, Type = typeof(ICollection<Order>))]
        [ProducesResponseType(400)]
        public ActionResult GetOrders([FromQuery] OrderFindDto Body)
        {
            if (!ModelState.IsValid)
                throw new BadRequest($"Form Body Is Not Valid!");

            return Ok(new ResponseFormat<List<Order>>
            {
                Data = _mapper.Map<List<Order>>(_service.Get(t => t.Id == Body.Id))
            });
        }


        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400)]
        public ActionResult GetOrder(int id)
        {
            if (!ModelState.IsValid)
                throw new BadRequest($"Form Body Is Not Valid!");

            return Ok(new ResponseFormat<List<Order>>
            {
                Data = _mapper.Map<List<Order>>(_service.Get(t => t.Id == id))
            });
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400)]
        public ActionResult DeleteOrder(int id)
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
