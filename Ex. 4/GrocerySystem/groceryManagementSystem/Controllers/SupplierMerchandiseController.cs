using Microsoft.AspNetCore.Mvc;
using Service.Dto;
using Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace groceryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierMerchandiseController : ControllerBase
    {
        private readonly ISuppMerchService _orderItemsService;
        public SupplierMerchandiseController(ISuppMerchService orderItemsService)
        {
            this._orderItemsService = orderItemsService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public List<SupplierMerchandiseDto> Get()
        {
            return _orderItemsService.GetAll();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public SupplierMerchandiseDto Get(int id)
        {
            return _orderItemsService.GetById(id);
        }

        [HttpGet("supp/{suppId}")]
        public List<SupplierMerchandiseDto> GetByIdSupp(int suppId)
        {
            return _orderItemsService.GetByIdSupp(suppId);
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromForm] SupplierMerchandiseDto item)
        {
            _orderItemsService.Add(item);
        }
    }
}
