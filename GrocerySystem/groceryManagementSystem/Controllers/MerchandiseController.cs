using Microsoft.AspNetCore.Mvc;
using Service.Dto;
using Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace groceryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchandiseController : ControllerBase
    {
        private readonly IService<MerchandiseDto> _merchService;
        public MerchandiseController(IService<MerchandiseDto> merchService)
        {
            this._merchService = merchService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public List<MerchandiseDto> Get()
        {
            return _merchService.GetAll();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public MerchandiseDto Get(int id)
        {
            return _merchService.GetById(id);
        }

        // POST api/<UserController>
        [HttpPost]
        public int Post([FromForm] MerchandiseDto item)
        {
            var result = _merchService.Add(item);
            return result.Id;
        }
    }
}
