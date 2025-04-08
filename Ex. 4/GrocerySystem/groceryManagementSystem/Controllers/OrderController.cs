using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Dto;
using Service.Interfaces;
using Service.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace groceryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            this._orderService = orderService;
        }

        // GET: api/<UserController>
        [HttpGet]
        [Authorize(Roles = "User")]
        public List<OrderDto> Get()
        {
            return _orderService.GetAll();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public OrderDto Get(int id)
        {
            return _orderService.GetById(id);
        }

        // GET: api/<UserController>
        [HttpGet("supplierId/{supplierId}")]
        [Authorize(Roles = "Supplier")]
        public List<OrderDto> GetBySupplierId(int supplierId)
        {
            return _orderService.GetBySupplierId(supplierId);
        }

        // GET: api/<UserController>
        [HttpGet("pendingOrders")]
        [Authorize(Roles = "User")]
        public List<OrderDto> GetPendingOrders()
        {
            return _orderService.GetPendingOrders();
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromForm] OrderDto item)
        {
            _orderService.Add(item);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromForm] OrderDto item)
        {
            _orderService.Update(id, item);
        }
    }
}
