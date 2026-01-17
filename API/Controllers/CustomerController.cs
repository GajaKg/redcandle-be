using API.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        public CustomerController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var customers = _dbContext.Customers.ToList();

            return Ok(customers);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var customer = _dbContext.Customers.Find(id);

            if (customer == null) return NotFound();

            return Ok(customer);
        }
    }
}