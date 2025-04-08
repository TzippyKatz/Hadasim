using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Service.Dto;
using Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace groceryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly IService<SupplierDto> _supplierService;
        public SupplierController(IService<SupplierDto> supplierService)
        {
            this._supplierService = supplierService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public List<SupplierDto> Get()
        {
            return _supplierService.GetAll();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public SupplierDto Get(int id)
        {
            return _supplierService.GetById(id);
        }

        //POST api/<UserController>
        [HttpPost]
        public int Post([FromForm] SupplierDto item)
        {
            //try
            //{
            //    var result = _supplierService.Add(item);
            //    return Ok(result);
            //}
            //catch (InvalidOperationException ex)
            //{
            //    return BadRequest(new { message = ex.Message });
            //}
            //catch (Exception ex)
            //{
            //    return StatusCode(500, new { message = "אירעה שגיאה בשרת", detail = ex.Message });
            //}
            var result = _supplierService.Add(item);
            return result.Id;
        }
    }
}
