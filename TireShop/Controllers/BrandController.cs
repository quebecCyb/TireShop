using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TireShop.DTO.Brand;
using TireShop.Entities;
using TireShop.Exceptions;
using TireShop.Services.Interfaces;
using TireShop.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BrandShop.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _service;
        private readonly IMapper _mapper;

        public BrandController(IBrandService service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

            
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Brand))]
        [ProducesResponseType(400)]
        public ActionResult CreateBrand([FromBody] BrandCreateDto Body)
        {
            if (!ModelState.IsValid)
                throw new BadRequest($"Form Body Is Not Valid!");

            return Ok(new ResponseFormat<Brand> { Data = _service.Create(_mapper.Map<Brand>(Body)) });
        }

        [HttpGet]
        //[Authorize(Policy = Policy.ADMIN)]
        [ProducesResponseType(200, Type = typeof(ICollection<Brand>))]
        [ProducesResponseType(400)]
        public ActionResult GetBrands([FromQuery] BrandFindDto Body)
        {
            if (!ModelState.IsValid)
                throw new BadRequest($"Form Body Is Not Valid!");

            return Ok(new ResponseFormat<IEnumerable<Brand>>
            {
                Data = _service.Get(t => (Body.Id == null || t.Id == Body.Id))
            });
        }


        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400)]
        public ActionResult GetBrand(int id)
        {
            if (!ModelState.IsValid)
                throw new BadRequest($"Form Body Is Not Valid!");

            return Ok(new ResponseFormat<IEnumerable<Brand>>
            {
                Data = _service.Get(t => (t.Id == id))
            });
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400)]
        public ActionResult DeleteBrand(int id)
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
